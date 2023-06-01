using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

namespace PeroTools2.AccessKing
{
    public class CommandSchedule<TTheme> : IAccessSchedule<TTheme>, ICommandSchedule<TTheme>
    {
        private readonly Dictionary<TTheme, CommandScheduleEntry> m_CommandBusMaps = new Dictionary<TTheme, CommandScheduleEntry>();
        private readonly Dictionary<TTheme, ICommandHandlerFactory> m_FactoryMaps = new Dictionary<TTheme, ICommandHandlerFactory>();

        public ICommandBus<TNotification> Require<TNotification>(TTheme theme) where TNotification : INotification
        {
            if (m_CommandBusMaps.TryGetValue(theme, out var entry))
            {
                if (entry.notificationType == typeof(TNotification))
                    return entry.GetBus<TNotification>();
                else
                    ThrowHelper.ThrowWhenNotificationCastFailed<TNotification>(entry.GetType().GenericTypeArguments[0]);
            }

            ThrowHelper.ThrowWhenAccessBusRequireFailed(typeof(ICommandBus<TNotification>));
            return null;
        }

        public ICommandBus<ParameterNotification> RequireWithParams(TTheme theme)
            => Require<ParameterNotification>(theme);

        public ICommandBus<ParameterNotification<T>> RequireWithParams<T>(TTheme theme)
            => Require<ParameterNotification<T>>(theme);

        public ICommandBus<ParameterNotification<T1, T2>> RequireWithParams<T1, T2>(TTheme theme)
            => Require<ParameterNotification<T1, T2>>(theme);

        public ICommandBus<ParameterNotification<T1, T2, T3>> RequireWithParams<T1, T2, T3>(TTheme theme)
            => Require<ParameterNotification<T1, T2, T3>>(theme);

        public ICommandBus<ParameterNotification<T1, T2, T3, T4>> RequireWithParams<T1, T2, T3, T4>(TTheme theme)
            => Require<ParameterNotification<T1, T2, T3, T4>>(theme);

        public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5>> RequireWithParams<T1, T2, T3, T4, T5>(TTheme theme)
            => Require<ParameterNotification<T1, T2, T3, T4, T5>>(theme);

        public void AddFactory(TTheme theme, ICommandHandlerFactory factory) => m_FactoryMaps.Add(theme, factory);

        public void AddBus<TBus>(TTheme theme) where TBus : ICommandBus, IAccessBus
        {
            var busType = typeof(TBus);
            if (!typeof(IAccessBus).IsAssignableFrom(busType) || !typeof(ICommandBus).IsAssignableFrom(busType))
                throw new InvalidCastException();

            if (m_FactoryMaps.TryGetValue(theme, out var factory))
            {
                var ctor = busType.GetConstructor(new[] {typeof(ICommandHandlerFactory)});
                Assert.IsNotNull(ctor, "The CommandBus must have a constructor with ICommandHandlerFactory parameters");

                var bus = (IAccessBus) ctor.Invoke(new object[] {factory});

                if (!m_CommandBusMaps.TryGetValue(theme, out var entry))
                {
                    var notificationType = CommandExtensions.GetNotificationType<TBus>();
                    Assert.IsNotNull(notificationType);
                    entry = new CommandScheduleEntry(notificationType);
                    m_CommandBusMaps.Add(theme, entry);
                }

                entry.Add(bus);
            }
            else
                ThrowHelper.ThrowWhenHandlerFactoryNeverBeenRegistered(theme);
        }

        public IEnumerator<IAccessBus> GetEnumerator()
        {
            return m_CommandBusMaps.Values.SelectMany(entry => entry
                    .GetAllAccessBus()
                    .Select(item => item))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IAccessBus IAccessSchedule<TTheme>.this[TTheme theme] => m_CommandBusMaps[theme].FirstOrDefault();

        bool IAccessSchedule<TTheme>.TryGetBus(TTheme theme, out IAccessBus bus)
        {
            if (m_CommandBusMaps.TryGetValue(theme, out var entry))
            {
                bus = entry.FirstOrDefault();
                return true;
            }

            bus = null;
            return false;
        }

        void IAccessSchedule<TTheme>.AddBus(TTheme theme, IAccessBus bus)
        {
            if (!m_FactoryMaps.TryGetValue(theme, out var factory))
                ThrowHelper.ThrowWhenHandlerFactoryNeverBeenRegistered(theme);
            if (bus is ICommandBus commandBus)
            {
                if (commandBus.handlerFactory != factory)
                    ThrowHelper.ThrowWhenHandlerFactoryRepeat(theme);
            }
            else
                ThrowHelper.ThrowWhenCommandBusCastFailed();

            if (m_CommandBusMaps.TryGetValue(theme, out var entry))
            {
                entry.Add(bus);
            }
        }

        private class CommandScheduleEntry : IEnumerable<IAccessBus>
        {
            public readonly Type notificationType;
            private readonly List<IAccessBus> m_Buses = new List<IAccessBus>();

            public CommandScheduleEntry(Type notificationType)
            {
                Assert.IsTrue(typeof(INotification).IsAssignableFrom(notificationType));
                this.notificationType = notificationType;
            }

            internal void Add(IAccessBus accessBus)
            {
                m_Buses.Add(accessBus);
            }

            internal IEnumerable<IAccessBus> GetAllAccessBus() => m_Buses;

            public ICommandBus<TNotification> GetBus<TNotification>() where TNotification : INotification
            {
                for (var index = 0; index < m_Buses.Count; index++)
                {
                    if (m_Buses[index] is ICommandBus<TNotification> bus)
                    {
                        return bus;
                    }
                }

                return default;
            }

            public IEnumerator<IAccessBus> GetEnumerator() => m_Buses.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private class CommandScheduleEntry<TNotification> : CommandScheduleEntry where TNotification : INotification
        {
            public CommandScheduleEntry() : base(typeof(TNotification))
            {
            }

            public ICommandBus<TNotification> GetBus<TOperation>()
            {
                return base.GetBus<TNotification>();
            }
        }
    }
}