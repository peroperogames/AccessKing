namespace PeroTools2.AccessKing
{
    
    public interface IEventBus<TNotification> where TNotification : INotification
    {
        bool Unsubscribe(IEventHandler<TNotification> handler);
        void Subscribe(IEventHandler<TNotification> handler);
        void Broadcast(in TNotification notification);
        void Clear();
    }
    
}