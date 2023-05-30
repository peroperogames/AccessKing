using System.Collections;
using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public class CommandSchedule<TTheme> : IAccessSchedule<TTheme>, ICommandSchedule<TTheme>
    {
        private readonly Dictionary<TTheme, CommandExecutive> m_CommandBusMaps = new Dictionary<TTheme, CommandExecutive>();
        private readonly Dictionary<TTheme, ICommandHandlerFactory> m_FactoryMaps = new Dictionary<TTheme, ICommandHandlerFactory>();

        public CommandExecutive<TNotification, TOperation> Require<TNotification, TOperation>(TTheme theme) where TNotification : INotification where TOperation : ICommandOperation
        {
            if (m_CommandBusMaps.TryGetValue(theme, out var executive))
            {
                return executive as CommandExecutive<TNotification, TOperation>;
            }

            ThrowHelper.ThrowWhenAccessBusRequireFailed(typeof(ICommandBus<TNotification, TOperation>));
            return null;
        }

        public CommandExecutive<ParameterNotification, TOperation> RequireWithParams<TOperation>(TTheme theme) where TOperation : ICommandOperation
            => Require<ParameterNotification, TOperation>(theme);

        public CommandExecutive<ParameterNotification<T>, TOperation> RequireWithParams<T, TOperation>(TTheme theme) where TOperation : ICommandOperation
            => Require<ParameterNotification<T>, TOperation>(theme);

        public CommandExecutive<ParameterNotification<T1, T2>, TOperation> RequireWithParams<T1, T2, TOperation>(TTheme theme) where TOperation : ICommandOperation
            => Require<ParameterNotification<T1, T2>, TOperation>(theme);

        public CommandExecutive<ParameterNotification<T1, T2, T3>, TOperation> RequireWithParams<T1, T2, T3, TOperation>(TTheme theme) where TOperation : ICommandOperation
            => Require<ParameterNotification<T1, T2, T3>, TOperation>(theme);

        public CommandExecutive<ParameterNotification<T1, T2, T3, T4>, TOperation> RequireWithParams<T1, T2, T3, T4, TOperation>(TTheme theme) where TOperation : ICommandOperation
            => Require<ParameterNotification<T1, T2, T3, T4>, TOperation>(theme);

        public CommandExecutive<ParameterNotification<T1, T2, T3, T4, T5>, TOperation> RequireWithParams<T1, T2, T3, T4, T5, TOperation>(TTheme theme) where TOperation : ICommandOperation
            => Require<ParameterNotification<T1, T2, T3, T4, T5>, TOperation>(theme);

        public void AddFactory(TTheme theme, ICommandHandlerFactory factory)
        {
            m_FactoryMaps.Add(theme, factory);
        }

        public void AddBus<TNotification, TOperation>(TTheme theme, ICommandBus<TNotification, TOperation> bus) where TNotification : INotification where TOperation : ICommandOperation
        {
            if (m_CommandBusMaps.TryGetValue(theme, out var executive))
            {
                if (bus is IAccessBus accessBus)
                    executive.Add<TNotification>(accessBus);
                else
                    ThrowHelper.ThrowWhenAccessBusCastFailed(bus.GetType());
            }
            else if (m_FactoryMaps.TryGetValue(theme, out var factory))
            {
                executive = new CommandExecutive<TNotification, TOperation>(factory);
                m_CommandBusMaps.Add(theme, executive);
                if (bus is IAccessBus accessBus)
                    executive.Add<TNotification>(accessBus);
                else
                    ThrowHelper.ThrowWhenAccessBusCastFailed(bus.GetType());
            }
            else
                ThrowHelper.ThrowWhenHandlerFactoryNeverBeenRegistered(theme);
        }


        public IEnumerator<IAccessBus> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IAccessBus IAccessSchedule<TTheme>.this[TTheme theme] => throw new System.NotImplementedException();

        bool IAccessSchedule<TTheme>.TryGetBus(TTheme theme, out IAccessBus bus)
        {
            throw new System.NotImplementedException();
        }

        void IAccessSchedule<TTheme>.AddBus(TTheme theme, IAccessBus bus)
        {
            throw new System.NotImplementedException();
        }
    }
}