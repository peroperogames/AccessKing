namespace PeroTools2.AccessKing
{
    public interface IWeakEventSubscriable<TNotification> where TNotification : INotification
    {
        void SubscribeWeakly(IEventHandler<TNotification> handler);
    }
}