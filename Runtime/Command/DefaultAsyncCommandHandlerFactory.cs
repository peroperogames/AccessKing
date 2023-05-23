using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public class DefaultAsyncCommandHandlerFactory : IAsyncCommandHandlerFactory
    {
        private readonly Dictionary<Type, List<ICommandExecutive>> m_ExecutiveMaps = new Dictionary<Type, List<ICommandExecutive>>();

        public void RegisterHandler<TNotification>(ITaskCommandHandler<TNotification, Task> handler) where TNotification : INotification
        {
            if (!m_ExecutiveMaps.TryGetValue(typeof(TNotification), out var handlers))
            {
                handlers = new List<ICommandExecutive>();
                m_ExecutiveMaps[typeof(TNotification)] = handlers;
            }
            handlers.Add(handler);
        }

        public IEnumerable<ITaskCommandHandler<TNotification, Task>> RequireHandlers<TNotification>() where TNotification : INotification
        {
            if (m_ExecutiveMaps.TryGetValue(typeof(TNotification), out var executives))
            {
                return executives.Select(executive => (ITaskCommandHandler<TNotification, Task>) executive);
            }
            return Array.Empty<IAsyncCommandHandler<TNotification>>();
        }

        IEnumerable<ICommandHandler<TNotification>> ICommandHandlerFactory.RequireHandlers<TNotification>()
        {
            if (m_ExecutiveMaps.TryGetValue(typeof(TNotification), out var executives))
            {
                return executives.Select(executive => (ICommandHandler<TNotification>) executive);
            }
            return Array.Empty<ICommandHandler<TNotification>>();
        }
    }
}