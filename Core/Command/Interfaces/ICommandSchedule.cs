/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/29 17:05:52
 */

namespace PeroTools2.AccessKing;

/// <summary>
/// The command bus locator which allows command buses mapping to custom themes.
/// </summary>
/// <typeparam name="TTheme">Command bus's only id in the schedule.</typeparam>
public interface ICommandSchedule<in TTheme> : IAccessSchedule<TTheme>
{
    /// <summary>
    /// Get command bus by theme.
    /// </summary>
    /// <param name="theme">Theme.</param>
    /// <typeparam name="TNotification">Notification type.</typeparam>
    /// <returns>Command bus for the corresponding theme.</returns>
    ICommandBus<TNotification> GetBus<TNotification>(TTheme theme) where TNotification : INotification;

    /// <summary>
    /// Try get command bus by theme.
    /// </summary>
    /// <param name="theme">Theme.</param>
    /// <param name="bus">Command bus for the corresponding theme.</param>
    /// <typeparam name="TNotification">Notification type.</typeparam>
    /// <returns>Contains any theme to command bus mapping.</returns>
    bool TryGetBus<TNotification>(TTheme theme, out ICommandBus<TNotification> bus) where TNotification : INotification;

    /// <summary>
    /// Add a theme to command bus mapping.
    /// </summary>
    /// <param name="theme">Theme.</param>
    /// <param name="bus">Command bus.</param>
    /// <typeparam name="TNotification">Notification type.</typeparam>
    void AddBus<TNotification>(TTheme theme, ICommandBus<TNotification> bus) where TNotification : INotification;

    /// <summary>
    /// Remove bus from schedule.
    /// </summary>
    /// <param name="bus">Command bus for the corresponding theme.</param>
    /// <typeparam name="TNotification">Notification type.</typeparam>
    /// <returns>Removed succeed.</returns>
    bool RemoveBus<TNotification>(ICommandBus<TNotification> bus) where TNotification : INotification;
}