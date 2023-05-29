using System;
using System.Collections;
using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public class EventSchedule<TTheme> : IEventSchedule<TTheme>, IAccessSchedule<TTheme>
    {
        private readonly Dictionary<TTheme, IAccessBus> m_EventBusMaps = new Dictionary<TTheme, IAccessBus>();
        IAccessBus IAccessSchedule<TTheme>.this[TTheme theme] => throw new NotImplementedException();

        bool IAccessSchedule<TTheme>.TryGetBus(TTheme theme, out IAccessBus bus) => m_EventBusMaps.TryGetValue(theme, out bus);

        void IAccessSchedule<TTheme>.AddBus(TTheme theme, IAccessBus bus)
        {
            if (bus.GetType() != typeof(IEventBus<>))
            {
                throw new InvalidOperationException("The access bus is not a event bus.");
            }

            m_EventBusMaps.Add(theme, bus);
        }

        public IEnumerator<IAccessBus> GetEnumerator() => m_EventBusMaps.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool TryGetBus<TNotification>(TTheme theme, out IEventBus<TNotification> bus) where TNotification : INotification
        {
            if (m_EventBusMaps.TryGetValue(theme, out var accessBus))
            {
                bus = (IEventBus<TNotification>) accessBus;
                return true;
            }

            bus = null;
            return false;
        }

        public void AddBus<TNotification>(TTheme theme, IEventBus<TNotification> bus) where TNotification : INotification
        {
            if(bus is IAccessBus accessBus)
                m_EventBusMaps.Add(theme, accessBus);
            else
                throw new InvalidOperationException("bus must implement from IAccessBus");
        }

        public IEventBus<ParameterNotification> Require(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification>(theme, out var bus))
            {
                bus = new ParameterEventBus();
                AddBus(theme, bus);
            }

            return bus;
        }

        public IEventBus<ParameterNotification<T>> Require<T>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T>>(theme, out var bus))
            {
                bus = new ParameterEventBus<T>();
                AddBus(theme, bus);
            }

            return bus;
        }

        public IEventBus<ParameterNotification<T1, T2>> Require<T1, T2>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2>>(theme, out var bus))
            {
                bus = new ParameterEventBus<T1, T2>();
                AddBus(theme, bus);
            }

            return bus;
        }

        public IEventBus<ParameterNotification<T1, T2, T3>> Require<T1, T2, T3>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2, T3>>(theme, out var bus))
            {
                bus = new ParameterEventBus<T1, T2, T3>();
                AddBus(theme, bus);
            }

            return bus;
        }

        public IEventBus<ParameterNotification<T1, T2, T3, T4>> Require<T1, T2, T3, T4>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2, T3, T4>>(theme, out var bus))
            {
                bus = new ParameterEventBus<T1, T2, T3, T4>();
                AddBus(theme, bus);
            }

            return bus;
        }

        public IEventBus<ParameterNotification<T1, T2, T3, T4, T5>> Require<T1, T2, T3, T4, T5>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2, T3, T4, T5>>(theme, out var bus))
            {
                bus = new ParameterEventBus<T1, T2, T3, T4, T5>();
                AddBus(theme, bus);
            }

            return bus;
        }
    }
}