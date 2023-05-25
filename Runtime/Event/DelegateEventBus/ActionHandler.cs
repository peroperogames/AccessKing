using System;

namespace PeroTools2.AccessKing
{
    public sealed class ActionHandler : IEventHandler
    {
        internal readonly IDelegate<Action> invocation;
        public ActionHandler(IDelegate<Action> delegation) => invocation = delegation;
        public void Clear() => invocation.Clear();
        public void Handle() => invocation.delegation?.Invoke();
    }

    public sealed class ActionHandler<T> : IEventHandler<ParameterNotification<T>>
    {
        internal readonly IDelegate<Action<T>> invocation;
        public ActionHandler(IDelegate<Action<T>> delegation) => invocation = delegation;
        public void Clear() => invocation.Clear();
        public void Handle(T param) => invocation.delegation?.Invoke(param);
        void IEventHandler<ParameterNotification<T>>.Handle(in ParameterNotification<T> notification) => Handle(notification.item);
    }

    public sealed class ActionHandler<T1, T2> : IEventHandler<ParameterNotification<T1, T2>>
    {
        internal readonly IDelegate<Action<T1, T2>> invocation;
        public ActionHandler(IDelegate<Action<T1, T2>> delegation) => invocation = delegation;
        public void Clear() => invocation.Clear();
        public void Handle(T1 param1, T2 param2) => invocation.delegation?.Invoke(param1, param2);
        void IEventHandler<ParameterNotification<T1, T2>>.Handle(in ParameterNotification<T1, T2> notification) => Handle(notification.item1, notification.item2);
    }

    public sealed class ActionHandler<T1, T2, T3> : IEventHandler<ParameterNotification<T1, T2, T3>>
    {
        internal readonly IDelegate<Action<T1, T2, T3>> invocation;
        public ActionHandler(IDelegate<Action<T1, T2, T3>> delegation) => invocation = delegation;
        public void Clear() => invocation.Clear();
        public void Handle(T1 param1, T2 param2, T3 param3) => invocation.delegation?.Invoke(param1, param2, param3);
        void IEventHandler<ParameterNotification<T1, T2, T3>>.Handle(in ParameterNotification<T1, T2, T3> notification) => Handle(notification.item1, notification.item2, notification.item3);
    }

    public sealed class ActionHandler<T1, T2, T3, T4> : IEventHandler<ParameterNotification<T1, T2, T3, T4>>
    {
        internal readonly IDelegate<Action<T1, T2, T3, T4>> invocation;
        public ActionHandler(IDelegate<Action<T1, T2, T3, T4>> delegation) => invocation = delegation;
        public void Clear() => invocation.Clear();
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4) => invocation.delegation?.Invoke(param1, param2, param3, param4);
        void IEventHandler<ParameterNotification<T1, T2, T3, T4>>.Handle(in ParameterNotification<T1, T2, T3, T4> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4);
    }

    public sealed class ActionHandler<T1, T2, T3, T4, T5> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5>>
    {
        internal readonly IDelegate<Action<T1, T2, T3, T4, T5>> invocation;
        public ActionHandler(IDelegate<Action<T1, T2, T3, T4, T5>> delegation) => invocation = delegation;
        public void Clear() => invocation.Clear();
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5) => invocation.delegation?.Invoke(param1, param2, param3, param4, param5);
        void IEventHandler<ParameterNotification<T1, T2, T3, T4, T5>>.Handle(in ParameterNotification<T1, T2, T3, T4, T5> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5);
    }
}