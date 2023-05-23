using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public interface ITaskCommandHandler<in TNotification, out TTaskResult> : ICommandHandler<TNotification, TTaskResult> where TNotification : INotification where TTaskResult : Task { }
    public interface IAsyncCommandHandler<in TNotification> : ITaskCommandHandler<TNotification, Task> where TNotification : INotification { }
    public interface IAsyncCommandHandler<in TNotification, TResult> : ITaskCommandHandler<TNotification, Task<TResult>> where TNotification : INotification { }
}