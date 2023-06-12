/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月29日
 * Description: Command bus schedule which allows command buses mapping to custom themes.
 */

namespace PeroTools2.AccessKing
{
    public interface ICommandSchedule<in TTheme>
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
        void AddThemeMapping<TNotification>(TTheme theme, ISchedulableCommandBus<TNotification> bus) where TNotification : INotification;
    }
}