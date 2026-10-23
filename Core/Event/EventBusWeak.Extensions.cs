/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/23 16:05:45
 */
using System;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Event bus extensions whose provider is a <c>object</c>.
    /// </summary>
    public static class EventBusWeakExtensions
    {
        #region SubscribeWeakly

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        [Obsolete("Use SubscribeWeakly(object provider, Action action) instead.")]
        public static void SubscribeWeakly(this IWeakEventSubscriable<Empty> eventBus, Action action, object provider)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        [Obsolete("Use SubscribeWeakly<T>(object provider, Action<T> action) instead.")]
        public static void SubscribeWeakly<T>(this IWeakEventSubscriable<ParameterNotification<T>> eventBus, Action<T> action, object provider)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        [Obsolete("Use SubscribeWeakly<T1, T2>(object provider, Action<T1, T2> action) instead.")]
        public static void SubscribeWeakly<T1, T2>(this IWeakEventSubscriable<ParameterNotification<T1, T2>> eventBus, Action<T1, T2> action, object provider)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        [Obsolete("Use SubscribeWeakly<T1, T2, T3>(object provider, Action<T1, T2, T3> action) instead.")]
        public static void SubscribeWeakly<T1, T2, T3>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3>> eventBus, Action<T1, T2, T3> action, object provider)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        [Obsolete("Use SubscribeWeakly<T1, T2, T3, T4>(object provider, Action<T1, T2, T3, T4> action) instead.")]
        public static void SubscribeWeakly<T1, T2, T3, T4>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4>> eventBus, Action<T1, T2, T3, T4> action, object provider)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        [Obsolete("Use SubscribeWeakly<T1, T2, T3, T4, T5>(object provider, Action<T1, T2, T3, T4, T5> action) instead.")]
        public static void SubscribeWeakly<T1, T2, T3, T4, T5>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5>> eventBus, Action<T1, T2, T3, T4, T5> action, object provider)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        [Obsolete("Use SubscribeWeakly<T1, T2, T3, T4, T5, T6>(object provider, Action<T1, T2, T3, T4, T5, T6> action) instead.")]
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6>> eventBus, Action<T1, T2, T3, T4, T5, T6> action, object provider)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        [Obsolete("Use SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7>(object provider, Action<T1, T2, T3, T4, T5, T6, T7> action) instead.")]
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7> action, object provider)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        [Obsolete("Use SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8>(object provider, Action<T1, T2, T3, T4, T5, T6, T7, T8> action) instead.")]
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8> action, object provider)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        [Obsolete("Use SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9>(object provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) instead.")]
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, object provider)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        [Obsolete("Use SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(object provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) instead.")]
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, object provider)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        [Obsolete("Use SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(object provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action) instead.")]
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action, object provider)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        [Obsolete("Use SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(object provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action) instead.")]
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action, object provider)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        [Obsolete("Use SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(object provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action) instead.")]
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action, object provider)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        [Obsolete("Use SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(object provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action) instead.")]
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, object provider)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        [Obsolete("Use SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(object provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action) instead.")]
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> eventBus, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action, object provider)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly(this IWeakEventSubscriable<Empty> eventBus, object provider, Action action)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<T>(this IWeakEventSubscriable<ParameterNotification<T>> eventBus, object provider, Action<T> action)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<T1, T2>(this IWeakEventSubscriable<ParameterNotification<T1, T2>> eventBus, object provider, Action<T1, T2> action)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<T1, T2, T3>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3>> eventBus, object provider, Action<T1, T2, T3> action)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<T1, T2, T3, T4>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4>> eventBus, object provider, Action<T1, T2, T3, T4> action)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<T1, T2, T3, T4, T5>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5>> eventBus, object provider, Action<T1, T2, T3, T4, T5> action)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6>> eventBus, object provider, Action<T1, T2, T3, T4, T5, T6> action)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7>> eventBus, object provider, Action<T1, T2, T3, T4, T5, T6, T7> action)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>> eventBus, object provider, Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9>> eventBus, object provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> eventBus, object provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> eventBus, object provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> eventBus, object provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> eventBus, object provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> eventBus, object provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(action, provider));

        /// <summary>
        /// Convert action delegate to ActionEventHandler, then register to event bus.
        /// </summary>
        /// <param name="eventBus">Event bus.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        /// <param name="action">The delegate which convert to ActionEventHandler.</param>
        public static void SubscribeWeakly<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IWeakEventSubscriable<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> eventBus, object provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
            => eventBus.SubscribeWeakly(new WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(action, provider));

        #endregion
    }
}