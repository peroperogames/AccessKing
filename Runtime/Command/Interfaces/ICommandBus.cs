namespace PeroTools2.AccessKing
{
    public interface ICommandBus<in TNotification, out TOperation>
        where TNotification : INotification
        where TOperation : ICommandOperation
    {
        TOperation Execute(ICommandHandlerFactory commandHandlerFactory, TNotification notification);
    }
}