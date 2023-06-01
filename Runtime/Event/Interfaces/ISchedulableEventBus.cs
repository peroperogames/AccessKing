namespace PeroTools2.AccessKing
{
    public interface ISchedulableEventBus<TNotification> : IEventBus<TNotification>, IAccessBus where TNotification : INotification { }
}