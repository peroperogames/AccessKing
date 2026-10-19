/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/29 17:05:57
 */

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Pool;

namespace PeroTools2.AccessKing
{
    /// <inheritdoc cref="ICommandBus{TNotification}"/>
    public class CommandBus<TNotification> : IAccessBus, ICommandBus<TNotification>, IMultipleTypeCommandHandlerFactoryContainer where TNotification : INotification
    {
        /// <summary>
        /// Handler collections.
        /// </summary>
        private readonly Dictionary<Type, ICommandHandlerFactory> m_HandlerFactories;

        /// <param name="handlerFactories">
        /// Factories that locate the handlers about specific notification.
        /// The factory type must be different.
        /// </param>
        public CommandBus(params ICommandHandlerFactory[] handlerFactories) => m_HandlerFactories = handlerFactories.ToDictionary(static item => item.GetType());

        public CommandBus() => m_HandlerFactories = new Dictionary<Type, ICommandHandlerFactory>();

        /// <inheritdoc cref="IAccessBus.Dispatch(INotification)"/>
        /// <exception cref="InvalidCastException">Throw when the notification cannot match to the generic type.</exception>
        object IAccessBus.Dispatch(INotification notification)
        {
            if (notification is TNotification tNotification)
            {
                return Execute(ref tNotification);
            }
            throw new InvalidCastException($"{notification.GetType()} is not a ${typeof(TNotification)} type. ");
        }

        /// <inheritdoc cref="ICommandBus{TNotification}.Execute(ref TNotification)"/>.
        public CommandOperation Execute(TNotification notification) => Execute(ref notification);

        /// <inheritdoc cref="ICommandBus{TNotification}.Execute(ref TNotification)"/>.
        public CommandOperation Execute(ref TNotification notification)
        {
            var handlers = CollectionPool<List<ICommandHandler<TNotification>>, ICommandHandler<TNotification>>.Get();
            var results = CollectionPool<List<IResultAvailable>, IResultAvailable>.Get();
            try
            {
                foreach (var factory in m_HandlerFactories.Values)
                {
                    // The factory appends into the collection, so it must be cleared for every factory
                    // to keep each handler dispatched exactly once.
                    handlers.Clear();
                    factory.GetHandlers(handlers);
                    foreach (var handler in handlers)
                    {
                        handler.Handle(ref notification);
                        if (handler is IResultAvailable resultGetter)
                        {
                            results.Add(resultGetter);
                        }
                    }
                }
            }
            catch
            {
                // Never leak the rented collections when a handler fails.
                CollectionPool<List<ICommandHandler<TNotification>>, ICommandHandler<TNotification>>.Release(handlers);
                CollectionPool<List<IResultAvailable>, IResultAvailable>.Release(results);
                throw;
            }

            CollectionPool<List<ICommandHandler<TNotification>>, ICommandHandler<TNotification>>.Release(handlers);

            return new CommandOperation(results);
        }

        /// <inheritdoc cref="IMultipleTypeCommandHandlerFactoryContainer.TryGetFactory(Type, out ICommandHandlerFactory)"/>.
        public bool TryGetFactory(Type factoryType, out ICommandHandlerFactory commandHandlerFactory) => m_HandlerFactories.TryGetValue(factoryType, out commandHandlerFactory);

        /// <inheritdoc cref="IMultipleTypeCommandHandlerFactoryContainer.ContainsFactory(Type)"/>.
        public bool ContainsFactory(Type factoryType) => m_HandlerFactories.ContainsKey(factoryType);

        /// <inheritdoc cref="IMultipleTypeCommandHandlerFactoryContainer.ClearFactories()"/>.
        public void ClearFactories() => m_HandlerFactories.Clear();

        /// <inheritdoc cref="IMultipleTypeCommandHandlerFactoryContainer.GetFactory(Type)"/>.
        public ICommandHandlerFactory GetFactory(Type factoryType) => m_HandlerFactories[factoryType];

        /// <inheritdoc cref="IMultipleTypeCommandHandlerFactoryContainer.AddFactory(ICommandHandlerFactory)"/>.
        public void AddFactory(ICommandHandlerFactory factory) => m_HandlerFactories.Add(factory.GetType(), factory);

        /// <inheritdoc cref="IMultipleTypeCommandHandlerFactoryContainer.RemoveFactory(Type)"/>.
        public bool RemoveFactory(Type factoryType) => m_HandlerFactories.Remove(factoryType);
    }
}