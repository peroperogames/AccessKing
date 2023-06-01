namespace PeroTools2.AccessKing
{
    public interface ICommandBus<in TNotification>
        where TNotification : INotification
    {
        CommandOperation Execute(TNotification notification);
    }
}