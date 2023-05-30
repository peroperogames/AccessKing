using System;
using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public class CommandExecutive
    {
        private readonly ICommandHandlerFactory m_Factory;
        private readonly Dictionary<Type, List<IAccessBus>> m_Buses = new Dictionary<Type, List<IAccessBus>>();

        public CommandExecutive(ICommandHandlerFactory factory)
        {
            m_Factory = factory;
        }

        internal void Add<TNotification>(IAccessBus accessBus)
        {
            if (!m_Buses.TryGetValue(typeof(TNotification), out var buses))
            {
                buses = new List<IAccessBus>();
                m_Buses.Add(typeof(TNotification), buses);
            }

            buses.Add(accessBus);
        }

        protected TOperation Execute<TNotification, TOperation>(TNotification notification) where TNotification : INotification where TOperation : ICommandOperation
        {
            if (!m_Buses.TryGetValue(typeof(TNotification), out var buses)) return default;
            for (var index = 0; index < buses.Count; index++)
            {
                if (buses[index] is ICommandBus<TNotification, TOperation> bus)
                {
                    return bus.Execute(m_Factory, notification);
                }
            }

            return default;
        }
    }

    public sealed class CommandExecutive<TNotification, TOperation> : CommandExecutive where TNotification : INotification where TOperation : ICommandOperation
    {
        public CommandExecutive(ICommandHandlerFactory factory) : base(factory) { }

        public TOperation Execute(TNotification notification)
        {
            return base.Execute<TNotification, TOperation>(notification);
        }
    }
}