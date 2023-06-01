namespace PeroTools2.AccessKing
{
    public interface ICommandBus
    {
        ICommandHandlerFactory handlerFactory { get; }
    }

    public interface ICommandBus<in TNotification> : ICommandBus
        where TNotification : INotification
    {
        CommandOperation Execute(TNotification notification);
    }
}