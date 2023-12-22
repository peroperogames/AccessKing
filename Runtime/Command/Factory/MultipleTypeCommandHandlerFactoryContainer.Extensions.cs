/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/07 15:12:05
 */

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Extensions for <see cref="IMultipleTypeCommandHandlerFactoryContainer"/>.
    /// </summary>
    public static class MultipleTypeCommandHandlerFactoryContainerExtensions
    {
        /// <summary>
        /// Try get the factory with the specified type.
        /// </summary>
        /// <param name="factoryContainer">Factory container.</param>
        /// <param name="factory">The factory instance with <c>TFactory</c>.</param>
        /// <typeparam name="TFactory">Type of <see cref="ICommandHandlerFactory"/>.</typeparam>
        /// <returns>True when there is any factory type match <c>factoryType</c></returns>
        public static bool TryGetFactory<TFactory>(this IMultipleTypeCommandHandlerFactoryContainer factoryContainer, out TFactory factory) where TFactory : class, ICommandHandlerFactory
        {
            var succeed = factoryContainer.TryGetFactory(typeof(TFactory), out var iFactory);
            factory = iFactory as TFactory;
            return succeed;
        }

        /// <summary>
        /// Check whether the specified factory type is contained
        /// </summary>
        /// <param name="factoryContainer">Factory container.</param>
        /// <typeparam name="TFactory">Type of <see cref="ICommandHandlerFactory"/>.</typeparam>
        /// <returns>Is contained.</returns>
        public static bool ContainsFactory<TFactory>(this IMultipleTypeCommandHandlerFactoryContainer factoryContainer) where TFactory : ICommandHandlerFactory
            => factoryContainer.ContainsFactory(typeof(TFactory));

        /// <summary>
        /// Removes factory that from container.
        /// </summary>
        /// <param name="factoryContainer">Factory container.</param>
        /// <typeparam name="TFactory">Type of <see cref="ICommandHandlerFactory"/>.</typeparam>
        /// <returns>Is remove successfully.</returns>
        public static bool RemoveFactory<TFactory>(this IMultipleTypeCommandHandlerFactoryContainer factoryContainer) where TFactory : ICommandHandlerFactory
            => factoryContainer.RemoveFactory(typeof(TFactory));

        /// <summary>
        /// Get factory from container with specified type.
        /// </summary>
        /// <param name="factoryContainer">Factory container.</param>
        /// <typeparam name="TFactory">Type of <see cref="ICommandHandlerFactory"/>.</typeparam>
        /// <returns>The factory instance with <c>factoryType</c>.</returns>
        public static ICommandHandlerFactory GetFactory<TFactory>(this IMultipleTypeCommandHandlerFactoryContainer factoryContainer) where TFactory : ICommandHandlerFactory
            => factoryContainer.GetFactory(typeof(TFactory));

        /// <summary>
        /// Get or create a factory with <c>TFactory</c> type.
        /// </summary>
        /// <param name="factoryContainer">Factory container.</param>
        /// <typeparam name="TFactory">Type of <see cref="ICommandHandlerFactory"/>.</typeparam>
        /// <returns>The factory instance with <c>TFactory</c>.</returns>
        public static TFactory RequireFactory<TFactory>(this IMultipleTypeCommandHandlerFactoryContainer factoryContainer) where TFactory : class, ICommandHandlerFactory, new()
        {
            if (factoryContainer.TryGetFactory<TFactory>(out var factory)) return factory;
            factory = new TFactory();
            factoryContainer.AddFactory(factory);
            return factory;
        }
    }
}