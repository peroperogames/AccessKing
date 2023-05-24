using System;
using System.Collections.Generic;
using System.Linq;

namespace PeroTools2.AccessKing
{
    public class RegistryCommandExecutiveFactory : ICommandExecutiveFactory
    {
        private readonly Dictionary<Type, List<ICommandExecutive>> m_ExecutiveMaps = new Dictionary<Type, List<ICommandExecutive>>();

        public void RegisterExecutive<TNotification>(ICommandExecutive<TNotification> executive) where TNotification : INotification
        {
            if (!m_ExecutiveMaps.TryGetValue(typeof(TNotification), out var handlers))
            {
                handlers = new List<ICommandExecutive>();
                m_ExecutiveMaps[typeof(TNotification)] = handlers;
            }

            handlers.Add(executive);
        }

        public bool UnRegisterExecutive<TNotification>(ICommandExecutive<TNotification> executive) where TNotification : INotification
        {
            return m_ExecutiveMaps.TryGetValue(typeof(TNotification), out var executives) && executives.Remove(executive);
        }


        public IEnumerable<ICommandExecutive<TNotification>> RequireExecutives<TNotification>() where TNotification : INotification
        {
            return m_ExecutiveMaps.TryGetValue(typeof(TNotification), out var executives)
                ? executives.Select(executive => (ICommandExecutive<TNotification>) executive)
                : Array.Empty<ICommandExecutive<TNotification>>();
        }
    }
}