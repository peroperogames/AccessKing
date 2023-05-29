using System;

namespace PeroTools2.AccessKing
{
    public sealed class ActionHandler : IEventHandler
    {
        private Action m_Invocation;
        public ActionHandler(Action delegation) => m_Invocation = delegation;
        public static implicit operator ActionHandler(Action delegation) => new ActionHandler(delegation);
        public void Clear() => m_Invocation = null;
        public void Handle() => m_Invocation?.Invoke();
        void IEventHandler<ParameterNotification>.Handle(in ParameterNotification notification) => Handle();
    }

    public sealed class ActionHandler<T> : IEventHandler<ParameterNotification<T>>
    {
        private Action<T> m_Invocation;
        public ActionHandler(Action<T> delegation) => m_Invocation = delegation;
        public static implicit operator ActionHandler<T>(Action<T> delegation) => new ActionHandler<T>(delegation);
        public void Clear() => m_Invocation = null;
        public void Handle(T param) => m_Invocation?.Invoke(param);
        void IEventHandler<ParameterNotification<T>>.Handle(in ParameterNotification<T> notification) => Handle(notification.item);
    }

    public sealed class ActionHandler<T1, T2> : IEventHandler<ParameterNotification<T1, T2>>
    {
        private Action<T1, T2> m_Invocation;
        public ActionHandler(Action<T1, T2> delegation) => m_Invocation = delegation;
        public static implicit operator ActionHandler<T1, T2>(Action<T1, T2> delegation) => new ActionHandler<T1, T2>(delegation);
        public void Clear() => m_Invocation = null;
        public void Handle(T1 param1, T2 param2) => m_Invocation?.Invoke(param1, param2);
        void IEventHandler<ParameterNotification<T1, T2>>.Handle(in ParameterNotification<T1, T2> notification) => Handle(notification.item1, notification.item2);
    }

    public sealed class ActionHandler<T1, T2, T3> : IEventHandler<ParameterNotification<T1, T2, T3>>
    {
        private Action<T1, T2, T3> m_Invocation;
        public ActionHandler(Action<T1, T2, T3> delegation) => m_Invocation = delegation;
        public static implicit operator ActionHandler<T1, T2, T3>(Action<T1, T2, T3> delegation) => new ActionHandler<T1, T2, T3>(delegation);
        public void Clear() => m_Invocation = null;
        public void Handle(T1 param1, T2 param2, T3 param3) => m_Invocation?.Invoke(param1, param2, param3);
        void IEventHandler<ParameterNotification<T1, T2, T3>>.Handle(in ParameterNotification<T1, T2, T3> notification) => Handle(notification.item1, notification.item2, notification.item3);
    }

    public sealed class ActionHandler<T1, T2, T3, T4> : IEventHandler<ParameterNotification<T1, T2, T3, T4>>
    {
        private Action<T1, T2, T3, T4> m_Invocation;
        public ActionHandler(Action<T1, T2, T3, T4> delegation) => m_Invocation = delegation;
        public static implicit operator ActionHandler<T1, T2, T3, T4>(Action<T1, T2, T3, T4> delegation) => new ActionHandler<T1, T2, T3, T4>(delegation);
        public void Clear() => m_Invocation = null;
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4) => m_Invocation?.Invoke(param1, param2, param3, param4);
        void IEventHandler<ParameterNotification<T1, T2, T3, T4>>.Handle(in ParameterNotification<T1, T2, T3, T4> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4);
    }

    public sealed class ActionHandler<T1, T2, T3, T4, T5> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5>>
    {
        private Action<T1, T2, T3, T4, T5> m_Invocation;
        public ActionHandler(Action<T1, T2, T3, T4, T5> delegation) => m_Invocation = delegation;
        public static implicit operator ActionHandler<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> delegation) => new ActionHandler<T1, T2, T3, T4, T5>(delegation);
        public void Clear() => m_Invocation = null;
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5) => m_Invocation?.Invoke(param1, param2, param3, param4, param5);
        void IEventHandler<ParameterNotification<T1, T2, T3, T4, T5>>.Handle(in ParameterNotification<T1, T2, T3, T4, T5> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5);
    }
}