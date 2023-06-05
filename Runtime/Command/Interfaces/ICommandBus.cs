/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月23日
 * Description: A pipeline that cross-domain commands executes with special notification.
 */

namespace PeroTools2.AccessKing
{
    public interface ICommandBus<TNotification>
        where TNotification : INotification
    {
        /// <summary>
        /// Execute all handler's handle method in bus with notification.
        /// </summary>
        /// <param name="notification">Notification of messages with data.</param>
        /// <returns>Command handlers executed result collection.</returns>
        CommandOperation Execute(ref TNotification notification);
    }
}