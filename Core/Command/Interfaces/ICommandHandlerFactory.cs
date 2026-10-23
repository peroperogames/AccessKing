/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/23 16:05:00
 */

using System.Collections.Generic;

namespace PeroTools2.AccessKing;

/// <summary>
/// A central point for creating command handler instances based on the type of notification being executed.
/// </summary>
public interface ICommandHandlerFactory
{
    /// <summary>
    /// Get all command handlers which could handle the <c>TNotification</c> from factory.
    /// </summary>
    /// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
    /// <returns>Command handler about the <c>TNotification</c> collections.</returns>
    IEnumerable<ICommandHandler<TNotification>> GetHandlers<TNotification>() where TNotification : INotification;

    /// <summary>
    /// Get all command handlers which could handle the <c>TNotification</c> from factory.
    /// </summary>
    /// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
    /// <returns>Command handler about the <c>TNotification</c> collections.</returns>
    void GetHandlers<TNotification>(IList<ICommandHandler<TNotification>> collection) where TNotification : INotification;
}