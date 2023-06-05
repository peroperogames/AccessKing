/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月26日
 * Description: Event bus schedule which allows event buses mapping to custom themes.
 */

namespace PeroTools2.AccessKing
{
    public interface IEventSchedule<in TTheme>
    {
        /// <summary>
        /// Get event bus by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <typeparam name="TNotification">Notification type.</typeparam>
        /// <returns>Event bus for the corresponding theme.</returns>
        IEventBus<TNotification> GetBus<TNotification>(TTheme theme) where TNotification : INotification;

        /// <summary>
        /// Try get event bus by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <param name="bus">Event bus for the corresponding theme.</param>
        /// <typeparam name="TNotification">Notification type.</typeparam>
        /// <returns>Contains any theme to event bus mapping.</returns>
        bool TryGetBus<TNotification>(TTheme theme, out IEventBus<TNotification> bus) where TNotification : INotification;

        /// <summary>
        /// Add a theme to event bus mapping.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <param name="bus">Event bus.</param>
        /// <typeparam name="TNotification">Notification type.</typeparam>
        void AddThemeMapping<TNotification>(TTheme theme, ISchedulableEventBus<TNotification> bus) where TNotification : INotification;
    }
}