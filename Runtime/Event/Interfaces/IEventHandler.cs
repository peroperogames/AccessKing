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

    /// <summary>
    /// Exposes the invocation method of a strongly typed event handler, so that a weak subscription
    /// can be located again from the handler (or delegate) that created it.
    /// </summary>
    internal interface IEventInvocation
    {
        /// <summary>
        /// The method that the handler invokes.
        /// </summary>
        System.Reflection.MethodInfo invocationMethod { get; }
        /// <summary>
        /// The owner that controls the lifetime of the handler, or null when it was already collected.
        /// It is the target of the delegate for a strongly typed handler.
        /// </summary>
        object invocationOwner { get; }
    }
}