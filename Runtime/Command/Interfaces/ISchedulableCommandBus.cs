namespace PeroTools2.AccessKing
{
    public interface ISchedulableCommandBus<in TNotification> : IAccessBus, ICommandBus<TNotification>, ICommandHandlerFactoryModifiable where TNotification : INotification { }
}