using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PeroTools2.AccessKing
{
    public readonly struct SyncCommandResult : ICommandResult,IDisposable
    {
        private readonly ArrayList m_Results;
        public SyncCommandResult(ArrayList results)
        {
            m_Results = results;
        }
        public IEnumerable<TResult> GetResults<TResult>() => m_Results.OfType<TResult>();

        public void Dispose()
        {
            m_Results.Clear();
            ObjectPool<ArrayList>.Recycle(m_Results);
        }
    }
}