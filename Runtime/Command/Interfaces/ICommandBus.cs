namespace PeroTools2.AccessKing
{
    public interface ICommandBus<TNotification>
        where TNotification : INotification
    {
        CommandOperation Execute(ref TNotification notification);
    }
}