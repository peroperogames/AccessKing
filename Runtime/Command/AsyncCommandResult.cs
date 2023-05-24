using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public readonly struct AsyncCommandResult : ICommandResult, IDisposable
    {
        private readonly List<Task> m_Tasks;
        public AsyncCommandResult(List<Task> tasks)
        {
            m_Tasks = tasks;
        }
        
        public async Task WhenAnyDone()
        {
            await Task.WhenAny(m_Tasks);
        }

        public async Task WhenAllDone()
        {
            await Task.WhenAll(m_Tasks);
        }
        
        public async Task<IEnumerable<TResult>> GetResultsAsync<TResult>()
        {
            await Task.WhenAll(m_Tasks);
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