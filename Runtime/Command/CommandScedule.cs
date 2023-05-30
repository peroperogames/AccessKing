using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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
                return entry.GetBus<TNotification, TOperation>();
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
                    entry = new CommandScheduleEntry();
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

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
    }
}