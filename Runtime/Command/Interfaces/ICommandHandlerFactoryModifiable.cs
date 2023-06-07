/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年06月01日
 * Description: Allow the command handler factory to be reset by schedule.
 */

namespace PeroTools2.AccessKing
{
    public interface ICommandHandlerFactoryModifiable
    {
        ICommandHandlerFactory factory { get; set; }
    }
}