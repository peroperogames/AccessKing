using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public interface INonNotificationEventBus : IAccessBus
    {
        void Publish();
        void Subscribe(IEventHandler eventHandler);
        bool Unsubscribe(IEventHandler eventHandler);
        void Clear();
    }
    public interface IAsyncNonNotificationEventBus : IAccessBus
    {
        Task PublishAsync();
        void Subscribe(IAsyncEventHandler eventHandler);
        bool Unsubscribe(IAsyncEventHandler eventHandler);
        void Clear();
    }
}