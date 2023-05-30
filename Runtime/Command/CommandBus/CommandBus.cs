namespace PeroTools2.AccessKing
{
    public abstract class CommandBus<TNotification, TOperation> : ICommandBus<TNotification, TOperation>, IAccessBus
        where TNotification : INotification
        where TOperation : ICommandOperation
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


        public TOperation Execute(TNotification notification) => Execute(m_HandlerFactory, notification);
        protected abstract TOperation Execute(ICommandHandlerFactory handlerFactory, TNotification notification);
    }
}