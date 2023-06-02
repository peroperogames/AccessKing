namespace PeroTools2.AccessKing
{
    public interface ICommandHandler<TNotification> 
        where TNotification : INotification
    {
        void Handle(ref TNotification notification);
    }
    
    public interface ICommandHandler : ICommandHandler<Empty> { }


    public interface ICommandHandler<TNotification, out TResult> : ICommandHandler<TNotification>, IResultAvailable<TResult> 
        where TNotification : INotification { }
}