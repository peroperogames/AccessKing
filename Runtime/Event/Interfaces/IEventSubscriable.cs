/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/01 15:12:21
 */

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Defines the contract for objects that can subscribe to events.
    /// </summary>
    /// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
    public interface IEventSubscriable<TNotification> where TNotification : INotification
    {
        /// <summary>
        /// Add event handler to bus.
        /// </summary>
        /// <param name="handler">The event handler with notification.</param>
        void Subscribe(IEventHandler<TNotification> handler);

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