namespace PeroTools2.AccessKing
{
    public interface  IWeakEventObserverSubscriable<in TEventObserver> where TEventObserver : IEventObserver
    {
        void SubscribeWeakly(TEventObserver observer);
    }
}