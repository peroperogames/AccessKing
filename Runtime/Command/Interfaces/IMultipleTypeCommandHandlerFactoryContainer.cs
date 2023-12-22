/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/06 19:12:22
 */

using System;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Container with factory select with type key.
    /// </summary>
    public interface IMultipleTypeCommandHandlerFactoryContainer
    {
        /// <summary>
        /// Try get the factory with the specified type.
        /// </summary>
        /// <param name="factoryType">Type of <see cref="ICommandHandlerFactory"/>.</param>
        /// <param name="commandHandlerFactory">The factory instance with <c>factoryType</c>.</param>
        /// <returns>True when there is any factory type match <c>factoryType</c></returns>
        bool TryGetFactory(Type factoryType, out ICommandHandlerFactory commandHandlerFactory);

        /// <summary>
        /// Check whether the specified factory type is contained
        /// </summary>
        /// <param name="factoryType">Type of <see cref="ICommandHandlerFactory"/>.</param>
        /// <returns>Is contained.</returns>
        bool ContainsFactory(Type factoryType);

        /// <summary>
        /// Removes factory that from container.
        /// </summary>
        /// <param name="factoryType">Type of <see cref="ICommandHandlerFactory"/>.</param>
        /// <returns>Is remove successfully.</returns>
        bool RemoveFactory(Type factoryType);

        /// <summary>
        /// Removes all factories that from container.
        /// </summary>
        void ClearFactories();

        /// <summary>
        /// Get factory from container with specified type.
        /// </summary>
        /// <param name="factoryType">Type of <see cref="ICommandHandlerFactory"/>.</param>
        /// <returns>The factory instance with <c>factoryType</c>.</returns>
        ICommandHandlerFactory GetFactory(Type factoryType);

        /// <summary>
        /// Add factory into container.
        /// It would build a key with type for the factory instance.
        /// </summary>
        /// <param name="factory">Factory instance.</param>
        void AddFactory(ICommandHandlerFactory factory);
    }
}