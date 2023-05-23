namespace PeroTools2.AccessKing
{
    public interface ICommandExecutive { }
    public interface ICommandExecutive<TNotification> : ICommandExecutive where TNotification : INotification { }
}