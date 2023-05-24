namespace PeroTools2.AccessKing
{
    public interface IEventBus<in TEventObserver, TNotification> : IAccessBus
        where TEventObserver : IEventObserver
        where TNotification : INotification
    {
        bool Unsubscribe(TEventObserver eventObserver);
        void Subscribe(TEventObserver eventObserver);
        void Publish(in TNotification notification);
        void Clear();
    }
    
    public interface IEventBus : IAccessBus
    {
        bool Unsubscribe<TEventObserver>(TEventObserver eventObserver) where TEventObserver : IEventObserver;
        void Subscribe<TEventObserver>(TEventObserver eventObserver) where TEventObserver : IEventObserver;
        void Publish<TNotification>(in TNotification notification) where TNotification : INotification;
        void Clear();
    }
}