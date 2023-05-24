namespace PeroTools2.AccessKing
{
    public interface ICommandExecutive { }
    public interface ICommandExecutive<in TNotification> : ICommandExecutive where TNotification : INotification { }
}