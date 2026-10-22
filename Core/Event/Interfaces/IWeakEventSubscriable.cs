/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/26 15:05:25
 */

namespace PeroTools2.AccessKing;

/// <summary>
/// Allows the event bus to have the behavior of holding a weak reference to the EventHandler when it is registered.
/// </summary>
/// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
/// <remarks>
/// The unsubscription and the clearing members are inherited from <see cref="IEventSubscriable{TNotification}"/> instead of
/// being declared again: <see cref="IEventBus{TNotification}"/> derives from both interfaces, and two separate declarations
/// of the same member would make every call through the bus interface ambiguous.
/// </remarks>
public interface IWeakEventSubscriable<TNotification> : IEventSubscriable<TNotification> where TNotification : INotification
{
    /// <summary>
    /// Subscribe handler by weak reference.
    /// </summary>
    /// <param name="handler">The event handler with notification.</param>
    void SubscribeWeakly(IWeakEventHandler<TNotification> handler);
}