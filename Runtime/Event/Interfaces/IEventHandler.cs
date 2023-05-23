namespace PeroTools2.AccessKing
{
    
    public interface IEventHandler : IEventObserver
    {
        void Handle();
    }
    public interface IEventHandler<TNotification> : IEventObserver where TNotification : INotification
    {
        void Handle(in TNotification notification);
    }

}