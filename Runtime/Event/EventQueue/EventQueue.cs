using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace PeroTools2.AccessKing
{
    public class EventQueue : IEventBus
    {
        private readonly Dictionary<Type, (List<INotification> notificationQueue, List<IEventObserver> eventHandlerQueue)> m_NotificationEventHandlerMaps = new Dictionary<Type, (List<INotification>, List<IEventObserver>)>();

        public void Clear() => m_NotificationEventHandlerMaps.Clear();
        void IAccessBus.Dispatch(INotification notification) => ((IEventBus) this).Publish(in notification);
        void IEventBus.Publish() => throw new InvalidOperationException();


        bool IEventBus.Unsubscribe(IEventObserver eventObserver)
        {
            if (eventObserver == null)
            {
                throw new ArgumentException("Event observer is null.");
            }
            Assert.IsTrue(eventObserver.TryGetNotificationType(out var notificationType));
            return m_NotificationEventHandlerMaps.TryGetValue(notificationType, out var queuePair) && queuePair.eventHandlerQueue.Remove(eventObserver);
        }

        void IEventBus.Subscribe(IEventObserver eventObserver)
        {
            if (eventObserver == null)
            {
                throw new ArgumentException("Event observer is null.");
            }
            Assert.IsTrue(eventObserver.TryGetNotificationType(out var notificationType));
            if (!m_NotificationEventHandlerMaps.TryGetValue(notificationType, out var queuePair))
            {
                queuePair = (new List<INotification>(), new List<IEventObserver>());
                Enqueue(queuePair.eventHandlerQueue, eventObserver);
                m_NotificationEventHandlerMaps[notificationType] = queuePair;
                return;
            }

            if (queuePair.notificationQueue.Count == 0)
                Enqueue(queuePair.eventHandlerQueue, eventObserver);
            else
                EventHelper.RequireEventHandlerHandleMethod(eventObserver.GetType(), notificationType)
                    .Invoke(eventObserver, new object[] {Dequeue(queuePair.notificationQueue)});
        }

        void IEventBus.Publish<TNotification>(in TNotification notification) => Publish(notification);

        public bool Unsubscribe<TNotification>(IEventHandler<TNotification> eventHandler) where TNotification : INotification
        {
            return m_NotificationEventHandlerMaps.TryGetValue(typeof(TNotification), out var queuePair) &&
                   queuePair.eventHandlerQueue.Remove(eventHandler);
        }

        public void Subscribe<TNotification>(IEventHandler<TNotification> eventHandler) where TNotification : INotification
        {
            Assert.IsNotNull(eventHandler);
            if (!m_NotificationEventHandlerMaps.TryGetValue(typeof(TNotification), out var queuePair))
            {
                queuePair = (new List<INotification>(), new List<IEventObserver>());
                Enqueue(queuePair.eventHandlerQueue, eventHandler);
                m_NotificationEventHandlerMaps[typeof(TNotification)] = queuePair;
                return;
            }

            if (queuePair.notificationQueue.Count == 0)
                Enqueue(queuePair.eventHandlerQueue, eventHandler);
            else
                eventHandler.Handle((TNotification) Dequeue(queuePair.notificationQueue));
        }

        public void Publish<TNotification>(in TNotification notification) where TNotification : INotification
        {
            if (!m_NotificationEventHandlerMaps.TryGetValue(typeof(TNotification), out var queuePair))
            {
                queuePair = (new List<INotification>(), new List<IEventObserver>());
                Enqueue(queuePair.notificationQueue, notification);
                m_NotificationEventHandlerMaps[typeof(TNotification)] = queuePair;
                return;
            }

            if (queuePair.eventHandlerQueue.Count == 0)
                Enqueue(queuePair.notificationQueue, notification);
            else
                ((IEventHandler<TNotification>) Dequeue(queuePair.eventHandlerQueue)).Handle(notification);
        }

        private static void Enqueue<T>(IList<T> list, T item)
        {
            list.Add(item);
        }

        private static T Dequeue<T>(IList<T> list)
        {
            var result = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return result;
        }
    }
}