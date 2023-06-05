/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月23日
 * Description: Event bus/schedule extensions.
 */

using System;
using System.Diagnostics.CodeAnalysis;

namespace PeroTools2.AccessKing
{
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    public static class EventExtensions
    {
        #region Subscribe

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe(this IEventBus<Empty> eventBus, Action action)
            => eventBus.Subscribe(new ActionEventHandler(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T>(this IEventBus<ParameterNotification<T>> eventBus, Action<T> action)
            => eventBus.Subscribe(new ActionEventHandler<T>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2>(this IEventBus<ParameterNotification<T1, T2>> eventBus, Action<T1, T2> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3>(this IEventBus<ParameterNotification<T1, T2, T3>> eventBus, Action<T1, T2, T3> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3, T4>(this IEventBus<ParameterNotification<T1, T2, T3, T4>> eventBus, Action<T1, T2, T3, T4> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3, T4, T5>(this IEventBus<ParameterNotification<T1, T2, T3, T4, T5>> eventBus, Action<T1, T2, T3, T4, T5> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4, T5>(action));

        #endregion

        #region Unsubscribe

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe(this IEventBus<Empty> eventBus, Action action)
            => eventBus.Unsubscribe(new ActionEventHandler(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T>(this IEventBus<ParameterNotification<T>> eventBus, Action<T> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2>(this IEventBus<ParameterNotification<T1, T2>> eventBus, Action<T1, T2> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3>(this IEventBus<ParameterNotification<T1, T2, T3>> eventBus, Action<T1, T2, T3> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3, T4>(this IEventBus<ParameterNotification<T1, T2, T3, T4>> eventBus, Action<T1, T2, T3, T4> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3, T4, T5>(this IEventBus<ParameterNotification<T1, T2, T3, T4, T5>> eventBus, Action<T1, T2, T3, T4, T5> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4, T5>(action));

        #endregion

        #region Broadcast

        /// <summary>
        /// Execute all handler's handle method in bus with 0 argument type parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast(this IEventBus<Empty> eventBus)
            => eventBus.Broadcast(ParameterNotification.Empty);

        /// <summary>
        /// Execute all handler's handle method in bus with 1 argument type parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T>(this IEventBus<ParameterNotification<T>> eventBus, T param)
            => eventBus.Broadcast(ParameterNotification.Create(param));

        /// <summary>
        /// Execute all handler's handle method in bus with 2 argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2>(this IEventBus<ParameterNotification<T1, T2>> eventBus, T1 param1, T2 param2)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2));

        /// <summary>
        /// Execute all handler's handle method in bus with 3 argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3>(this IEventBus<ParameterNotification<T1, T2, T3>> eventBus, T1 param1, T2 param2, T3 param3)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3));

        /// <summary>
        /// Execute all handler's handle method in bus with 4 argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3, T4>(this IEventBus<ParameterNotification<T1, T2, T3, T4>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4));

        /// <summary>
        /// Execute all handler's handle method in bus with 5 argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3, T4, T5>(this IEventBus<ParameterNotification<T1, T2, T3, T4, T5>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4, param5));

        #endregion
    }
}