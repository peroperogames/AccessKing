/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/26 15:05:25
 */

namespace PeroTools2.AccessKing
{
    /// <summary>
    ///  A mediator that transfers a message from a sender to a receiver.
    /// </summary>
    /// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
    public interface IEventBus<TNotification> : IEventSubscriable<TNotification>, IEventBroadcastable<TNotification>, IWeakEventSubscriable<TNotification> where TNotification : INotification { }
}