namespace PeroTools2.AccessKing
{
    public interface IEventSchedule<in TTheme>
    {
        IEventBus<TNotification> GetBus<TNotification>(TTheme theme) where TNotification : INotification;
        bool TryGetBus<TNotification>(TTheme theme, out IEventBus<TNotification> bus) where TNotification : INotification;
        void AddBus<TNotification>(TTheme theme, ISchedulableEventBus<TNotification> bus) where TNotification : INotification;
    }
}