using System.Collections;

namespace PeroTools2.AccessKing
{
    public class SyncCommandBus : ICommandBus, ICommandBus<SyncCommandOperation>
    {
        private readonly ICommandHandlerFactory m_HandlerFactory;

        public SyncCommandBus(ICommandHandlerFactory handlerFactory) => m_HandlerFactory = handlerFactory;

        void IAccessBus.Dispatch(INotification notification) => Execute(notification);

        ICommandOperation ICommandBus.Execute<TNotification>(TNotification notification) => Execute(notification);

        public SyncCommandOperation Execute<TNotification>(TNotification notification) where TNotification : INotification
        {
            var handlers = m_HandlerFactory.RequireExecutives<TNotification>();
            var results = ObjectPool<ArrayList>.Require();
            foreach (var handler in handlers)
            {
                handler.Handle(notification);
                if(handler is IResultAvailable resultGetter)
                {
                    results.Add(resultGetter.GetResult());
                }
            }
            return new SyncCommandOperation(results,handlers.Count);
        }
    }
}