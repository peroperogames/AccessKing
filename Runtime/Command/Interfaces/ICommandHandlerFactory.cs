/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月23日
 * Description: Command handler collections.
 */
using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public interface ICommandHandlerFactory
    {
        /// <summary>
        /// Require a command handler instance from factory.
        /// </summary>
        /// <typeparam name="TNotification"></typeparam>
        /// <returns></returns>
        IReadOnlyList<ICommandHandler<TNotification>> RequireHandlers<TNotification>() where TNotification : INotification;
    }
}