/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月26日
 * Description: The event handler for handling notifications.
 */

namespace PeroTools2.AccessKing
{
    
    public interface IEventHandler<TNotification> where TNotification : INotification
    {
        /// <summary>
        /// Handle notification.
        /// </summary>
        /// <param name="notification">Notification of messages with data.</param>
        void Handle(in TNotification notification);
    }
    
    public interface IEventHandler : IEventHandler<Empty> { }
}