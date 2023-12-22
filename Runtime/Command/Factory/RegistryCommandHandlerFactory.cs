/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/23 16:05:34
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Command handler factory registered in a hard coding manner.
    /// </summary>
    public class RegistryCommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly Dictionary<Type, List<object>> m_HandlerMaps = new();

        /// <summary>
        /// Handlers count.
        /// </summary>
        public int handlerCount { get; private set; }

        /// <summary>
        /// Register command handler to factory.
        /// </summary>
        /// <param name="handler">The command handler with notification.</param>
        /// <typeparam name="TNotification">Notification type.</typeparam>
        public void RegisterHandler<TNotification>(ICommandHandler<TNotification> handler) where TNotification : INotification
        {
            if (!m_HandlerMaps.TryGetValue(typeof(TNotification), out var handlers))
            {
                handlers = new List<object>();
                m_HandlerMaps[typeof(TNotification)] = handlers;
            }

            handlers.Add(handler);
            handlerCount++;
        }

        /// <summary>
        /// Unregister command handler from factory.
        /// </summary>
        /// <param name="handler">The command handler with notification.</param>
        /// <typeparam name="TNotification">Notification type.</typeparam>
        /// <returns>Whether Unregister successfully.</returns>
        public bool UnregisterHandler<TNotification>(ICommandHandler<TNotification> handler) where TNotification : INotification
        {
            if (!m_HandlerMaps.TryGetValue(typeof(TNotification), out var handlers) || !handlers.Remove(handler))
            {
                return false;
            }
            handlerCount--;
            return true;
        }

        /// <summary>
        /// Remove all registered handlers.
        /// </summary>
        public void ClearHandlers() => m_HandlerMaps.Clear();

        /// <inheritdoc cref="ICommandHandlerFactory.GetHandlers{TNotification}()"/>
        public IEnumerable<ICommandHandler<TNotification>> GetHandlers<TNotification>() where TNotification : INotification
            => m_HandlerMaps.TryGetValue(typeof(TNotification), out var handlers)
                ? handlers.Cast<ICommandHandler<TNotification>>()
                : Array.Empty<ICommandHandler<TNotification>>();

        /// <summary>
        /// Whether contains the CommandHandler with specified notification type.
        /// </summary>
        /// <typeparam name="TNotification">Notification type.</typeparam>
        /// <returns>Whether contains handler.</returns>
        public bool ContainsHandler<TNotification>() where TNotification : INotification => m_HandlerMaps.ContainsKey(typeof(TNotification));
    }
}