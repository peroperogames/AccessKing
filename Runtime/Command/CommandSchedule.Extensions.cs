/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/06 16:12:10
 */

namespace PeroTools2.AccessKing
{
    public partial class CommandSchedule<TTheme>
    {
        /// <summary>
        /// Get or create a command bus with 0 argument type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<Empty> Require(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<Empty>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus();
            AddBus(theme, commandBus);
            return commandBus;
        }

        /// <summary>
        /// Get or create a command bus with 1 argument type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T>> Require<T>(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<ParameterNotification<T>>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus<T>();
            AddBus(theme, commandBus);
            return commandBus;
        }

        /// <summary>
        /// Get or create a command bus with 2 arguments type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2>> Require<T1, T2>(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<ParameterNotification<T1, T2>>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus<T1, T2>();
            AddBus(theme, commandBus);
            return commandBus;
        }

        /// <summary>
        /// Get or create a command bus with 3 arguments type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3>> Require<T1, T2, T3>(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<ParameterNotification<T1, T2, T3>>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus<T1, T2, T3>();
            AddBus(theme, commandBus);
            return commandBus;
        }

        /// <summary>
        /// Get or create a command bus with 4 arguments type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3, T4>> Require<T1, T2, T3, T4>(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<ParameterNotification<T1, T2, T3, T4>>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus<T1, T2, T3, T4>();
            AddBus(theme, commandBus);
            return commandBus;
        }

        /// <summary>
        /// Get or create a command bus with 5 arguments type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5>> Require<T1, T2, T3, T4, T5>(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<ParameterNotification<T1, T2, T3, T4, T5>>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus<T1, T2, T3, T4, T5>();
            AddBus(theme, commandBus);
            return commandBus;
        }

        /// <summary>
        /// Get or create a command bus with 6 arguments type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6>> Require<T1, T2, T3, T4, T5, T6>(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<ParameterNotification<T1, T2, T3, T4, T5, T6>>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus<T1, T2, T3, T4, T5, T6>();
            AddBus(theme, commandBus);
            return commandBus;
        }

        /// <summary>
        /// Get or create a command bus with 7 arguments type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7>> Require<T1, T2, T3, T4, T5, T6, T7>(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7>>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus<T1, T2, T3, T4, T5, T6, T7>();
            AddBus(theme, commandBus);
            return commandBus;
        }

        /// <summary>
        /// Get or create a command bus with 8 arguments type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>> Require<T1, T2, T3, T4, T5, T6, T7, T8>(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus<T1, T2, T3, T4, T5, T6, T7, T8>();
            AddBus(theme, commandBus);
            return commandBus;
        }

        /// <summary>
        /// Get or create a command bus with 9 arguments type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9>> Require<T1, T2, T3, T4, T5, T6, T7, T8, T9>(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus<T1, T2, T3, T4, T5, T6, T7, T8, T9>();
            AddBus(theme, commandBus);
            return commandBus;
        }

        /// <summary>
        /// Get or create a command bus with 10 arguments type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> Require<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>();
            AddBus(theme, commandBus);
            return commandBus;
        }

        /// <summary>
        /// Get or create a command bus with 11 arguments type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> Require<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>();
            AddBus(theme, commandBus);
            return commandBus;
        }

        /// <summary>
        /// Get or create a command bus with 12 arguments type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> Require<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>();
            AddBus(theme, commandBus);
            return commandBus;
        }

        /// <summary>
        /// Get or create a command bus with 13 arguments type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> Require<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>();
            AddBus(theme, commandBus);
            return commandBus;
        }

        /// <summary>
        /// Get or create a command bus with 14 arguments type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> Require<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>();
            AddBus(theme, commandBus);
            return commandBus;
        }

        /// <summary>
        /// Get or create a command bus with 15 arguments type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> Require<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>();
            AddBus(theme, commandBus);
            return commandBus;
        }

        /// <summary>
        /// Get or create a command bus with 16 arguments type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme of command bus.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> Require<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(TTheme theme)
        {
            // Get bus from cache.
            if (TryGetBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(theme, out var bus)) return bus;

            // Build a new ParameterCommandBus.
            var commandBus = new ParameterCommandBus<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>();
            AddBus(theme, commandBus);
            return commandBus;
        }
    }
}