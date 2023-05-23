using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public class AsyncCommandBus : ICommandBus, ICommandBus<AsyncCommandResult>
    {
        private readonly IAsyncCommandHandlerFactory m_HandlerFactory;

        public AsyncCommandBus(IAsyncCommandHandlerFactory handlerFactory) => m_HandlerFactory = handlerFactory;

        void IAccessBus.Dispatch(INotification notification) => Execute(notification);

        ICommandResult ICommandBus.Execute<TNotification>(TNotification notification) => Execute(notification);

        public AsyncCommandResult Execute<TNotification>(TNotification notification) where TNotification : INotification
        {
            var handlers = m_HandlerFactory.RequireHandlers<TNotification>();
            var list = ObjectPool<List<Task>>.Require();
            foreach (var handler in handlers)
            {
                list.Add(handler.Handle(notification));
            }
            return new AsyncCommandResult(list);
        }
    }
}