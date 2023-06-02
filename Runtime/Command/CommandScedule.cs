using System.Collections;
using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public class CommandSchedule<TTheme, TCommandHandlerFactory> : IAccessSchedule<TTheme>, ICommandSchedule<TTheme> where TCommandHandlerFactory : ICommandHandlerFactory, new()
    {
        private readonly Dictionary<TTheme, IAccessBus> m_CommandBusMaps = new Dictionary<TTheme, IAccessBus>();
        private readonly Dictionary<TTheme, TCommandHandlerFactory> m_FactoryMaps = new Dictionary<TTheme, TCommandHandlerFactory>();
        IAccessBus IAccessSchedule<TTheme>.this[TTheme theme] => m_CommandBusMaps[theme];

        bool IAccessSchedule<TTheme>.TryGetBus(TTheme theme, out IAccessBus bus) => m_CommandBusMaps.TryGetValue(theme, out bus);

        void IAccessSchedule<TTheme>.AddBus(TTheme theme, IAccessBus bus)
        {
            if (bus is ICommandHandlerFactoryModifiable factoryModifiable)
                factoryModifiable.SetFactory(RequireHandlerFactory(theme));
            else
                ThrowHelper.ScheduleCommandBusCastFailed();
            if (CommandExtensions.GetNotificationType(bus.GetType()) == null)
                ThrowHelper.ScheduleCommandBusCastFailed();
            m_CommandBusMaps.Add(theme, bus);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<IAccessBus> GetEnumerator() => m_CommandBusMaps.Values.GetEnumerator();

        public void AddFactory(TTheme theme, TCommandHandlerFactory factory) => m_FactoryMaps.Add(theme, factory);

        public TCommandHandlerFactory RequireHandlerFactory(TTheme theme)
        {
            if (!m_FactoryMaps.TryGetValue(theme, out var factory))
            {
                factory = new TCommandHandlerFactory();
                AddFactory(theme, factory);
            }
            return factory;
        }

        public bool RemoveTheme(TTheme theme) => m_CommandBusMaps.Remove(theme);

        public void AddBus<TNotification>(TTheme theme, ISchedulableCommandBus<TNotification> bus) where TNotification : INotification
        {
            bus.SetFactory(RequireHandlerFactory(theme));
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

        public ICommandBus<Empty> Require(TTheme theme)
        {
            if (!TryGetBus<Empty>(theme, out var bus))
            {
                var commandBus = new ParameterCommandBus();
                ((ICommandHandlerFactoryModifiable) commandBus).SetFactory(RequireHandlerFactory(theme));
                AddBus(theme, commandBus);
                bus = commandBus;
            }

            return bus;
        }

        public ICommandBus<ParameterNotification<T>> Require<T>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T>>(theme, out var bus))
            {
                var commandBus = new ParameterCommandBus<T>();
                ((ICommandHandlerFactoryModifiable) commandBus).SetFactory(RequireHandlerFactory(theme));
                AddBus(theme, commandBus);
                bus = commandBus;
            }

            return bus;
        }

        public ICommandBus<ParameterNotification<T1, T2>> Require<T1, T2>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2>>(theme, out var bus))
            {
                var commandBus = new ParameterCommandBus<T1, T2>();
                ((ICommandHandlerFactoryModifiable) commandBus).SetFactory(RequireHandlerFactory(theme));
                AddBus(theme, commandBus);
                bus = commandBus;
            }

            return bus;
        }

        public ICommandBus<ParameterNotification<T1, T2, T3>> Require<T1, T2, T3>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2, T3>>(theme, out var bus))
            {
                var commandBus = new ParameterCommandBus<T1, T2, T3>();
                ((ICommandHandlerFactoryModifiable) commandBus).SetFactory(RequireHandlerFactory(theme));
                AddBus(theme, commandBus);
                bus = commandBus;
            }

            return bus;
        }

        public ICommandBus<ParameterNotification<T1, T2, T3, T4>> Require<T1, T2, T3, T4>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2, T3, T4>>(theme, out var bus))
            {
                var commandBus = new ParameterCommandBus<T1, T2, T3, T4>();
                ((ICommandHandlerFactoryModifiable) commandBus).SetFactory(RequireHandlerFactory(theme));
                AddBus(theme, commandBus);
                bus = commandBus;
            }

            return bus;
        }

        public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5>> Require<T1, T2, T3, T4, T5>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2, T3, T4, T5>>(theme, out var bus))
            {
                var commandBus = new ParameterCommandBus<T1, T2, T3, T4, T5>();
                ((ICommandHandlerFactoryModifiable) commandBus).SetFactory(RequireHandlerFactory(theme));
                AddBus(theme, commandBus);
                bus = commandBus;
            }

            return bus;
        }
    }
}