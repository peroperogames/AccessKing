using System;
using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public sealed class SyncEventBus : IWeakEventObserverSubscriable<IEventObserver>, INotificationEventBus, INonNotificationEventBus
    {
        private readonly List<object> m_Observers = new List<object>();
        public bool Unsubscribe(IEventObserver observer) => m_Observers.Remove(observer);
        public void Subscribe(IEventObserver eventObserver) => m_Observers.Add(eventObserver);
        public void SubscribeWeakly(IEventObserver observer) => m_Observers.Add(new WeakReference(observer));
        public void Clear() => m_Observers.Clear();
        void IAccessBus.Dispatch(INotification notification) => ((IEventBus) this).Publish(in notification);
        void INotificationEventBus.Subscribe<TNotification>(IEventHandler<TNotification> eventHandler) => Subscribe(eventHandler);
        bool INotificationEventBus.Unsubscribe<TNotification>(IEventHandler<TNotification> eventHandler) => Unsubscribe(eventHandler);
        void INonNotificationEventBus.Subscribe(IEventHandler eventHandler) => Subscribe(eventHandler);
        bool INonNotificationEventBus.Unsubscribe(IEventHandler eventHandler) => Unsubscribe(eventHandler);
        bool IEventBus.Unsubscribe(IEventObserver eventObserver) => Unsubscribe(eventObserver);
        void IEventBus.Subscribe(IEventObserver eventObserver) => Unsubscribe(eventObserver);
        void IEventBus.Publish<TNotification>(in TNotification notification)
        {
            if (notification == null || notification is ParameterNotification)
            {
                Publish();
            }
            else
            {
                Publish(notification);
            }
        }

        /// <summary>
        /// Publish event with notifications.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// Thrown when the event observer does not belong to the following type:
        /// <list type="IEventHandler">
        /// <item>IEventHandler&lt;TNotification&gt;</item>
        /// </list>
        /// </exception>
        public void Publish<TNotification>(in TNotification notification) where TNotification : INotification
        {
            for (var index = m_Observers.Count - 1; index >= 0; index--)
            {
                var observer = m_Observers[index];
                if (observer is WeakReference weakHandler)
                {
                    if (weakHandler.IsAlive)
                        observer = weakHandler.Target;
                    else
                    {
                        m_Observers.RemoveAt(index);
                        continue;
                    }
                }

                switch (observer)
                {
                    case IEventHandler<TNotification> eventHandler:
                        eventHandler.Handle(notification);
                        break;
                    default:
                        throw new NotSupportedException($"Unknown event observer type: {observer.GetType()} .");
                }
            }
        }

        /// <summary>
        /// Publish event with empty notification or empty parameter notification.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// Thrown when the event observer does not belong to the following type:
        /// <list type="IEventHandler">
        /// <item>IEventHandler&lt;ParameterNotification&gt;</item>
        /// <item>IEventHandler</item>
        /// </list>
        /// </exception>
        public void Publish()
        {
            for (var index = m_Observers.Count - 1; index >= 0; index--)
            {
                var observer = m_Observers[index];
                if (observer is WeakReference weakHandler)
                {
                    if (weakHandler.IsAlive)
                        observer = weakHandler.Target;
                    else
                    {
                        m_Observers.RemoveAt(index);
                        continue;
                    }
                }

                switch (observer)
                {
                    case IEventHandler<ParameterNotification> eventHandler:
                        eventHandler.Handle(ParameterNotification.Empty);
                        break;
                    case IEventHandler eventHandler:
                        eventHandler.Handle();
                        break;
                    default:
                        throw new NotSupportedException($"Unknown event observer type: {observer.GetType()} .");
                }
            }
        }
    }
}