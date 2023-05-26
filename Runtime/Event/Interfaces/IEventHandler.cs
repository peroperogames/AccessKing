namespace PeroTools2.AccessKing
{

    public interface IEventHandler<TNotification> : IEventObserver where TNotification : INotification
    {
        void Handle(in TNotification notification);
    }
    public interface IEventHandler : IEventHandler<ParameterNotification> { }
}