/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/26 15:05:25
 */

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Allows the event bus to have the behavior of holding a weak reference to the EventHandler when it is registered.
    /// </summary>
    /// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
    public interface IWeakEventSubscriable<TNotification> where TNotification : INotification
    {
        /// <summary>
        /// Subscribe handler by weak reference.
        /// </summary>
        /// <param name="handler">The event handler with notification.</param>
        void SubscribeWeakly(IWeakEventHandler<TNotification> handler);

        /// <summary>
        /// Remove handler from bus.
        /// </summary>
        /// <param name="handler">The event handler with notification.</param>
        /// <returns>Is removed succeed.</returns>
        bool Unsubscribe(IEventHandler<TNotification> handler);

        /// <summary>
        /// Remove all handlers from bus.
        /// </summary>
        void Clear();
    }
}