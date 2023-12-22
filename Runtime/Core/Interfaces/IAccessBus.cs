/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月23日
 * Description: Service bus used to distribute notifications crossing domain.
 */

namespace PeroTools2.AccessKing
{
    public interface IAccessBus
    {
        /// <summary>
        /// Dispatch notification to handlers.
        /// </summary>
        /// <param name="notification">Notification of messages with data.</param>
        /// <returns>The message result.</returns>
        object Dispatch(INotification notification);
    }
}