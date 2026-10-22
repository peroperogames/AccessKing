/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/23
 * Description: The bus handler for handling notifications.
 */

namespace PeroTools2.AccessKing;

/// <summary>
/// The bus handler for handling notifications.
/// </summary>
/// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
public interface ICommandHandler<TNotification> where TNotification : INotification
{
    /// <summary>
    /// Handle notification.
    /// </summary>
    /// <param name="notification">Notification of messages with data.</param>
    void Handle(ref TNotification notification);
}

/// <inheritdoc cref="IEventHandler{TNotification}"/>
public interface ICommandHandler : ICommandHandler<Empty>;

/// <summary>
/// Command handler with result.
/// </summary>
/// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
/// <typeparam name="TResult">Result of handling.</typeparam>
public interface ICommandHandler<TNotification, out TResult> : ICommandHandler<TNotification>, IResultAvailable<TResult> where TNotification : INotification;