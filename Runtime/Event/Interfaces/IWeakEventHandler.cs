/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/05 16:12:32
 */

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// The event handler from a weak reference provider for handling notifications.
    /// </summary>
    /// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
    public interface IWeakEventHandler<TNotification> where TNotification : INotification
    {
        bool isAlive { get; }

        /// <summary>
        /// Try handle notification if the event provider still alive.
        /// </summary>
        /// <param name="notification">Notification of messages with data.</param>
        /// <returns>Whether the event provider is alive.</returns>
        bool TryHandle(in TNotification notification);
    }

    /// <inheritdoc cref="IWeakEventHandler{TNotification}"/>
    public interface IWeakEventHandler : IWeakEventHandler<Empty> { }
}