using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public class AsyncCommandBus : ICommandBus, ICommandBus<AsyncCommandOperation>
    {
        private readonly ICommandHandlerFactory m_HandlerFactory;

        public AsyncCommandBus(ICommandHandlerFactory handlerFactory) => m_HandlerFactory = handlerFactory;

        void IAccessBus.Dispatch(INotification notification) => Execute(notification);

        ICommandOperation ICommandBus.Execute<TNotification>(TNotification notification) => Execute(notification);

        public AsyncCommandOperation Execute<TNotification>(TNotification notification) where TNotification : INotification
        {
            var executives = m_HandlerFactory.RequireExecutives<TNotification>();
            var results = ObjectPool<List<Task>>.Require();
            foreach (var handler in executives)
            {
                handler.Handle(notification);
                if (handler is IResultAvailable resultGetter)
                {
                    if (resultGetter is IResultAvailable<Task> taskResultGetter)
                    {
                        results.Add(taskResultGetter.GetResult());
                    }
                    else
                    {
                        results.Add(Task.FromResult(resultGetter.GetResult()));
                    }
                }
            }
            return new AsyncCommandOperation(results, executives.Count);
        }
    }
}