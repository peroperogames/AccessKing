namespace PeroTools2.AccessKing
{
    public interface IEventSchedule<in TTheme>
    {
        bool TryGetBus<TNotification>(TTheme theme, out IEventBus<TNotification> bus) where TNotification : INotification;

        void AddBus<TNotification>(TTheme theme, IEventBus<TNotification> bus) where TNotification : INotification;
    }
}