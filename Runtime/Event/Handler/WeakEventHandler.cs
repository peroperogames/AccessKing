/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/08 17:12:13
 */

using System;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// The handler wrapper that create a weak reference for the input handler.
    /// </summary>
    /// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
    internal sealed class WeakEventHandler<TNotification> : IWeakEventHandler<TNotification> where TNotification : INotification
    {
        /// <summary>
        /// Weak reference for the input handler.
        /// </summary>
        private readonly WeakReference<IEventHandler<TNotification>> m_WeakHandler;

        /// <summary>
        /// Is the handler still alive.
        /// </summary>
        public bool isAlive => m_WeakHandler.TryGetTarget(out _);

        /// <summary>
        /// <inheritdoc cref="WeakEventHandler{TNotification}"/>
        /// </summary>
        /// <param name="handler">The handler that would be created a weak reference.</param>
        internal WeakEventHandler(IEventHandler<TNotification> handler) => m_WeakHandler = new WeakReference<IEventHandler<TNotification>>(handler);

        /// <inheritdoc cref="IWeakEventHandler{TNotification}"/>
        public bool TryHandle(in TNotification notification)
        {
            // Check alive.
            if (!m_WeakHandler.TryGetTarget(out var handler)) return false;
            // Alive, then handle it.
            handler.Handle(in notification);
            return true;
        }
    }
}