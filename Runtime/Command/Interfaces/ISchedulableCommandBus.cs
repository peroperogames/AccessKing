/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年06月01日
 * Description: The command bus allows additions to the command schedule.
 */
namespace PeroTools2.AccessKing
{
    public interface ISchedulableCommandBus<TNotification> : IAccessBus, ICommandBus<TNotification>, ICommandHandlerFactoryModifiable where TNotification : INotification { }
}