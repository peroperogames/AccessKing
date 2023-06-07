/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月26日
 * Description: Default event schedule implementation.
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PeroTools2.AccessKing
{
    public class EventSchedule<TTheme> : IEventSchedule<TTheme>, IAccessSchedule<TTheme>
    {
        private readonly Dictionary<TTheme, IAccessBus> m_EventBusMaps = new Dictionary<TTheme, IAccessBus>();
        IAccessBus IAccessSchedule<TTheme>.this[TTheme theme] => m_EventBusMaps[theme];
        
        IAccessBus IAccessSchedule<TTheme>.GetBus(TTheme theme) => m_EventBusMaps[theme];
        
        bool IAccessSchedule<TTheme>.TryGetBus(TTheme theme, out IAccessBus bus) => m_EventBusMaps.TryGetValue(theme, out bus);

        void IAccessSchedule<TTheme>.AddThemeMapping(TTheme theme, IAccessBus bus)
        {
            if (typeof(ISchedulableEventBus<>).IsInstanceOfType(bus) )
            {
                ThrowHelper.ScheduleEventBusCastFailed();
            }

            m_EventBusMaps.Add(theme, bus);
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<IAccessBus> GetEnumerator() => m_EventBusMaps.Values.GetEnumerator();

        public bool RemoveTheme(TTheme theme) => m_EventBusMaps.Remove(theme);
        
        public bool RemoveBus(IAccessBus accessBus)
        {
            var pair = m_EventBusMaps.FirstOrDefault(kv => kv.Value.Equals(accessBus));
            return pair.Key != null && m_EventBusMaps.Remove(pair.Key);
        }

        public bool ContainsBus(TTheme theme) => m_EventBusMaps.ContainsKey(theme);

        public void ClearTheme() => m_EventBusMaps.Clear();

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

        public void AddThemeMapping<TNotification>(TTheme theme, ISchedulableEventBus<TNotification> bus) where TNotification : INotification => m_EventBusMaps.Add(theme, bus);

        /// <summary>
        /// Get or create a event bus with 0 argument type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <returns>Event bus for the corresponding theme.</returns>
        public IEventBus<Empty> Require(TTheme theme)
        {
            if (!TryGetBus<Empty>(theme, out var bus))
            {
                var eventBus = new ParameterEventBus();
                bus = eventBus;
                AddThemeMapping(theme, eventBus);
            }

            return bus;
        }

        /// <summary>
        /// Get or create a event bus with 1 argument type parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <returns>Event bus for the corresponding theme.</returns>
        public IEventBus<ParameterNotification<T>> Require<T>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T>>(theme, out var bus))
            {
                var eventBus = new ParameterEventBus<T>();
                bus = eventBus;
                AddThemeMapping(theme, eventBus);
            }

            return bus;
        }

        /// <summary>
        /// Get or create a event bus with 2 argument types parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <returns>Event bus for the corresponding theme.</returns>
        public IEventBus<ParameterNotification<T1, T2>> Require<T1, T2>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2>>(theme, out var bus))
            {
                var eventBus = new ParameterEventBus<T1, T2>();
                bus = eventBus;
                AddThemeMapping(theme, eventBus);
            }

            return bus;
        }

        /// <summary>
        /// Get or create a event bus with 3 argument types parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <returns>Event bus for the corresponding theme.</returns>
        public IEventBus<ParameterNotification<T1, T2, T3>> Require<T1, T2, T3>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2, T3>>(theme, out var bus))
            {
                var eventBus = new ParameterEventBus<T1, T2, T3>();
                bus = eventBus;
                AddThemeMapping(theme, eventBus);
            }

            return bus;
        }

        /// <summary>
        /// Get or create a event bus with 4 argument types parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <returns>Event bus for the corresponding theme.</returns>
        public IEventBus<ParameterNotification<T1, T2, T3, T4>> Require<T1, T2, T3, T4>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2, T3, T4>>(theme, out var bus))
            {
                var eventBus = new ParameterEventBus<T1, T2, T3, T4>();
                bus = eventBus;
                AddThemeMapping(theme, eventBus);
            }

            return bus;
        }

        /// <summary>
        /// Get or create a event bus with 5 argument types parameter notification from schedule by theme.
        /// </summary>
        /// <param name="theme">Theme.</param>
        /// <returns>Event bus for the corresponding theme.</returns>
        public IEventBus<ParameterNotification<T1, T2, T3, T4, T5>> Require<T1, T2, T3, T4, T5>(TTheme theme)
        {
            if (!TryGetBus<ParameterNotification<T1, T2, T3, T4, T5>>(theme, out var bus))
            {
                var eventBus = new ParameterEventBus<T1, T2, T3, T4, T5>();
                bus = eventBus;
                AddThemeMapping(theme, eventBus);
            }

            return bus;
        }
    }
}