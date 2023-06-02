namespace PeroTools2.AccessKing
{
    public interface ICommandHandlerFactoryModifiable 
    {
        //ICommandHandlerFactory<TNotification> handlerFactory { get; }
        void SetFactory(ICommandHandlerFactory handlerFactory);
    }
}