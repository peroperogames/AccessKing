namespace PeroTools2.AccessKing
{
    public interface ISchedulableCommandBus<TNotification> : IAccessBus, ICommandBus<TNotification>, ICommandHandlerFactoryModifiable where TNotification : INotification { }
}