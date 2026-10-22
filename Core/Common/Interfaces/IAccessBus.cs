/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/23
 * Description: Service bus used to distribute notifications crossing domain.
 */

namespace PeroTools2.AccessKing;

/// <summary>
/// Service bus used to distribute notifications crossing domain.
/// </summary>
public interface IAccessBus
{
    /// <summary>
    /// Dispatch notification to handlers.
    /// </summary>
    /// <param name="notification">Notification of messages with data.</param>
    /// <returns>The message result.</returns>
    object Dispatch(INotification notification);
}