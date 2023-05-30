namespace PeroTools2.AccessKing
{
    public abstract class CommandBus<TNotification, TOperation> : ICommandBus<TNotification, TOperation>, IAccessBus
        where TNotification : INotification
        where TOperation : ICommandOperation
    {
        private readonly ICommandHandlerFactory m_HandlerFactory;

        public CommandBus(ICommandHandlerFactory factory)
        {
            m_HandlerFactory = factory;
        }

        void IAccessBus.Dispatch(INotification notification)
        {
            if (notification is TNotification tNotification)
                Execute(m_HandlerFactory, tNotification);
            else
                ThrowHelper.ThrowWhenNotificationCastFailed<TNotification>(notification);
        }

        // public abstract TOperation Execute(TNotification notification);
        public abstract TOperation Execute(ICommandHandlerFactory commandHandlerFactory, TNotification notification);
    }
}