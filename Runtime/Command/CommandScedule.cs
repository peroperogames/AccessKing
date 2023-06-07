/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月29日
 * Description: Default command schedule implementation.
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PeroTools2.AccessKing
{
    public class CommandSchedule<TTheme, TCommandHandlerFactory> : IAccessSchedule<TTheme>, ICommandSchedule<TTheme> where TCommandHandlerFactory : ICommandHandlerFactory, new()
    {
        private readonly Dictionary<TTheme, IAccessBus> m_CommandBusMaps = new Dictionary<TTheme, IAccessBus>();
        private readonly Dictionary<TTheme, TCommandHandlerFactory> m_FactoryMaps = new Dictionary<TTheme, TCommandHandlerFactory>();
        IAccessBus IAccessSchedule<TTheme>.this[TTheme theme] => m_CommandBusMaps[theme];

        IAccessBus IAccessSchedule<TTheme>.GetBus(TTheme theme) => m_CommandBusMaps[theme];

        bool IAccessSchedule<TTheme>.TryGetBus(TTheme theme, out IAccessBus bus) => m_CommandBusMaps.TryGetValue(theme, out bus);

        void IAccessSchedule<TTheme>.AddThemeMapping(TTheme theme, IAccessBus bus)
        {
            if (bus is ICommandHandlerFactoryModifiable factoryModifiable)
            {
                if (!m_FactoryMaps.ContainsKey(theme))
                    factoryModifiable.factory = RequireFactory(theme);
                else if(factoryModifiable.factory is TCommandHandlerFactory factory)
                    m_FactoryMaps[theme] = factory;
                else
                    ThrowHelper.FactoryCastFailed<TCommandHandlerFactory>();
            }
            else
                ThrowHelper.ScheduleCommandBusCastFailed();
            if (typeof(ISchedulableCommandBus<>).IsInstanceOfType(bus))
                ThrowHelper.ScheduleCommandBusCastFailed();
            m_CommandBusMaps.Add(theme, bus);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<IAccessBus> GetEnumerator() => m_CommandBusMaps.Values.GetEnumerator();
        
        /// <summary>
        /// Add a command handler factory by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <param name="factory">Command handler factory.</param>
        public void AddFactory(TTheme theme, TCommandHandlerFactory factory) => m_FactoryMaps.Add(theme, factory);

        /// <summary>
        /// Set factory by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <param name="factory">Command handler factory.</param>
        public void SetFactory(TTheme theme, TCommandHandlerFactory factory)
        {
            m_FactoryMaps[theme] = factory;  
            ((ICommandHandlerFactoryModifiable)m_CommandBusMaps[theme]).factory =factory;
        } 
        
        /// <summary>
        /// Get or create a command handler factory by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <returns>Command handler factory.</returns>
        public TCommandHandlerFactory RequireFactory(TTheme theme)
        {
            if (!m_FactoryMaps.TryGetValue(theme, out var factory))
            {
                factory = new TCommandHandlerFactory();
                AddFactory(theme, factory);
            }

            return factory;
        }

        public bool RemoveTheme(TTheme theme) => m_CommandBusMaps.Remove(theme);

        public bool RemoveBus(IAccessBus accessBus)
        {
            var pair = m_CommandBusMaps.FirstOrDefault(kv => kv.Value.Equals(accessBus));
            return pair.Key != null && m_CommandBusMaps.Remove(pair.Key);
        }
        
        public bool ContainsBus(TTheme theme) => m_CommandBusMaps.ContainsKey(theme);

        public void ClearTheme() => m_CommandBusMaps.Clear();

        public void AddThemeMapping<TNotification>(TTheme theme, ISchedulableCommandBus<TNotification> bus) where TNotification : INotification
        {
            if (!m_FactoryMaps.ContainsKey(theme))
                bus.factory = RequireFactory(theme);
            else if(bus.factory is TCommandHandlerFactory factory)
                m_FactoryMaps[theme] = factory;
            else
                ThrowHelper.FactoryCastFailed<TCommandHandlerFactory>();
            m_CommandBusMaps.Add(theme, bus);
        }


        public bool TryGetBus<TNotification>(TTheme theme, out ICommandBus<TNotification> bus) where TNotification : INotification
        {
            if (m_CommandBusMaps.TryGetValue(theme, out var accessBus))
            {
                if (accessBus is ICommandBus<TNotification> commandBus)
                {
                    bus = commandBus;
                    return true;
                }
            }

            bus = null;
            return false;
        }

        public ICommandBus<TNotification> GetBus<TNotification>(TTheme theme) where TNotification : INotification
        {
            if (m_CommandBusMaps.TryGetValue(theme, out var bus))
            {
                if (bus is ICommandBus<TNotification> commandBus)
                    return commandBus;
            }

            ThrowHelper.AccessBusRequireFailed(typeof(ICommandBus<TNotification>));
            return null;
        }

        /// <summary>
        /// Get or create a command bus with 0 argument type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<Empty> Require(TTheme theme)
        {
            if (!TryGetBus<Empty>(theme, out var bus))
            {
                var commandBus = new ParameterCommandBus();
                AddThemeMapping(theme, commandBus);
                bus = commandBus;
            }

            return bus;
        }

        /// <summary>
        /// Get or create a command bus with 1 argument type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T>> Require<T>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T>>(theme, out var bus))
            {
                var commandBus = new ParameterCommandBus<T>();
                AddThemeMapping(theme, commandBus);
                bus = commandBus;
            }

            return bus;
        }

        /// <summary>
        /// Get or create a command bus with 2 argument types parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2>> Require<T1, T2>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2>>(theme, out var bus))
            {
                var commandBus = new ParameterCommandBus<T1, T2>();
                AddThemeMapping(theme, commandBus);
                bus = commandBus;
            }

            return bus;
        }

        /// <summary>
        /// Get or create a command bus with 3 argument types parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3>> Require<T1, T2, T3>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2, T3>>(theme, out var bus))
            {
                var commandBus = new ParameterCommandBus<T1, T2, T3>();
                AddThemeMapping(theme, commandBus);
                bus = commandBus;
            }

            return bus;
        }

        /// <summary>
        /// Get or create a command bus with 4 argument types parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3, T4>> Require<T1, T2, T3, T4>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2, T3, T4>>(theme, out var bus))
            {
                var commandBus = new ParameterCommandBus<T1, T2, T3, T4>();
                AddThemeMapping(theme, commandBus);
                bus = commandBus;
            }

            return bus;
        }

        /// <summary>
        /// Get or create a command bus with 5 argument types parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <returns>Command bus for the corresponding theme.</returns>
        public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5>> Require<T1, T2, T3, T4, T5>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2, T3, T4, T5>>(theme, out var bus))
            {
                var commandBus = new ParameterCommandBus<T1, T2, T3, T4, T5>();
                AddThemeMapping(theme, commandBus);
                bus = commandBus;
            }

            return bus;
        }
    }
}