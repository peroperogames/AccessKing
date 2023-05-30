using System;

namespace PeroTools2.AccessKing
{
    public abstract class CommandBus<TNotification, TOperation> : ICommandBus<TNotification, TOperation>, IAccessBus
        where TNotification : INotification
        where TOperation : ICommandOperation
    {
        protected readonly ICommandHandlerFactory handlerFactory;
        public CommandBus(ICommandHandlerFactory factory)
        {
            handlerFactory = factory;
        }

        void IAccessBus.Dispatch(INotification notification)
        {
            if (notification is TNotification tNotification)
                Execute(tNotification);
            else
                ThrowHelper.ThrowWhenNotificationCastFailed<TNotification>(notification);

        }

        public abstract TOperation Execute(TNotification notification);
    }
}