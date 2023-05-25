using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public interface INotificationEventBus : IEventBus
    {
        void Publish<TNotification>(in TNotification eventHandler) where TNotification : INotification;
        void Subscribe<TNotification>(IEventHandler<TNotification> eventHandler) where TNotification : INotification;
        bool Unsubscribe<TNotification>(IEventHandler<TNotification> eventHandler) where TNotification : INotification;
        void Clear();
    }
    public interface IAsyncNotificationEventBus : IEventBus
    {
        Task PublishAsync<TNotification>(TNotification eventHandler) where TNotification : INotification;
        void Subscribe<TNotification>(IAsyncEventHandler<TNotification> eventHandler) where TNotification : INotification;
        bool Unsubscribe<TNotification>(IAsyncEventHandler<TNotification> eventHandler) where TNotification : INotification;
        void Clear();
    }
}