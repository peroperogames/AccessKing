/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月24日
 * Description:  Access bus schedule which allows access buses mapping to custom themes.
 */

using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public interface IAccessSchedule<in TTheme> : IEnumerable<IAccessBus>
    {
        /// <summary>
        /// Get access bus by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        IAccessBus this[TTheme theme] { get; }

        /// <summary>
        /// Get event bus by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <returns>Access bus for the corresponding theme.</returns>
        IAccessBus GetBus(TTheme theme);

        /// <summary>
        /// Try get access bus by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <param name="bus">Access bus for the corresponding theme.</param>
        /// <returns>Contains any theme to access bus mapping.</returns>
        bool TryGetBus(TTheme theme, out IAccessBus bus);

        /// <summary>
        /// Add a theme to access bus mapping.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <param name="bus">Access bus.</param>
        void AddThemeMapping(TTheme theme, IAccessBus bus);

        /// <summary>
        /// Remove the theme and all its access buses.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <returns>Remove succeed.</returns>
        bool RemoveTheme(TTheme theme);
    }
}