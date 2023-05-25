using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public interface INonNotificationEventBus : IEventBus
    {
        void Publish();
        void Subscribe(IEventHandler eventHandler);
        bool Unsubscribe(IEventHandler eventHandler);
        void Clear();
    }
    public interface IAsyncNonNotificationEventBus : IEventBus
    {
        Task PublishAsync();
        void Subscribe(IAsyncEventHandler eventHandler);
        bool Unsubscribe(IAsyncEventHandler eventHandler);
        void Clear();
    }
}