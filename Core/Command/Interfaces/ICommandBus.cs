/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/23 16:05:45
 */

namespace PeroTools2.AccessKing;

/// <summary>
/// A pipeline that cross-domain commands executes with special notification.
/// </summary>
/// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
public interface ICommandBus<TNotification> where TNotification : INotification
{
    /// <summary>
    /// Execute all handler's handle method in bus with notification.
    /// </summary>
    /// <param name="notification">Notification of messages with data.</param>
    /// <returns>Command handlers executed result collection.</returns>
    CommandOperation Execute(ref TNotification notification);
}