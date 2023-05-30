using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PeroTools2.AccessKing
{
    public class CommandSchedule<TTheme> : IAccessSchedule<TTheme>, ICommandSchedule<TTheme>
    {
        private readonly Dictionary<TTheme, (ICommandHandlerFactory factory, List<IAccessBus> buses)> m_CommandBusMaps = new Dictionary<TTheme, (ICommandHandlerFactory factory, List<IAccessBus> buses)>();

        public IEnumerator<IAccessBus> GetEnumerator()
        {
            var list = new List<IAccessBus>();
            foreach (var item in m_CommandBusMaps.Values)
            {
                list.AddRange(item.buses);
            }

            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IAccessBus IAccessSchedule<TTheme>.this[TTheme theme] => m_CommandBusMaps[theme].buses.FirstOrDefault();

        bool IAccessSchedule<TTheme>.TryGetBus(TTheme theme, out IAccessBus bus)
        {
            bus = ((IAccessSchedule<TTheme>) this)[theme];
            return bus == null;
        }

        void IAccessSchedule<TTheme>.AddBus(TTheme theme, IAccessBus bus)
        {
            if (!typeof(ICommandBus<,>).IsAssignableFrom(bus.GetType()))
                ThrowHelper.ThrowWhenAccessBusCastFailed(typeof(ICommandBus<,>));

            if (!m_CommandBusMaps.TryGetValue(theme, out var busInfo))
                ThrowHelper.ThrowWhenThemeHasBeenRegistered(theme);

            busInfo.buses.Add(bus);
        }

        public void AddFactory(TTheme theme, ICommandHandlerFactory factory)
        {
            if (m_CommandBusMaps.ContainsKey(theme))
            {
                ThrowHelper.ThrowWhenThemeHasBeenRegistered(theme);
                return;
            }

            m_CommandBusMaps.Add(theme, (factory, new List<IAccessBus>()));
        }

        public bool ContainsFactory(TTheme theme) => m_CommandBusMaps.ContainsKey(theme);

        public bool TryGetBus<TNotification, TOperation>(TTheme theme, out ICommandBus<TNotification, TOperation> bus) where TNotification : INotification where TOperation : ICommandOperation
        {
            bus = null;
            if (!m_CommandBusMaps.TryGetValue(theme, out var busInfo))
                return false;
            bus = (ICommandBus<TNotification, TOperation>) busInfo.buses.FirstOrDefault(accessBus => accessBus is ICommandBus<TNotification, TOperation>);
            return bus == null;
        }

        public TBus AddBus<TBus, TNotification, TOperation>(TTheme theme)
            where TBus : CommandBus<TNotification, TOperation>
            where TOperation : ICommandOperation
            where TNotification : INotification
            => Require<TBus, TNotification, TOperation>(theme);

        public TBus Require<TBus, TNotification, TOperation>(TTheme theme)
            where TBus : ICommandBus<TNotification, TOperation>
            where TOperation : ICommandOperation
            where TNotification : INotification
        {
            TBus bus = default;
            if (m_CommandBusMaps.TryGetValue(theme, out var busInfo))
            {
                bus = (TBus) busInfo.buses.FirstOrDefault(acBus => acBus is TBus);
                if (bus != null)
                    return bus;
                bus = (TBus) typeof(TBus)
                    .GetConstructor(new Type[] {typeof(ICommandHandlerFactory)})?
                    .Invoke(new object[] {busInfo.factory});
                if (ReferenceEquals(bus, null))
                    ThrowHelper.ThrowWhenAccessBusRequireFailed(typeof(TBus));
                if (bus is IAccessBus accessBus)
                    busInfo.buses.Add(accessBus);
                else
                    ThrowHelper.ThrowWhenAccessBusRequireFailed(typeof(TBus));
            }
            else
                ThrowHelper.ThrowWhenHandlerFactoryNeverBeenRegistered(typeof(TBus));

            return bus;
        }

        // public ICommandBus<ParameterNotification, TOperation> Require<TOperation>(TTheme theme) where TOperation : ICommandOperation
        //     => RequireInternal<ICommandBus<ParameterNotification, TOperation>, ParameterNotification, TOperation>(theme);
        //
        // public ICommandBus<ParameterNotification<T>, TOperation> Require<TOperation, T>(TTheme theme) where TOperation : ICommandOperation
        //     => RequireInternal<ICommandBus<ParameterNotification<T>, TOperation>, ParameterNotification<T>, TOperation>(theme);
        //
        // public ICommandBus<ParameterNotification<T1, T2>, TOperation> Require<TOperation, T1, T2>(TTheme theme) where TOperation : ICommandOperation
        //     => RequireInternal<ICommandBus<ParameterNotification<T1, T2>, TOperation>, ParameterNotification<T1, T2>, TOperation>(theme);
        //
        // public ICommandBus<ParameterNotification<T1, T2, T3>, TOperation> Require<TOperation, T1, T2, T3>(TTheme theme) where TOperation : ICommandOperation
        //     => RequireInternal<ICommandBus<ParameterNotification<T1, T2, T3>, TOperation>, ParameterNotification<T1, T2, T3>, TOperation>(theme);
        //
        // public ICommandBus<ParameterNotification<T1, T2, T3, T4>, TOperation> Require<TOperation, T1, T2, T3, T4>(TTheme theme) where TOperation : ICommandOperation
        //     => RequireInternal<ICommandBus<ParameterNotification<T1, T2, T3, T4>, TOperation>, ParameterNotification<T1, T2, T3, T4>, TOperation>(theme);
        //
        // public ICommandBus<ParameterNotification<T1, T2, T3, T4, T5>, TOperation> Require<TOperation, T1, T2, T3, T4, T5>(TTheme theme) where TOperation : ICommandOperation
        //     => RequireInternal<ICommandBus<ParameterNotification<T1, T2, T3, T4, T5>, TOperation>, ParameterNotification<T1, T2, T3, T4, T5>, TOperation>(theme);
    }
}