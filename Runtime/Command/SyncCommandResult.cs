using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PeroTools2.AccessKing
{
    public struct SyncCommandResult : ICommandResult
    {
        private readonly ArrayList m_Results;
        public SyncCommandResult(ArrayList results)
        {
            m_Results = results;
        }
        public IEnumerable<TResult> GetResults<TResult>() => m_Results.OfType<TResult>();
    }
}