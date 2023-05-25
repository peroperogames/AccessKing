using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine.Assertions;

namespace PeroTools2.AccessKing
{
    public static class EventHelper
    {
        private static readonly Dictionary<Type, MethodInfo> s_HandleMethods = new Dictionary<Type, MethodInfo>();

        internal static bool TryGetNotificationType(this IEventObserver observer, out Type notificationType)
        {
            notificationType = null;
            foreach (var iEventHandler in observer.GetType().GetInterfaces())
            {
                if (!Regex.Replace(iEventHandler.Name, @"/[.*/]", "TNotification").Equals(typeof(IEventHandler<>).Name)) continue;
                notificationType = iEventHandler.GenericTypeArguments[0];
                return true;
            }

            return false;
        }


        internal static MethodInfo RequireEventHandlerHandleMethod(Type handlerType, Type notificationType)
        {
            if (s_HandleMethods.TryGetValue(notificationType, out var method))
            {
                return method;
            }

            method = handlerType.GetMethods().FirstOrDefault(m => m.ToString().Equals($"Void Handle({notificationType.Name} ByRef)"));
            Assert.IsNotNull(method);
            s_HandleMethods.Add(notificationType, method);
            Delegate.CreateDelegate(typeof(Action<INotification>), method);
            return method;
        }

        internal static MethodInfo RequireAsyncEventHandlerHandleMethod(Type handlerType, Type notificationType)
        {
            if (s_HandleMethods.TryGetValue(notificationType, out var method))
            {
                return method;
            }

            method = handlerType.GetMethods().FirstOrDefault(m => m.ToString().Equals($"Task HandleAsync({notificationType.Name})"));
            Assert.IsNotNull(method);
            s_HandleMethods.Add(notificationType, method);
            return method;
        }

        #region Event Schedule

        public static TEventBus Require<TEventBus>(this IEventSchedule<Type> schedule) where TEventBus : IEventBus, new()
        {
            if (!schedule.TryGetBus(typeof(TEventBus), out var eventBus))
            {
                eventBus = new TEventBus();
                schedule[typeof(TEventBus)] = eventBus;
            }

            return (TEventBus) eventBus;
        }

        public static IEventBus Require<TTheme>(this IEventSchedule<TTheme> schedule, TTheme theme, Type busType = null)
        {
            if (schedule.TryGetBus(theme, out var eventBus))
            {
                return eventBus;
            }

            if (busType == null)
            {
                busType = typeof(SyncEventBus);
            }

            Assert.IsTrue(typeof(IEventBus).IsAssignableFrom(busType));
            eventBus = (IEventBus) Activator.CreateInstance(busType);
            schedule[theme] = eventBus;
            return eventBus;
        }

        #endregion

        #region ActionHandlerConvertion

        public static void Subscribe(this IEventBus eventBus, Action action) => eventBus.Subscribe(new ActionHandler(new GenericDelegate<Action>(action)));
        public static void Subscribe<T>(this IEventBus eventBus, Action<T> action) => eventBus.Subscribe(new ActionHandler<T>(new GenericDelegate<Action<T>>(action)));
        public static void Subscribe<T1, T2>(this IEventBus eventBus, Action<T1, T2> action) => eventBus.Subscribe(new ActionHandler<T1, T2>(new GenericDelegate<Action<T1, T2>>(action)));
        public static void Subscribe<T1, T2, T3>(this IEventBus eventBus, Action<T1, T2, T3> action) => eventBus.Subscribe(new ActionHandler<T1, T2, T3>(new GenericDelegate<Action<T1, T2, T3>>(action)));
        public static void Subscribe<T1, T2, T3, T4>(this IEventBus eventBus, Action<T1, T2, T3, T4> action) => eventBus.Subscribe(new ActionHandler<T1, T2, T3, T4>(new GenericDelegate<Action<T1, T2, T3, T4>>(action)));
        public static void Subscribe<T1, T2, T3, T4, T5>(this IEventBus eventBus, Action<T1, T2, T3, T4, T5> action) => eventBus.Subscribe(new ActionHandler<T1, T2, T3, T4, T5>(new GenericDelegate<Action<T1, T2, T3, T4, T5>>(action)));
        
        
        public static bool Unsubscribe(this IEventBus eventBus, Action action) => eventBus.Unsubscribe(new ActionHandler(new GenericDelegate<Action>(action)));
        public static bool Unsubscribe<T>(this IEventBus eventBus, Action<T> action) => eventBus.Unsubscribe(new ActionHandler<T>(new GenericDelegate<Action<T>>(action)));
        public static bool Unsubscribe<T1, T2>(this IEventBus eventBus, Action<T1, T2> action) => eventBus.Unsubscribe(new ActionHandler<T1, T2>(new GenericDelegate<Action<T1, T2>>(action)));
        public static bool Unsubscribe<T1, T2, T3>(this IEventBus eventBus, Action<T1, T2, T3> action) => eventBus.Unsubscribe(new ActionHandler<T1, T2, T3>(new GenericDelegate<Action<T1, T2, T3>>(action)));
        public static bool Unsubscribe<T1, T2, T3, T4>(this IEventBus eventBus, Action<T1, T2, T3, T4> action) => eventBus.Unsubscribe(new ActionHandler<T1, T2, T3, T4>(new GenericDelegate<Action<T1, T2, T3, T4>>(action)));
        public static bool Unsubscribe<T1, T2, T3, T4, T5>(this IEventBus eventBus, Action<T1, T2, T3, T4, T5> action) => eventBus.Unsubscribe(new ActionHandler<T1, T2, T3, T4, T5>(new GenericDelegate<Action<T1, T2, T3, T4, T5>>(action)));
        
        public static void Publish<T>(this IEventBus eventBus, T param) => eventBus.Publish(new ParameterNotification<T>(param));
        public static void Publish<T1, T2>(this IEventBus eventBus, T1 param1, T2 param2) => eventBus.Publish(new ParameterNotification<T1, T2>(param1, param2));
        public static void Publish<T1, T2, T3>(this IEventBus eventBus, T1 param1, T2 param2, T3 param3) => eventBus.Publish(new ParameterNotification<T1, T2, T3>(param1, param2, param3));
        public static void Publish<T1, T2, T3, T4>(this IEventBus eventBus, T1 param1, T2 param2, T3 param3, T4 param4) => eventBus.Publish(new ParameterNotification<T1, T2, T3, T4>(param1, param2, param3, param4));
        public static void Publish<T1, T2, T3, T4, T5>(this IEventBus eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5) => eventBus.Publish(new ParameterNotification<T1, T2, T3, T4, T5>(param1, param2, param3, param4, param5));


        public static void Subscribe(this IEventBus<ActionHandler,ParameterNotification> eventBus, Action action)
            => eventBus.Subscribe(new ActionHandler(new GenericDelegate<Action>(action)));
        public static void Subscribe<T>(this IEventBus<ActionHandler<T>, ParameterNotification<T>> eventBus, Action<T> action)
            => eventBus.Subscribe(new ActionHandler<T>(new GenericDelegate<Action<T>>(action)));

        public static void Subscribe<T1, T2>(this IEventBus<ActionHandler<T1, T2>, ParameterNotification<T1, T2>> eventBus, Action<T1, T2> action)
            => eventBus.Subscribe(new ActionHandler<T1, T2>(new GenericDelegate<Action<T1, T2>>(action)));

        public static void Subscribe<T1, T2, T3>(this IEventBus<ActionHandler<T1, T2, T3>, ParameterNotification<T1, T2, T3>> eventBus, Action<T1, T2, T3> action)
            => eventBus.Subscribe(new ActionHandler<T1, T2, T3>(new GenericDelegate<Action<T1, T2, T3>>(action)));

        public static void Subscribe<T1, T2, T3, T4>(this IEventBus<ActionHandler<T1, T2, T3, T4>, ParameterNotification<T1, T2, T3, T4>> eventBus, Action<T1, T2, T3, T4> action)
            => eventBus.Subscribe(new ActionHandler<T1, T2, T3, T4>(new GenericDelegate<Action<T1, T2, T3, T4>>(action)));

        public static void Subscribe<T1, T2, T3, T4, T5>(this IEventBus<ActionHandler<T1, T2, T3, T4, T5>, ParameterNotification<T1, T2, T3, T4, T5>> eventBus, Action<T1, T2, T3, T4, T5> action)
            => eventBus.Subscribe(new ActionHandler<T1, T2, T3, T4, T5>(new GenericDelegate<Action<T1, T2, T3, T4, T5>>(action)));


        public static bool Unsubscribe(this IEventBus<ActionHandler,ParameterNotification> eventBus, Action action)
            => eventBus.Unsubscribe(new ActionHandler(new GenericDelegate<Action>(action)));

        public static bool Unsubscribe<T>(this IEventBus<ActionHandler<T>, ParameterNotification<T>> eventBus, Action<T> action)
            => eventBus.Unsubscribe(new ActionHandler<T>(new GenericDelegate<Action<T>>(action)));

        public static bool Unsubscribe<T1, T2>(this IEventBus<ActionHandler<T1, T2>, ParameterNotification<T1, T2>> eventBus, Action<T1, T2> action)
            => eventBus.Unsubscribe(new ActionHandler<T1, T2>(new GenericDelegate<Action<T1, T2>>(action)));

        public static bool Unsubscribe<T1, T2, T3>(this IEventBus<ActionHandler<T1, T2, T3>, ParameterNotification<T1, T2, T3>> eventBus, Action<T1, T2, T3> action)
            => eventBus.Unsubscribe(new ActionHandler<T1, T2, T3>(new GenericDelegate<Action<T1, T2, T3>>(action)));

        public static bool Unsubscribe<T1, T2, T3, T4>(this IEventBus<ActionHandler<T1, T2, T3, T4>, ParameterNotification<T1, T2, T3, T4>> eventBus, Action<T1, T2, T3, T4> action)
            => eventBus.Unsubscribe(new ActionHandler<T1, T2, T3, T4>(new GenericDelegate<Action<T1, T2, T3, T4>>(action)));

        public static bool Unsubscribe<T1, T2, T3, T4, T5>(this IEventBus<ActionHandler<T1, T2, T3, T4, T5>, ParameterNotification<T1, T2, T3, T4, T5>> eventBus, Action<T1, T2, T3, T4, T5> action)
            => eventBus.Unsubscribe(new ActionHandler<T1, T2, T3, T4, T5>(new GenericDelegate<Action<T1, T2, T3, T4, T5>>(action)));


        public static void Publish<T>(this IEventBus<ActionHandler<T>, ParameterNotification<T>> eventBus, T param)
            => eventBus.Publish(new ParameterNotification<T>(param));

        public static void Publish<T1, T2>(this IEventBus<ActionHandler<T1, T2>, ParameterNotification<T1, T2>> eventBus, T1 param1, T2 param2)
            => eventBus.Publish(new ParameterNotification<T1, T2>(param1, param2));

        public static void Publish<T1, T2, T3>(this IEventBus<ActionHandler<T1, T2, T3>, ParameterNotification<T1, T2, T3>> eventBus, T1 param1, T2 param2, T3 param3)
            => eventBus.Publish(new ParameterNotification<T1, T2, T3>(param1, param2, param3));

        public static void Publish<T1, T2, T3, T4>(this IEventBus<ActionHandler<T1, T2, T3, T4>, ParameterNotification<T1, T2, T3, T4>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4)
            => eventBus.Publish(new ParameterNotification<T1, T2, T3, T4>(param1, param2, param3, param4));

        public static void Publish<T1, T2, T3, T4, T5>(this IEventBus<ActionHandler<T1, T2, T3, T4, T5>, ParameterNotification<T1, T2, T3, T4, T5>> eventBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
            => eventBus.Publish(new ParameterNotification<T1, T2, T3, T4, T5>(param1, param2, param3, param4, param5));
        #endregion
    }
}