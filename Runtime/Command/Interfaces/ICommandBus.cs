namespace PeroTools2.AccessKing
{
    public interface ICommandBus : IAccessBus
    {
        ICommandOperation Execute<TNotification>(TNotification notification) where TNotification : INotification;
    }

    public interface ICommandBus<out TResult> : IAccessBus where TResult : ICommandOperation
    {
        TResult Execute<TNotification>(TNotification notification) where TNotification : INotification;
    }
}