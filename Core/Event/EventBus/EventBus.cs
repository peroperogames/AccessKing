/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/26 15:05:25
 */

using System;
using System.Collections.Generic;

namespace PeroTools2.AccessKing;

/// <inheritdoc cref="IEventBus{TNotification}"/>
public class EventBus<TNotification> : IEventBus<TNotification>, IAccessBus where TNotification : INotification
{
    /// <summary>
    /// Handler collections.
    /// </summary>
    private readonly List<IEventHandler<TNotification>> m_Handlers = [];

    /// <summary>
    /// Weak handler collections.
    /// </summary>
    private readonly List<IWeakEventHandler<TNotification>> m_WeakHandlers = [];

    /// <inheritdoc cref="IAccessBus.Dispatch(INotification)"/>
    /// <exception cref="InvalidCastException">Throw when the notification cannot match to the generic type.</exception>
    object IAccessBus.Dispatch(INotification notification)
    {
        if (notification is not TNotification tNotification)
        {
            throw new InvalidCastException($"{notification.GetType()} is not a {typeof(TNotification)} type. ");
        }

        Broadcast(tNotification);
        return null;
    }

    /// <inheritdoc cref="IEventSubscriable{TNotification}.Clear()"/>
    public void Clear()
    {
        m_Handlers.Clear();
        m_WeakHandlers.Clear();
    }

    /// <inheritdoc cref="IEventSubscriable{TNotification}.Unsubscribe(IEventHandler{TNotification})"/>
    public bool Unsubscribe(IEventHandler<TNotification> handler)
    {
        if (handler is null) return false;

        // Dispatch all normal handlers.
        for (var index = m_Handlers.Count - 1; index >= 0; index--)
        {
            if (!m_Handlers[index].Equals(handler)) continue;
            m_Handlers.RemoveAt(index);
            return true;
        }

        // Dispatch all weak handlers, the dead references are dropped on the way.
        for (var index = m_WeakHandlers.Count - 1; index >= 0; index--)
        {
            var weakTarget = m_WeakHandlers[index];
            var isAlive = weakTarget.isAlive;
            if (isAlive && !weakTarget.Equals(handler)) continue;

            m_WeakHandlers.RemoveAt(index);
            if (isAlive) return true;
        }

        return false;
    }

    /// <inheritdoc cref="IEventSubscriable{TNotification}.Subscribe(IEventHandler{TNotification})"/>
    /// <exception cref="ArgumentNullException">Throw when the handler is null.</exception>
    public void Subscribe(IEventHandler<TNotification> handler)
    {
        if (handler is null) throw new ArgumentNullException(nameof(handler));
        m_Handlers.Add(handler);
    }

    /// <inheritdoc cref="IWeakEventSubscriable{TNotification}.SubscribeWeakly(IWeakEventHandler{TNotification})"/>
    /// <exception cref="ArgumentNullException">Throw when the handler is null.</exception>
    void IWeakEventSubscriable<TNotification>.SubscribeWeakly(IWeakEventHandler<TNotification> handler)
    {
        if (handler is null) throw new ArgumentNullException(nameof(handler));
        m_WeakHandlers.Add(handler);
    }

    /// <inheritdoc cref="IEventBroadcastable{TNotification}.Broadcast"/>
    public void Broadcast(in TNotification notification)
    {
        // Dispatch all normal handlers.
        foreach (var handler in m_Handlers)
        {
            handler.Handle(notification);
        }

        // Dispatch all weak handlers.
        foreach (var handler in m_WeakHandlers)
        {
            handler.TryHandle(notification);
        }

        // Clear all dead weak handlers.
        m_WeakHandlers.RemoveAll(static handler => !handler.isAlive);
    }
}
