using System;

namespace PeroTools2.AccessKing
{
    public static class EventExtensions
    {

        #region Subscribe

        public static void Subscribe(this IEventBus<ParameterNotification> eventBus, Action action)
            => eventBus.Subscribe(new ActionHandler(action));

        public static void Subscribe<T>(this IEventBus<ParameterNotification<T>> eventBus, Action<T> action)
            => eventBus.Subscribe(new ActionHandler<T>(action));

        public static void Subscribe<T1, T2>(this IEventBus<ParameterNotification<T1, T2>> eventBus, Action<T1, T2> action)
            => eventBus.Subscribe(new ActionHandler<T1, T2>(action));

        public static void Subscribe<T1, T2, T3>(this IEventBus<ParameterNotification<T1, T2, T3>> eventBus, Action<T1, T2, T3> action)
            => eventBus.Subscribe(new ActionHandler<T1, T2, T3>(action));

        public static void Subscribe<T1, T2, T3, T4>(this IEventBus<ParameterNotification<T1, T2, T3, T4>> eventBus, Action<T1, T2, T3, T4> action)
            => eventBus.Subscribe(new ActionHandler<T1, T2, T3, T4>(action));

        public static void Subscribe<T1, T2, T3, T4, T5>(this IEventBus<ParameterNotification<T1, T2, T3, T4, T5>> eventBus, Action<T1, T2, T3, T4, T5> action)
            => eventBus.Subscribe(new ActionHandler<T1, T2, T3, T4, T5>(action));

        #endregion

        #region Unsubscribe

        public static bool Unsubscribe(this IEventBus<ParameterNotification> eventBus, Action action)
            => eventBus.Unsubscribe(new ActionHandler(action));

        public static bool Unsubscribe<T>(this IEventBus<ParameterNotification<T>> eventBus, Action<T> action)
            => eventBus.Unsubscribe(new ActionHandler<T>(action));

        public static bool Unsubscribe<T1, T2>(this IEventBus<ParameterNotification<T1, T2>> eventBus, Action<T1, T2> action)
            => eventBus.Unsubscribe(new ActionHandler<T1, T2>(action));

        public static bool Unsubscribe<T1, T2, T3>(this IEventBus<ParameterNotification<T1, T2, T3>> eventBus, Action<T1, T2, T3> action)
            => eventBus.Unsubscribe(new ActionHandler<T1, T2, T3>(action));

        public static bool Unsubscribe<T1, T2, T3, T4>(this IEventBus<ParameterNotification<T1, T2, T3, T4>> eventBus, Action<T1, T2, T3, T4> action)
            => eventBus.Unsubscribe(new ActionHandler<T1, T2, T3, T4>(action));

        public static bool Unsubscribe<T1, T2, T3, T4, T5>(this IEventBus<ParameterNotification<T1, T2, T3, T4, T5>> eventBus, Action<T1, T2, T3, T4, T5> action)
            => eventBus.Unsubscribe(new ActionHandler<T1, T2, T3, T4, T5>(action));

        #endregion

        #region Broadcast

        public static void Broadcast<T>(this IEventBus<ParameterNotification> eventBus)
            => eventBus.Broadcast(ParameterNotification.Default);

        public static void Broadcast<T>(this IEventBus<ParameterNotification<T>> eventBus, T param)
            => eventBus.Broadcast(new ParameterNotification<T>(param));

        public static void Broadcast<T1, T2>(this IEventBus<ParameterNotification<T1, T2>> eventBus, T1 param1, T2 param2)
            => eventBus.Broadcast(new ParameterNotification<T1, T2>(param1, param2));

        public static void Broadcast<T1, T2, T3>(this IEventBus<ParameterNotification<T1, T2, T3>> eventBus, T1 param1, T2 param2, T3 param3)
            => eventBus.Broadcast(new ParameterNotification<T1, T2, T3>(param1, param2, param3));

        public static void Broadcast<T1, T2, T3, T4>(this IEventBus<ParameterNotification<T1, T2, T3, T4>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4)
            => eventBus.Broadcast(new ParameterNotification<T1, T2, T3, T4>(param1, param2, param3, param4));

        public static void Broadcast<T1, T2, T3, T4, T5>(this IEventBus<ParameterNotification<T1, T2, T3, T4, T5>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
            => eventBus.Broadcast(new ParameterNotification<T1, T2, T3, T4, T5>(param1, param2, param3, param4, param5));

        #endregion
    }
}