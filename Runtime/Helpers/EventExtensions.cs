using System;

namespace PeroTools2.AccessKing
{
    public static class EventExtensions
    {
        #region Subscribe

        public static void Subscribe(this IEventBus<Empty> eventBus, Action action)
            => eventBus.Subscribe(new ActionEventHandler(action));

        public static void Subscribe<T>(this IEventBus<ParameterNotification<T>> eventBus, Action<T> action)
            => eventBus.Subscribe(new ActionEventHandler<T>(action));

        public static void Subscribe<T1, T2>(this IEventBus<ParameterNotification<T1, T2>> eventBus, Action<T1, T2> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2>(action));

        public static void Subscribe<T1, T2, T3>(this IEventBus<ParameterNotification<T1, T2, T3>> eventBus, Action<T1, T2, T3> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3>(action));

        public static void Subscribe<T1, T2, T3, T4>(this IEventBus<ParameterNotification<T1, T2, T3, T4>> eventBus, Action<T1, T2, T3, T4> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4>(action));

        public static void Subscribe<T1, T2, T3, T4, T5>(this IEventBus<ParameterNotification<T1, T2, T3, T4, T5>> eventBus, Action<T1, T2, T3, T4, T5> action)
            => eventBus.Subscribe(new ActionEventHandler<T1, T2, T3, T4, T5>(action));

        #endregion

        #region Unsubscribe

        public static bool Unsubscribe(this IEventBus<Empty> eventBus, Action action)
            => eventBus.Unsubscribe(new ActionEventHandler(action));

        public static bool Unsubscribe<T>(this IEventBus<ParameterNotification<T>> eventBus, Action<T> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T>(action));

        public static bool Unsubscribe<T1, T2>(this IEventBus<ParameterNotification<T1, T2>> eventBus, Action<T1, T2> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2>(action));

        public static bool Unsubscribe<T1, T2, T3>(this IEventBus<ParameterNotification<T1, T2, T3>> eventBus, Action<T1, T2, T3> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3>(action));

        public static bool Unsubscribe<T1, T2, T3, T4>(this IEventBus<ParameterNotification<T1, T2, T3, T4>> eventBus, Action<T1, T2, T3, T4> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4>(action));

        public static bool Unsubscribe<T1, T2, T3, T4, T5>(this IEventBus<ParameterNotification<T1, T2, T3, T4, T5>> eventBus, Action<T1, T2, T3, T4, T5> action)
            => eventBus.Unsubscribe(new ActionEventHandler<T1, T2, T3, T4, T5>(action));

        #endregion

        #region Broadcast

        public static void Broadcast(this IEventBus<Empty> eventBus)
            => eventBus.Broadcast(ParameterNotification.Empty);

        public static void Broadcast<T>(this IEventBus<ParameterNotification<T>> eventBus, T param)
            => eventBus.Broadcast(ParameterNotification.Create(param));

        public static void Broadcast<T1, T2>(this IEventBus<ParameterNotification<T1, T2>> eventBus, T1 param1, T2 param2)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2));

        public static void Broadcast<T1, T2, T3>(this IEventBus<ParameterNotification<T1, T2, T3>> eventBus, T1 param1, T2 param2, T3 param3)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3));

        public static void Broadcast<T1, T2, T3, T4>(this IEventBus<ParameterNotification<T1, T2, T3, T4>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4));

        public static void Broadcast<T1, T2, T3, T4, T5>(this IEventBus<ParameterNotification<T1, T2, T3, T4, T5>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
            => eventBus.Broadcast(ParameterNotification.Create(param1, param2, param3, param4, param5));

        #endregion
    }
}