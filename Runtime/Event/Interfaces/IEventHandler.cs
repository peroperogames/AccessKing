/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/26 15:05:25
 */

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// The event handler for handling notifications.
    /// </summary>
    /// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
    public interface IEventHandler<TNotification> where TNotification : INotification
    {
        /// <summary>
        /// Handle notification.
        /// </summary>
        /// <param name="notification">Notification of messages with data.</param>
        void Handle(in TNotification notification);
    }

    /// <inheritdoc cref="IEventHandler{TNotification}"/>
    public interface IEventHandler : IEventHandler<Empty> { }
}