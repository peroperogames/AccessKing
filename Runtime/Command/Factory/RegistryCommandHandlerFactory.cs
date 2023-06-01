using System;
using System.Collections.Generic;
using System.Linq;

namespace PeroTools2.AccessKing
{
    public class RegistryCommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly Dictionary<Type, List<object>> m_HandlerMaps = new Dictionary<Type, List<object>>();

        public void RegisterHandler<TNotification>(ICommandHandler<TNotification> handler) where TNotification : INotification
        {
            if (!m_HandlerMaps.TryGetValue(typeof(TNotification), out var handlers))
            {
                handlers = new List<object>();
                m_HandlerMaps[typeof(TNotification)] = handlers;
            }

            handlers.Add(handler);
        }

        public bool UnRegisterHandler<TNotification>(ICommandHandler<TNotification> handler) where TNotification : INotification
        {
            return m_HandlerMaps.TryGetValue(typeof(TNotification), out var executives) && executives.Remove(handler);
        }

        public IReadOnlyList<ICommandHandler<TNotification>> RequireHandlers<TNotification>() where TNotification : INotification
        {
            return m_HandlerMaps.TryGetValue(typeof(TNotification), out var handlers)
                ? handlers.Select(handler => (ICommandHandler<TNotification>) handler).ToList()
                : Array.Empty<ICommandHandler<TNotification>>().ToList();
        }
    }
}