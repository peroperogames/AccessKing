/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/23 16:05:45
 */

using System;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Extensions for <see cref="IEventBus{TNotification}"/>.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    public static class EventBusExtensions
    {
        #region Subscribe

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe(this IEventSubscriable<Empty> eventBus, Action action)
            => eventBus.Subscribe(new ActionEventHandler(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T>(this IEventSubscriable<ParameterNotification<T>> eventBus, Action<T> action)
            => eventBus.Subscribe(new ActionEventHandler<T>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2>(this IEventSubscriable<ParameterNotification<T1, T2>> eventBus, Action<T1, T2> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3>(this IEventSubscriable<ParameterNotification<T1, T2, T3>> eventBus, Action<T1, T2, T3> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3, T4>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4>> eventBus, Action<T1, T2, T3, T4> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3, T4, T5>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5>> eventBus, Action<T1, T2, T3, T4, T5> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4, T5>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3, T4, T5, T6>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6>> eventBus, Action<T1, T2, T3, T4, T5, T6> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3, T4, T5, T6, T7>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3, T4, T5, T6, T7, T8>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void Subscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(action));

        #endregion

        #region SubscribeWeakly

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="eventHandler">The handler that would be referenced weakly by the event bus.</param>
        public static void SubscribeWeakly<TNotification>(this IWeakEventSubscriable<TNotification> eventBus, IEventHandler<TNotification> eventHandler) where TNotification : INotification
            => eventBus.SubscribeWeakly(new WeakEventHandler<TNotification>(eventHandler));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<TEventSource>(this IWeakEventSubscriable<Empty> eventBus, Action action, TEventSource provider) where TEventSource : class
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<TEventSource>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<TEventSource, T>(this IWeakEventSubscriable<ParameterNotification<T>> eventBus, Action<T> action, TEventSource provider) where TEventSource : class
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<TEventSource, T>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<TEventSource, T1, T2>(this IWeakEventSubscriable<ParameterNotification<T1, T2>> eventBus, Action<T1, T2> action, TEventSource provider) where TEventSource : class
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<TEventSource, T1, T2>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<TEventSource, T1, T2, T3>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3>> eventBus, Action<T1, T2, T3> action, TEventSource provider) where TEventSource : class
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<TEventSource, T1, T2, T3>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<TEventSource, T1, T2, T3, T4>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4>> eventBus, Action<T1, T2, T3, T4> action, TEventSource provider) where TEventSource : class
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<TEventSource, T1, T2, T3, T4>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<TEventSource, T1, T2, T3, T4, T5>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5>> eventBus, Action<T1, T2, T3, T4, T5> action, TEventSource provider) where TEventSource : class
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<TEventSource, T1, T2, T3, T4, T5, T6>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6>> eventBus, Action<T1, T2, T3, T4, T5, T6> action, TEventSource provider) where TEventSource : class
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<TEventSource, T1, T2, T3, T4, T5, T6, T7>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7> action, TEventSource provider) where TEventSource : class
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8> action, TEventSource provider) where TEventSource : class
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, TEventSource provider) where TEventSource : class
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, TEventSource provider) where TEventSource : class
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action, TEventSource provider) where TEventSource : class
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action, TEventSource provider) where TEventSource : class
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action, TEventSource provider) where TEventSource : class
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, TEventSource provider) where TEventSource : class
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action, TEventSource provider) where TEventSource : class
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(action, provider));

        #endregion

        #region Unsubscribe

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe(this IEventSubscriable<Empty> eventBus, Action action)
            => eventBus.Unsubscribe(new ActionEventHandler(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T>(this IEventSubscriable<ParameterNotification<T>> eventBus, Action<T> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2>(this IEventSubscriable<ParameterNotification<T1, T2>> eventBus, Action<T1, T2> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3>(this IEventSubscriable<ParameterNotification<T1, T2, T3>> eventBus, Action<T1, T2, T3> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3, T4>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4>> eventBus, Action<T1, T2, T3, T4> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3, T4, T5>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5>> eventBus, Action<T1, T2, T3, T4, T5> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4, T5>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3, T4, T5, T6>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6>> eventBus, Action<T1, T2, T3, T4, T5, T6> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3, T4, T5, T6, T7>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3, T4, T5, T6, T7, T8>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(action));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then unsubscribe from event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static bool Unsubscribe<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(action));

        #endregion

        #region Broadcast

        /// <summary>
        /// Execute all handler's handle method in bus with argument argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast(this IEventBroadcastable<Empty> eventBus)
            => eventBus.Broadcast(ParameterNotification.Empty);

        /// <summary>
        /// Execute all handler's handle method in bus with argument argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T>(this IEventBroadcastable<ParameterNotification<T>> eventBus, T param)
            => eventBus.Broadcast(ParameterNotification.Create(param));

        /// <summary>
        /// Execute all handler's handle method in bus with arguments argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2>(this IEventBroadcastable<ParameterNotification<T1, T2>> eventBus, T1 param1, T2 param2)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2));

        /// <summary>
        /// Execute all handler's handle method in bus with arguments argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3>(this IEventBroadcastable<ParameterNotification<T1, T2, T3>> eventBus, T1 param1, T2 param2, T3 param3)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3));

        /// <summary>
        /// Execute all handler's handle method in bus with arguments argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3, T4>(this IEventBroadcastable<ParameterNotification<T1, T2, T3, T4>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4));

        /// <summary>
        /// Execute all handler's handle method in bus with arguments argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3, T4, T5>(this IEventBroadcastable<ParameterNotification<T1, T2, T3, T4, T5>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4, param5));

        /// <summary>
        /// Execute all handler's handle method in bus with arguments argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3, T4, T5, T6>(this IEventBroadcastable<ParameterNotification<T1, T2, T3, T4, T5, T6>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4, param5, param6));

        /// <summary>
        /// Execute all handler's handle method in bus with arguments argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3, T4, T5, T6, T7>(this IEventBroadcastable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7));

        /// <summary>
        /// Execute all handler's handle method in bus with arguments argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3, T4, T5, T6, T7, T8>(this IEventBroadcastable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8));

        /// <summary>
        /// Execute all handler's handle method in bus with arguments argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IEventBroadcastable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9));

        /// <summary>
        /// Execute all handler's handle method in bus with arguments argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IEventBroadcastable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10));

        /// <summary>
        /// Execute all handler's handle method in bus with arguments argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IEventBroadcastable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11));

        /// <summary>
        /// Execute all handler's handle method in bus with arguments argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IEventBroadcastable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12));

        /// <summary>
        /// Execute all handler's handle method in bus with arguments argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IEventBroadcastable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13));

        /// <summary>
        /// Execute all handler's handle method in bus with arguments argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IEventBroadcastable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14));

        /// <summary>
        /// Execute all handler's handle method in bus with arguments argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IEventBroadcastable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14, T15 param15)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15));

        /// <summary>
        /// Execute all handler's handle method in bus with arguments argument types parameter notification.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        public static void Broadcast<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IEventBroadcastable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14, T15 param15, T16 param16)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16));

        #endregion
    }
}