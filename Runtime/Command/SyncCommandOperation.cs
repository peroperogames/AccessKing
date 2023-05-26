using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PeroTools2.AccessKing
{
    public readonly struct SyncCommandOperation : ICommandOperation,IDisposable
    {
        private readonly ArrayList m_Results;
        public readonly int count;

        internal SyncCommandOperation(ArrayList results, int count)
        {
            m_Results = results;
            this.count = count;
        }
        public IEnumerable<TResult> GetResults<TResult>() => m_Results.OfType<TResult>();

        public void Dispose()
        {
            m_Results.Clear();
            ObjectPool<ArrayList>.Recycle(m_Results);
        }
    }
}