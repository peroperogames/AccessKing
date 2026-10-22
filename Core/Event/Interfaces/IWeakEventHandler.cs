/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/05 16:12:32
 */

namespace PeroTools2.AccessKing;

/// <summary>
/// The event handler from a weak reference provider for handling notifications.
/// </summary>
/// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
public interface IWeakEventHandler<TNotification> where TNotification : INotification
{
    /// <summary>
    /// Whether the event provider is still alive.
    /// </summary>
    bool isAlive { get; }

    /// <summary>
    /// Try handle notification if the event provider still alive.
    /// </summary>
    /// <param name="notification">Notification of messages with data.</param>
    /// <returns>Whether the event provider is alive.</returns>
    bool TryHandle(in TNotification notification);
}

/// <inheritdoc cref="IWeakEventHandler{TNotification}"/>
public interface IWeakEventHandler : IWeakEventHandler<Empty>;

/// <summary>
/// Exposes the invocation method of a weakly referenced handler, so that a weak subscription can be
/// located again from the delegate that created it, without widening the equality of the handler.
/// </summary>
internal interface IWeakEventInvocation
{
    /// <summary>
    /// The method that the weak handler invokes.
    /// </summary>
    System.Reflection.MethodInfo invocationMethod { get; }

    /// <summary>
    /// The owner that controls the lifetime of the handler, or null when it was already collected.
    /// It is the target of the delegate for a strongly typed handler.
    /// </summary>
    object invocationOwner { get; }
}