/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/26 15:05:53
 */

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// The event bus locator which allows event buses mapping to custom themes.
    /// </summary>
    /// <typeparam name="TTheme">Event bus's only id in the schedule.</typeparam>
    public interface IEventSchedule<in TTheme> : IAccessSchedule<TTheme>
    {
        /// <summary>
        /// Get event bus by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
        /// <returns>Event bus for the corresponding theme.</returns>
        IEventBus<TNotification> GetBus<TNotification>(TTheme theme) where TNotification : INotification;

        /// <summary>
        /// Try get event bus by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <param name="bus">Event bus for the corresponding theme.</param>
        /// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
        /// <returns>Contains any theme to event bus mapping.</returns>
        bool TryGetBus<TNotification>(TTheme theme, out IEventBus<TNotification> bus) where TNotification : INotification;

        /// <summary>
        /// Add a theme to event bus mapping.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <param name="bus">Event bus.</param>
        /// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
        void AddBus<TNotification>(TTheme theme, IEventBus<TNotification> bus) where TNotification : INotification;

        /// <summary>
        /// Remove bus from schedule.
        /// </summary>
        /// <param name="bus">Event bus.</param>
        /// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
        /// <returns>Is remove successfully.</returns>
        bool RemoveBus<TNotification>(IEventBus<TNotification> bus) where TNotification : INotification;
    }
}