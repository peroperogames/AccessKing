/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年06月01日
 * Description: The event bus allows additions to the event schedule.
 */
namespace PeroTools2.AccessKing
{
    public interface ISchedulableEventBus<TNotification> : IEventBus<TNotification>, IAccessBus where TNotification : INotification { }
}