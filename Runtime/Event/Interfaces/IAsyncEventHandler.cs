using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public interface IAsyncEventHandler<in TNotification> : IEventObserver where TNotification : INotification
    {
        Task HandleAsync(TNotification notification);
    }
}