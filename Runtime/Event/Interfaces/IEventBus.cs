/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月26日
 * Description: A pipeline that receives events and cross-domain event broadcasts with special notification.
 */

namespace PeroTools2.AccessKing
{
    public interface IEventBus<TNotification> where TNotification : INotification
    {
        /// <summary>
        /// Remove handler from bus.
        /// </summary>
        /// <param name="handler">The event handler with notification.</param>
        /// <returns>Is removed succeed.</returns>
        bool Unsubscribe(IEventHandler<TNotification> handler);

        /// <summary>
        /// Add event handler to bus.
        /// </summary>
        /// <param name="handler">The event handler with notification.</param>
        void Subscribe(IEventHandler<TNotification> handler);
        
        /// <summary>
        /// Execute all handler's handle method in bus with notification.
        /// </summary>
        /// <param name="notification">Notification of messages with data.</param>
        void Broadcast(in TNotification notification);
        
        /// <summary>
        /// Remove all handlers from bus.
        /// </summary>
        void Clear();
    }
}