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
    internal sealed class WeakEventHandler<TNotification> : IWeakEventHandler<TNotification>, IWeakEventInvocation where TNotification : INotification
    {
        /// <summary>
        /// Weak reference for the input handler.
        /// </summary>
        private readonly WeakReference<IEventHandler<TNotification>> m_WeakHandler;

        /// <summary>
        /// Is the handler still alive.
        /// </summary>
        public bool isAlive => m_WeakHandler.TryGetReference(out _);

        /// <summary>
        /// <inheritdoc cref="WeakEventHandler{TNotification}"/>
        /// </summary>
        /// <param name="handler">The handler that would be created a weak reference.</param>
        internal WeakEventHandler(IEventHandler<TNotification> handler)
        {
            m_WeakHandler = new WeakReference<IEventHandler<TNotification>>(handler);
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}"/>
        public bool TryHandle(in TNotification notification)
        {
            // Check alive.
            if (!m_WeakHandler.TryGetReference(out var handler)) return false;
            // Alive, then handle it.
            handler.Handle(in notification);
            return true;
        }

        /// <summary>
        /// Compare with the wrapped handler so that a subscription made through this wrapper can be
        /// located again by the handler instance that created it.
        /// </summary>
        public override bool Equals(object obj) => m_WeakHandler.TryGetReference(out var handler) && handler.Equals(obj);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_WeakHandler.TryGetReference(out var handler) ? handler.GetHashCode() : 0;
        /// <summary>
        /// The invocation method of the wrapped handler, used to locate the subscription from its delegate.
        /// </summary>
        System.Reflection.MethodInfo IWeakEventInvocation.invocationMethod
            => m_WeakHandler.TryGetReference(out var handler) && handler is IWeakEventInvocation weak ? weak.invocationMethod : null;

        object IWeakEventInvocation.invocationOwner
            => m_WeakHandler.TryGetReference(out var handler) && handler is IWeakEventInvocation weak ? weak.invocationOwner : null;
    }
}