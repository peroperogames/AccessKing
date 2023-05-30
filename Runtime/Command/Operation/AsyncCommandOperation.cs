using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public struct AsyncCommandOperation : ICommandOperation, IDisposable
    {
        private readonly List<Task> m_Tasks;
        private bool isDones;
        public readonly int count;

        public AsyncCommandOperation(List<Task> tasks,int count)
        {
            m_Tasks = tasks;
            isDones = false;
            this.count = count;
        }

        public async Task WhenAnyDone()
        {
            if (isDones) return;
            await Task.WhenAny(m_Tasks);
        }

        public async Task WhenAllDone()
        {
            if (!isDones)
            {
                await Task.WhenAll(m_Tasks);
                isDones = true;
            }
        }

        public async Task<IEnumerable<TResult>> GetResultsAsync<TResult>()
        {
            if (!isDones)
            {
                await Task.WhenAll(m_Tasks);
                isDones = true;
            }

            var results = new List<TResult>();
            foreach (var task in m_Tasks)
            {
                if (task is Task<TResult> resultTask)
                {
                    results.Add(resultTask.Result);
                }
                else if (task is Task<object> objectTask && objectTask.Result is TResult result)
                {
                    results.Add(result);
                }
            }

            return results;
        }

        public void Dispose()
        {
            m_Tasks.Clear();
            ObjectPool<List<Task>>.Recycle(m_Tasks);
        }
    }
}