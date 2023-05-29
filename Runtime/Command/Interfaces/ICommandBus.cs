namespace PeroTools2.AccessKing
{
    public interface ICommandBus<out TResult> where TResult : ICommandOperation
    {
        TResult Execute<TNotification>(TNotification notification) where TNotification : INotification;
    }
}