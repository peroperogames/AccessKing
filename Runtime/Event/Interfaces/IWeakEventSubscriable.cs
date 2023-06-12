/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月26日
 * Description: Allows the event bus to have the behavior of holding a weak reference to the EventHandler when it is registered.
 */

namespace PeroTools2.AccessKing
{
    public interface IWeakEventSubscriable<TNotification> where TNotification : INotification
    {
        /// <summary>
        /// Subscribe handler by weak reference.
        /// </summary>
        /// <param name="handler">The event handler with notification.</param>
        void SubscribeWeakly(IEventHandler<TNotification> handler);
    }
}