namespace PeroTools2.AccessKing
{
    public interface ICommandHandler<in TNotification> : ICommandExecutive<TNotification> where TNotification : INotification
    {
        void Handle(TNotification notification);
    }

    public interface ICommandHandler<in TNotification, out TResult> : ICommandExecutive<TNotification> where TNotification : INotification
    {
        TResult Handle(TNotification notification);
    }
}