using System.Collections;

namespace PeroTools2.AccessKing
{
    public class CommandBus<TNotification> : ICommandBus<TNotification>, IAccessBus
        where TNotification : INotification
    {
        private readonly ICommandHandlerFactory m_HandlerFactory;
        ICommandHandlerFactory ICommandBus.handlerFactory => m_HandlerFactory;

        public CommandBus(ICommandHandlerFactory factory) => m_HandlerFactory = factory;


        void IAccessBus.Dispatch(INotification notification)
        {
            if (m_HandlerFactory == null)
                return;
            if (notification is TNotification tNotification)
                Execute(tNotification);
            else
                ThrowHelper.ThrowWhenNotificationCastFailed<TNotification>(notification);
        }

        public CommandOperation Execute(TNotification notification)
        {
            var handlers = m_HandlerFactory.RequireHandlers<TNotification>();
            var results = ObjectPool<ArrayList>.Require();
            foreach (var handler in handlers)
            {
                handler.Handle(notification);
                if (handler is IResultAvailable resultGetter)
                {
                    results.Add(resultGetter.GetResult());
                }
            }
            
            return new CommandOperation(results);
        }
    }
}