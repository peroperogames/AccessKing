namespace PeroTools2.AccessKing
{
    public interface ICommandBus
    {
        ICommandHandlerFactory handlerFactory { get; }
    }

    public interface ICommandBus<in TNotification, out TOperation> : ICommandBus
        where TNotification : INotification
        where TOperation : ICommandOperation
    {
        TOperation Execute(TNotification notification);
    }
}