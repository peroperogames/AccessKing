using System.Collections;
using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public class CommandSchedule<TTheme> : IAccessSchedule<TTheme>, ICommandSchedule<TTheme>
    {
        private readonly Dictionary<TTheme, IAccessBus> m_CommandBusMaps = new Dictionary<TTheme, IAccessBus>();
        IAccessBus IAccessSchedule<TTheme>.this[TTheme theme] => m_CommandBusMaps[theme];

        public ICommandBus this[TTheme theme]
        {
            get => m_CommandBusMaps[theme] as ICommandBus;
            set => m_CommandBusMaps[theme] = (IAccessBus) value;
        }

        public ICommandBus<TNotification> Require<TNotification>(TTheme theme) where TNotification : INotification
        {
            if (m_CommandBusMaps.TryGetValue(theme, out var bus))
            {
                if (bus is ICommandBus<TNotification> commandBus)
                    return commandBus;
            }

            ThrowHelper.AccessBusRequireFailed(typeof(ICommandBus<TNotification>));
            return null;
        }

        public ICommandBus<Empty> RequireWithParams(TTheme theme)
            => Require<Empty>(theme);

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

        public void AddBus<TBus>(TTheme theme, TBus bus) where TBus : ICommandBus, IAccessBus => m_CommandBusMaps.Add(theme, bus);

        public IEnumerator<IAccessBus> GetEnumerator() => m_CommandBusMaps.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        bool IAccessSchedule<TTheme>.TryGetBus(TTheme theme, out IAccessBus bus) => m_CommandBusMaps.TryGetValue(theme, out bus);

        void IAccessSchedule<TTheme>.AddBus(TTheme theme, IAccessBus bus)
        {
            if (bus is ICommandBus)
                m_CommandBusMaps.Add(theme, bus);
            ThrowHelper.CommandBusCastFailed();
        }
    }
}