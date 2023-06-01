using System;

namespace PeroTools2.AccessKing
{
    public sealed class ActionEventHandler : IEventHandler
    {
        private readonly Action m_Invocation;
        public ActionEventHandler(Action delegation) => m_Invocation = delegation;
        public static implicit operator ActionEventHandler(Action delegation) => new ActionEventHandler(delegation);
        public void Handle() => m_Invocation?.Invoke();
        void IEventHandler<Empty>.Handle(in Empty notification) => Handle();
    }

    public sealed class ActionEventHandler<T> : IEventHandler<ParameterNotification<T>>
    {
        private readonly Action<T> m_Invocation;
        public ActionEventHandler(Action<T> delegation) => m_Invocation = delegation;
        public static implicit operator ActionEventHandler<T>(Action<T> delegation) => new ActionEventHandler<T>(delegation);
        public void Handle(T param) => m_Invocation?.Invoke(param);
        void IEventHandler<ParameterNotification<T>>.Handle(in ParameterNotification<T> notification) => Handle(notification.item);
    }

    public sealed class ActionEventHandler<T1, T2> : IEventHandler<ParameterNotification<T1, T2>>
    {
        private readonly Action<T1, T2> m_Invocation;
        public ActionEventHandler(Action<T1, T2> delegation) => m_Invocation = delegation;
        public static implicit operator ActionEventHandler<T1, T2>(Action<T1, T2> delegation) => new ActionEventHandler<T1, T2>(delegation);
        public void Handle(T1 param1, T2 param2) => m_Invocation?.Invoke(param1, param2);
        void IEventHandler<ParameterNotification<T1, T2>>.Handle(in ParameterNotification<T1, T2> notification) => Handle(notification.item1, notification.item2);
    }

    public sealed class ActionEventHandler<T1, T2, T3> : IEventHandler<ParameterNotification<T1, T2, T3>>
    {
        private readonly Action<T1, T2, T3> m_Invocation;
        public ActionEventHandler(Action<T1, T2, T3> delegation) => m_Invocation = delegation;
        public static implicit operator ActionEventHandler<T1, T2, T3>(Action<T1, T2, T3> delegation) => new ActionEventHandler<T1, T2, T3>(delegation);
        public void Handle(T1 param1, T2 param2, T3 param3) => m_Invocation?.Invoke(param1, param2, param3);
        void IEventHandler<ParameterNotification<T1, T2, T3>>.Handle(in ParameterNotification<T1, T2, T3> notification) => Handle(notification.item1, notification.item2, notification.item3);
    }

    public sealed class ActionEventHandler<T1, T2, T3, T4> : IEventHandler<ParameterNotification<T1, T2, T3, T4>>
    {
        private readonly Action<T1, T2, T3, T4> m_Invocation;
        public ActionEventHandler(Action<T1, T2, T3, T4> delegation) => m_Invocation = delegation;
        public static implicit operator ActionEventHandler<T1, T2, T3, T4>(Action<T1, T2, T3, T4> delegation) => new ActionEventHandler<T1, T2, T3, T4>(delegation);
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4) => m_Invocation?.Invoke(param1, param2, param3, param4);
        void IEventHandler<ParameterNotification<T1, T2, T3, T4>>.Handle(in ParameterNotification<T1, T2, T3, T4> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4);
    }

    public sealed class ActionEventHandler<T1, T2, T3, T4, T5> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5>>
    {
        private readonly Action<T1, T2, T3, T4, T5> m_Invocation;
        public ActionEventHandler(Action<T1, T2, T3, T4, T5> delegation) => m_Invocation = delegation;
        public static implicit operator ActionEventHandler<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> delegation) => new ActionEventHandler<T1, T2, T3, T4, T5>(delegation);
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5) => m_Invocation?.Invoke(param1, param2, param3, param4, param5);
        void IEventHandler<ParameterNotification<T1, T2, T3, T4, T5>>.Handle(in ParameterNotification<T1, T2, T3, T4, T5> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5);
    }
}