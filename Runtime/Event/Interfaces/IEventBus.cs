namespace PeroTools2.AccessKing
{
    public interface IEventBus<in TEventObserver, TNotification> : IAccessBus
        where TEventObserver : IEventObserver
        where TNotification : INotification
    {
        bool Unsubscribe(TEventObserver observer);
        void Subscribe(TEventObserver handler);
        void Publish(in TNotification notification);
        void Clear();
    }

    
    public interface IEventBus : IAccessBus
    {
        bool Unsubscribe(IEventObserver eventObserver);
        void Subscribe(IEventObserver eventObserver);
        void Publish<TNotification>(in TNotification notification) where TNotification : INotification;
        void Publish();
        void Clear();
    }
}