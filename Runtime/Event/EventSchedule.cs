using System;
using System.Collections;
using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public class EventSchedule<TTheme> : IEventSchedule<TTheme>, IAccessSchedule<TTheme>
    {
        private readonly Dictionary<TTheme, IAccessBus> m_EventBusMaps = new Dictionary<TTheme, IAccessBus>();
        IAccessBus IAccessSchedule<TTheme>.this[TTheme theme] => m_EventBusMaps[theme];

        bool IAccessSchedule<TTheme>.TryGetBus(TTheme theme, out IAccessBus bus) => m_EventBusMaps.TryGetValue(theme, out bus);

        void IAccessSchedule<TTheme>.AddBus(TTheme theme, IAccessBus bus)
        {
            if (bus.GetType() != typeof(IEventBus<>))
            {
                throw new InvalidOperationException("The access bus is not a event bus.");
            }

            m_EventBusMaps.Add(theme, bus);
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<IAccessBus> GetEnumerator() => m_EventBusMaps.Values.GetEnumerator();

        public bool RemoveTheme(TTheme theme) => m_EventBusMaps.Remove(theme);

        public IEventBus<TNotification> GetBus<TNotification>(TTheme theme) where TNotification : INotification
        {
            if (m_EventBusMaps.TryGetValue(theme, out var bus))
            {
                if (bus is IEventBus<TNotification> eventBus)
                    return eventBus;
            }

            ThrowHelper.AccessBusRequireFailed(typeof(ICommandBus<TNotification>));
            return null;
        }

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

        public void AddBus<TNotification>(TTheme theme, ISchedulableEventBus<TNotification> bus) where TNotification : INotification => m_EventBusMaps.Add(theme, bus);

        public IEventBus<Empty> RequireWithParams(TTheme theme)
        {
            if (!TryGetBus<Empty>(theme, out var bus))
            {
                var eventBus = new ParameterEventBus();
                bus = eventBus;
                AddBus(theme, eventBus);
            }

            return bus;
        }

        public IEventBus<ParameterNotification<T>> RequireWithParams<T>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T>>(theme, out var bus))
            {
                var eventBus = new ParameterEventBus<T>();
                bus = eventBus;
                AddBus(theme, eventBus);
            }

            return bus;
        }

        public IEventBus<ParameterNotification<T1, T2>> RequireWithParams<T1, T2>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2>>(theme, out var bus))
            {
                var eventBus = new ParameterEventBus<T1, T2>();
                bus = eventBus;
                AddBus(theme, eventBus);
            }

            return bus;
        }

        public IEventBus<ParameterNotification<T1, T2, T3>> RequireWithParams<T1, T2, T3>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2, T3>>(theme, out var bus))
            {
                var eventBus = new ParameterEventBus<T1, T2, T3>();
                bus = eventBus;
                AddBus(theme, eventBus);
            }

            return bus;
        }

        public IEventBus<ParameterNotification<T1, T2, T3, T4>> RequireWithParams<T1, T2, T3, T4>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2, T3, T4>>(theme, out var bus))
            {
                var eventBus = new ParameterEventBus<T1, T2, T3, T4>();
                bus = eventBus;
                AddBus(theme, eventBus);
            }

            return bus;
        }

        public IEventBus<ParameterNotification<T1, T2, T3, T4, T5>> RequireWithParams<T1, T2, T3, T4, T5>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2, T3, T4, T5>>(theme, out var bus))
            {
                var eventBus = new ParameterEventBus<T1, T2, T3, T4, T5>();
                bus = eventBus;
                AddBus(theme, eventBus);
            }

            return bus;
        }
    }
}