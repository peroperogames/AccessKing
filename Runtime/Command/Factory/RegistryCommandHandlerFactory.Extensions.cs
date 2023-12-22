/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/11 09:12:22
 */

using System;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Extensions for <see cref="ICommandHandlerFactory"/>.
    /// </summary>
    public static class RegistryCommandHandlerFactoryExtensions
    {
        #region RegisterActionHandler

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler(this RegistryCommandHandlerFactory factory, Action action)
            => factory.RegisterHandler(new ActionCommandHandler(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T>(this RegistryCommandHandlerFactory factory, Action<T> action)
            => factory.RegisterHandler(new ActionCommandHandler<T>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2>(this RegistryCommandHandlerFactory factory, Action<T1, T2> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3, T4>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3, T4, T5>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3, T4, T5, T6>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3, T4, T5, T6, T7>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(action));

        #endregion

        #region RegisterFuncHandler

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterFuncHandler<TResult>(this RegistryCommandHandlerFactory factory, Func<TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterFuncHandler<T, TResult>(this RegistryCommandHandlerFactory factory, Func<T, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, T3, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, T3, T4, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, T4, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, T3, T4, T5, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, T3, T4, T5, T6, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(func));

        #endregion

        #region UnRegisterActionHandler

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler(this RegistryCommandHandlerFactory factory, Action action)
            => factory.UnregisterHandler(new ActionCommandHandler(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler<T>(this RegistryCommandHandlerFactory factory, Action<T> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler<T1, T2>(this RegistryCommandHandlerFactory factory, Action<T1, T2> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler<T1, T2, T3>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler<T1, T2, T3, T4>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3, T4>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler<T1, T2, T3, T4, T5>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler<T1, T2, T3, T4, T5, T6>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler<T1, T2, T3, T4, T5, T6, T7>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterActionHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(action));

        #endregion

        #region UnregisterFuncHandler

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterFuncHandler<TResult>(this RegistryCommandHandlerFactory factory, Func<TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterFuncHandler<T, TResult>(this RegistryCommandHandlerFactory factory, Func<T, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterFuncHandler<T1, T2, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterFuncHandler<T1, T2, T3, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, T3, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterFuncHandler<T1, T2, T3, T4, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, T3, T4, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterFuncHandler<T1, T2, T3, T4, T5, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterFuncHandler<T1, T2, T3, T4, T5, T6, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool UnregisterFuncHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(func));

        #endregion
    }
}