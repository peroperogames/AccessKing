/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月23日
 * Description: The bus handler for handling notifications.
 */

namespace PeroTools2.AccessKing
{
    public interface ICommandHandler<TNotification> 
        where TNotification : INotification
    {
        /// <summary>
        /// Handle notification.
        /// </summary>
        /// <param name="notification">Handle parameters</param>
        void Handle(ref TNotification notification);
    }
    
    public interface ICommandHandler : ICommandHandler<Empty> { }

    
    public interface ICommandHandler<TNotification, out TResult> : ICommandHandler<TNotification>, IResultAvailable<TResult> 
        where TNotification : INotification { }
}