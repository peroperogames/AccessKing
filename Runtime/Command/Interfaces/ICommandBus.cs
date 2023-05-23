namespace PeroTools2.AccessKing
{
    public interface ICommandBus : IAccessBus
    {
        ICommandResult Execute<TNotification>(TNotification notification) where TNotification : INotification;
    }

    public interface ICommandBus<out TResult> : IAccessBus where TResult : ICommandResult
    {
        TResult Execute<TNotification>(TNotification notification) where TNotification : INotification;
    }

    public interface ICommandBus<in TNotification, out TResult> : IAccessBus where TNotification : INotification where TResult : ICommandResult
    {
        TResult Execute(TNotification notification);
    }
}