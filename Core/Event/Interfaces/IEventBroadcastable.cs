/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/01 15:12:44
 */

namespace PeroTools2.AccessKing;

/// <summary>
/// Defines the behavior of an object that can broadcast events to multiple subscribers.
/// </summary>
/// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
public interface IEventBroadcastable<TNotification> where TNotification : INotification
{
    /// <summary>
    /// Execute all handler's handle method in bus with notification.
    /// </summary>
    /// <param name="notification">Notification of messages with data.</param>
    void Broadcast(in TNotification notification);
}