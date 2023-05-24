namespace PeroTools2.AccessKing
{
    public interface IEventSchedule<in TTheme, in TEventObserver> : IAccessSchedule<INotificationEventBus, TTheme>
        where TEventObserver : IEventObserver
    {
        void Subscribe<TNotification>(TTheme theme, IEventHandler handler);
        void UnSubscribe<TNotification>(TTheme theme, IEventHandler handler);
        void Publish<TNotification>(TTheme theme, in TNotification notification);
    }
}