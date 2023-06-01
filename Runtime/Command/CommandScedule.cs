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

        public ICommandBus<TNotification, TOperation> Require<TNotification, TOperation>(TTheme theme) where TNotification : INotification where TOperation : ICommandOperation
        {
            if (m_CommandBusMaps.TryGetValue(theme, out var entry))
            {
                if (entry.notificationType == typeof(TNotification))
                    return entry.GetBus<TNotification,TOperation>();
                else
                    ThrowHelper.ThrowWhenNotificationCastFailed<TNotification>(entry.GetType().GenericTypeArguments[0]);
            }

            ThrowHelper.ThrowWhenAccessBusRequireFailed(typeof(ICommandBus<TNotification, TOperation>));
            return null;
        }

        public ICommandBus<ParameterNotification, TOperation> RequireWithParams<TOperation>(TTheme theme) where TOperation : ICommandOperation
            => Require<ParameterNotification, TOperation>(theme);

        public ICommandBus<ParameterNotification<T>, TOperation> RequireWithParams<T, TOperation>(TTheme theme) where TOperation : ICommandOperation
            => Require<ParameterNotification<T>, TOperation>(theme);

        public ICommandBus<ParameterNotification<T1, T2>, TOperation> RequireWithParams<T1, T2, TOperation>(TTheme theme) where TOperation : ICommandOperation
            => Require<ParameterNotification<T1, T2>, TOperation>(theme);

        public ICommandBus<ParameterNotification<T1, T2, T3>, TOperation> RequireWithParams<T1, T2, T3, TOperation>(TTheme theme) where TOperation : ICommandOperation
            => Require<ParameterNotification<T1, T2, T3>, TOperation>(theme);

        public ICommandBus<ParameterNotification<T1, T2, T3, T4>, TOperation> RequireWithParams<T1, T2, T3, T4, TOperation>(TTheme theme) where TOperation : ICommandOperation
            => Require<ParameterNotification<T1, T2, T3, T4>, TOperation>(theme);

        public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5>, TOperation> RequireWithParams<T1, T2, T3, T4, T5, TOperation>(TTheme theme) where TOperation : ICommandOperation
            => Require<ParameterNotification<T1, T2, T3, T4, T5>, TOperation>(theme);

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

            public ICommandBus<TNotification, TOperation> GetBus<TNotification, TOperation>() where TNotification : INotification where TOperation : ICommandOperation
            {
                for (var index = 0; index < m_Buses.Count; index++)
                {
                    if (m_Buses[index] is ICommandBus<TNotification, TOperation> bus)
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
            public CommandScheduleEntry() : base(typeof(TNotification)) { }
            public ICommandBus<TNotification, TOperation> GetBus<TOperation>() where TOperation : ICommandOperation
            {
                return base.GetBus<TNotification, TOperation>();
            }
        }

    }
}