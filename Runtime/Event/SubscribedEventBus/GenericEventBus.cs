using System;
using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public class GenericEventBus<TEventHandler> : IEventBus, IEventBus<TEventHandler, ParameterNotification> where TEventHandler : class, IEventHandler
    {
        private readonly List<TEventHandler> m_Handlers = new List<TEventHandler>();
        private readonly List<WeakReference<TEventHandler>> m_WeakHandlers = new List<WeakReference<TEventHandler>>();

        public void Subscribe(TEventHandler handler) => m_Handlers.Add(handler);

        void IEventBus.Subscribe(IEventObserver observer)
        {
            if (observer is TEventHandler handler)
                Subscribe(handler);
            else
                throw new InvalidCastException($"Observer is not a {observer.GetType()} type");
        }

        public void SubscribeWeakly(TEventHandler handler) => m_WeakHandlers.Add(new WeakReference<TEventHandler>(handler));

        bool IEventBus.Unsubscribe(IEventObserver observer)
        {
            if (observer is TEventHandler handler)
            {
                return Unsubscribe(handler);
            }

            return false;
        }

        public bool Unsubscribe(TEventHandler handler)
        {
            if (handler == null)
                return false;
            for (var index = m_Handlers.Count - 1; index >= 0; index--)
            {
                if (m_Handlers[index] != handler)
                    continue;
                m_Handlers.RemoveAt(index);
                return true;
            }

            for (var index = m_WeakHandlers.Count - 1; index >= 0; index--)
            {
                var weakTarget = m_WeakHandlers[index];
                if (weakTarget.TryGetTarget(out var targetHandler))
                {
                    if (targetHandler != handler)
                        continue;
                    m_WeakHandlers.RemoveAt(index);
                    return true;
                }

                m_WeakHandlers.RemoveAt(index);
            }

            return false;
        }

        void IAccessBus.Dispatch(INotification notification) => Publish();

        void IEventBus<TEventHandler, ParameterNotification>.Publish(in ParameterNotification notification) => Publish();
        void IEventBus.Publish<TGenericNotification>(in TGenericNotification notification) => Publish();

        public void Publish()
        {
            for (var index = 0; index < m_Handlers.Count; index++)
            {
                m_Handlers[index].Handle();
            }

            for (var index = m_WeakHandlers.Count - 1; index >= 0; index--)
            {
                if (m_WeakHandlers[index].TryGetTarget(out var handler))
                    handler.Handle();
                else
                    m_WeakHandlers.RemoveAt(index);
            }
        }

        void IEventBus<TEventHandler, ParameterNotification>.Clear() => Clear();

        public void Clear()
        {
            m_Handlers.Clear();
            m_WeakHandlers.Clear();
        }
    }


    public class GenericEventBus<TEventHandler, TNotification> : IEventBus, IEventBus<TEventHandler, TNotification>, IWeakEventObserverSubscriable<TEventHandler> where TEventHandler : class, IEventHandler<TNotification> where TNotification : INotification
    {
        private readonly List<TEventHandler> m_Handlers = new List<TEventHandler>();
        private readonly List<WeakReference<TEventHandler>> m_WeakHandlers = new List<WeakReference<TEventHandler>>();

        public void Subscribe(TEventHandler handler)
        {
            m_Handlers.Add(handler);
        }

        void IEventBus.Subscribe(IEventObserver observer)
        {
            if (observer is TEventHandler handler)
                Subscribe(handler);
            else
                throw new InvalidCastException($"Observer is not a {observer.GetType()} type");
        }

        public void SubscribeWeakly(TEventHandler handler)
        {
            m_WeakHandlers.Add(new WeakReference<TEventHandler>(handler));
        }

        bool IEventBus.Unsubscribe(IEventObserver observer)
        {
            if (observer is TEventHandler handler)
            {
                return Unsubscribe(handler);
            }

            return false;
        }

        public bool Unsubscribe(TEventHandler handler)
        {
            if (handler == null)
                return false;
            for (var index = m_Handlers.Count - 1; index >= 0; index--)
            {
                if (m_Handlers[index] == handler)
                {
                    m_Handlers.RemoveAt(index);
                    return true;
                }
            }

            for (var index = m_WeakHandlers.Count - 1; index >= 0; index--)
            {
                var weakTarget = m_WeakHandlers[index];
                if (weakTarget.TryGetTarget(out var targetHandler))
                {
                    if (targetHandler == handler)
                    {
                        m_WeakHandlers.RemoveAt(index);
                        return true;
                    }
                }
                else
                {
                    m_WeakHandlers.RemoveAt(index);
                }
            }

            return false;
        }

        void IAccessBus.Dispatch(INotification notification)
        {
            if (notification is TNotification targetNotification)
                Publish(targetNotification);
            else
                throw new InvalidCastException($"Notification is not a {typeof(TNotification)} type");
        }

        void IEventBus.Publish<TGenericNotification>(in TGenericNotification notification)
        {
            if (notification is TNotification targetNotification)
                Publish(targetNotification);
            else
                throw new InvalidCastException($"Notification is not a {typeof(TNotification)} type");
        }

        void IEventBus.Publish()
        {
            throw new InvalidOperationException();
        }

        public void Publish(in TNotification notification)
        {
            for (var index = 0; index < m_Handlers.Count; index++)
            {
                m_Handlers[index].Handle(in notification);
            }

            for (var index = m_WeakHandlers.Count - 1; index >= 0; index--)
            {
                if (m_WeakHandlers[index].TryGetTarget(out var handler))
                    handler.Handle(in notification);
                else
                    m_WeakHandlers.RemoveAt(index);
            }
        }

        void IEventBus<TEventHandler, TNotification>.Clear() => Clear();

        public void Clear()
        {
            m_Handlers.Clear();
            m_WeakHandlers.Clear();
        }
    }
}