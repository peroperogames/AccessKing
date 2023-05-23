using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public interface IAsyncEventHandler : IEventObserver
    {
        Task HandleAsync();
    }

    public interface IAsyncEventHandler<in TNotification> : IEventObserver
    {
        Task HandleAsync(TNotification notification);
    }

}