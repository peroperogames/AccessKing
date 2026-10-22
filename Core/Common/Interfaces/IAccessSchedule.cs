/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/06 18:12:09
 */

namespace PeroTools2.AccessKing;

/// <summary>
/// The access bus locator which allows access buses mapping to custom themes.
/// </summary>
/// <typeparam name="TTheme">Access bus's only id in the schedule.</typeparam>
public interface IAccessSchedule<in TTheme>
{
    /// <summary>
    /// Count of the access buses registered in the schedule.
    /// </summary>
    int busCount { get; }

    /// <summary>
    /// Remove the theme and all its access buses.
    /// </summary>
    /// <param name="theme">Theme of the bus that need to be removed.</param>
    /// <returns>Remove succeed.</returns>
    bool RemoveBus(TTheme theme);

    /// <summary>
    /// Remove the theme and all its access buses.
    /// </summary>
    /// <param name="bus">The bus that need to be removed.</param>
    /// <returns>Remove succeed.</returns>
    bool RemoveBus(object bus);

    /// <summary>
    /// Check if the bus is contained in the schedule.
    /// </summary>
    /// <param name="theme">Theme.</param>
    /// <returns>The bus is contained in schedule.</returns>
    bool ContainsBus(TTheme theme);

    /// <summary>
    /// Clear all themes and its buses in the schedule.
    /// </summary>
    void Clear();

    /// <summary>
    /// Get access bus by theme.
    /// </summary>
    /// <param name="theme">Theme.</param>
    /// <returns>Command bus for the corresponding theme.</returns>
    object GetBus(TTheme theme);

    /// <summary>
    /// Try get event bus by theme.
    /// </summary>
    /// <param name="theme">Theme.</param>
    /// <param name="bus">Bus for the corresponding theme.</param>
    /// <returns>Contains any theme to event bus mapping.</returns>
    bool TryGetBus(TTheme theme, out object bus);

    /// <summary>
    /// Add a theme to bus mapping.
    /// </summary>
    /// <param name="theme">Theme.</param>
    /// <param name="bus">Access bus.</param>
    void AddBus(TTheme theme, object bus);
}