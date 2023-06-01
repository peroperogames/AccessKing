namespace PeroTools2.AccessKing
{
    public interface ICommandSchedule<in TTheme>
    {
        ICommandBus<TNotification> GetBus<TNotification>(TTheme theme) where TNotification : INotification;
        bool TryGetBus<TNotification>(TTheme theme, out ICommandBus<TNotification> bus) where TNotification : INotification;
        void AddBus<TNotification>(TTheme theme, ICommandBus<TNotification> bus) where TNotification : INotification;
    }
}