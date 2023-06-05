/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月26日
 * Description: Default event bus implementation.
 */
 
using System;
using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public class EventBus<TNotification> : ISchedulableEventBus<TNotification>, IWeakEventSubscriable<TNotification> where TNotification : INotification
    {
        private readonly List<IEventHandler<TNotification>> m_Handlers = new List<IEventHandler<TNotification>>();
        private readonly List<WeakReference<IEventHandler<TNotification>>> m_WeakHandlers = new List<WeakReference<IEventHandler<TNotification>>>();

        void IAccessBus.Dispatch(INotification notification)
        {
            if (notification is TNotification tNotification)
                Broadcast(tNotification);
            else
                ThrowHelper.NotificationCastFailed<TNotification>(notification);
        }

        public void Clear()
        {
            m_Handlers.Clear();
            m_WeakHandlers.Clear();
        }

        public bool Unsubscribe(IEventHandler<TNotification> handler)
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

        public void Subscribe(IEventHandler<TNotification> handler) => m_Handlers.Add(handler);

        public void SubscribeWeakly(IEventHandler<TNotification> handler) => m_WeakHandlers.Add(new WeakReference<IEventHandler<TNotification>>(handler));

        public void Broadcast(in TNotification notification)
        {
            for (var index = 0; index < m_Handlers.Count; index++)
            {
                m_Handlers[index].Handle(notification);
            }

            for (var index = m_WeakHandlers.Count - 1; index >= 0; index--)
            {
                if (m_WeakHandlers[index].TryGetTarget(out var handler))
                    handler.Handle(notification);
                else
                    m_WeakHandlers.RemoveAt(index);
            }
        }
    }
}