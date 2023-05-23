using System;
using System.Collections.Generic;
using System.Linq;
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
            var results = m_Tasks.OfType<Task<TResult>>().Select(task => task.Result);
            return results;
        }

        public void Dispose()
        {
            m_Tasks.Clear();
            ObjectPool<List<Task>>.Recycle(m_Tasks);
        }
    }
}