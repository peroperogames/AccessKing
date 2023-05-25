using System;

namespace PeroTools2.AccessKing
{
    public class DelegateEventBus : ParameterEventBus<ActionHandler>, IDelegateEventBus
    {
        private readonly ActionHandler m_Handler;
        public DelegateEventBus() => m_Handler = new ActionHandler(new GenericDelegate<Action>());
        public DelegateEventBus(IDelegate<Action> invocation) => m_Handler = new ActionHandler(invocation);
        protected override void Subscribe(ActionHandler eventHandler) => Subscribe(eventHandler.invocation.delegation);
        protected override bool Unsubscribe(ActionHandler eventHandler) => Unsubscribe(eventHandler.invocation.delegation);
        public void Subscribe(Action action) => m_Handler.invocation.Add(action);
        public bool Unsubscribe(Action action) => m_Handler.invocation.Remove(action);
        public override void Publish() => m_Handler.Handle();
        public override void Clear() => m_Handler.Clear();
    }

    public class DelegateEventBus<T> : ParameterEventBus<ActionHandler<T>, T>, IDelegateEventBus<T>
    {
        private readonly ActionHandler<T> m_Handler;
        public DelegateEventBus() => m_Handler = new ActionHandler<T>(new GenericDelegate<Action<T>>());
        public DelegateEventBus(IDelegate<Action<T>> invocation) => m_Handler = new ActionHandler<T>(invocation);
        protected override void Subscribe(ActionHandler<T> eventHandler) => Subscribe(eventHandler.invocation.delegation);
        protected override bool Unsubscribe(ActionHandler<T> eventHandler) => Unsubscribe(eventHandler.invocation.delegation);
        public void Subscribe(Action<T> action) => m_Handler.invocation.Add(action);
        public bool Unsubscribe(Action<T> action) => m_Handler.invocation.Remove(action);
        public override void Publish(T param) => m_Handler.Handle(param);
        public override void Clear() => m_Handler.Clear();
    }

    public class DelegateEventBus<T1, T2> : ParameterEventBus<ActionHandler<T1, T2>, T1, T2>, IDelegateEventBus<T1, T2>
    {
        private readonly ActionHandler<T1, T2> m_Handler;
        public DelegateEventBus() => m_Handler = new ActionHandler<T1, T2>(new GenericDelegate<Action<T1, T2>>());
        public DelegateEventBus(IDelegate<Action<T1, T2>> invocation) => m_Handler = new ActionHandler<T1, T2>(invocation);
        protected override void Subscribe(ActionHandler<T1, T2> eventHandler) => Subscribe(eventHandler.invocation.delegation);
        protected override bool Unsubscribe(ActionHandler<T1, T2> eventHandler) => Unsubscribe(eventHandler.invocation.delegation);
        public void Subscribe(Action<T1, T2> action) => m_Handler.invocation.Add(action);
        public bool Unsubscribe(Action<T1, T2> action) => m_Handler.invocation.Remove(action);
        public override void Publish(T1 param1, T2 param2) => m_Handler.Handle(param1, param2);
        public override void Clear() => m_Handler.Clear();
    }

    public class DelegateEventBus<T1, T2, T3> : ParameterEventBus<ActionHandler<T1, T2, T3>, T1, T2, T3>, IDelegateEventBus<T1, T2, T3>
    {
        private readonly ActionHandler<T1, T2, T3> m_Handler;
        public DelegateEventBus() => m_Handler = new ActionHandler<T1, T2, T3>(new GenericDelegate<Action<T1, T2, T3>>());
        public DelegateEventBus(IDelegate<Action<T1, T2, T3>> invocation) => m_Handler = new ActionHandler<T1, T2, T3>(invocation);
        protected override void Subscribe(ActionHandler<T1, T2, T3> eventHandler) => Subscribe(eventHandler.invocation.delegation);
        protected override bool Unsubscribe(ActionHandler<T1, T2, T3> eventHandler) => Unsubscribe(eventHandler.invocation.delegation);
        public void Subscribe(Action<T1, T2, T3> action) => m_Handler.invocation.Add(action);
        public bool Unsubscribe(Action<T1, T2, T3> action) => m_Handler.invocation.Remove(action);
        public override void Publish(T1 param1, T2 param2, T3 param3) => m_Handler.Handle(param1, param2, param3);
        public override void Clear() => m_Handler.Clear();
    }

    public class DelegateEventBus<T1, T2, T3, T4> : ParameterEventBus<ActionHandler<T1, T2, T3, T4>, T1, T2, T3, T4>, IDelegateEventBus<T1, T2, T3, T4>
    {
        private readonly ActionHandler<T1, T2, T3, T4> m_Handler;
        public DelegateEventBus() => m_Handler = new ActionHandler<T1, T2, T3, T4>(new GenericDelegate<Action<T1, T2, T3, T4>>());
        public DelegateEventBus(IDelegate<Action<T1, T2, T3, T4>> invocation) => m_Handler = new ActionHandler<T1, T2, T3, T4>(invocation);
        protected override void Subscribe(ActionHandler<T1, T2, T3, T4> eventHandler) => Subscribe(eventHandler.invocation.delegation);
        protected override bool Unsubscribe(ActionHandler<T1, T2, T3, T4> eventHandler) => Unsubscribe(eventHandler.invocation.delegation);
        public void Subscribe(Action<T1, T2, T3, T4> action) => m_Handler.invocation.Add(action);
        public bool Unsubscribe(Action<T1, T2, T3, T4> action) => m_Handler.invocation.Remove(action);
        public override void Publish(T1 param1, T2 param2, T3 param3, T4 param4) => m_Handler.Handle(param1, param2, param3, param4);
        public override void Clear() => m_Handler.Clear();
    }

    public class DelegateEventBus<T1, T2, T3, T4, T5> : ParameterEventBus<ActionHandler<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>, IDelegateEventBus<T1, T2, T3, T4, T5>
    {
        private readonly ActionHandler<T1, T2, T3, T4, T5> m_Handler;
        public DelegateEventBus() => m_Handler = new ActionHandler<T1, T2, T3, T4, T5>(new GenericDelegate<Action<T1, T2, T3, T4, T5>>());
        public DelegateEventBus(IDelegate<Action<T1, T2, T3, T4, T5>> invocation) => m_Handler = new ActionHandler<T1, T2, T3, T4, T5>(invocation);
        protected override void Subscribe(ActionHandler<T1, T2, T3, T4, T5> eventHandler) => Subscribe(eventHandler.invocation.delegation);
        protected override bool Unsubscribe(ActionHandler<T1, T2, T3, T4, T5> eventHandler) => Unsubscribe(eventHandler.invocation.delegation);
        public void Subscribe(Action<T1, T2, T3, T4, T5> action) => m_Handler.invocation.Add(action);
        public bool Unsubscribe(Action<T1, T2, T3, T4, T5> action) => m_Handler.invocation.Remove(action);
        public override void Publish(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5) => m_Handler.Handle(param1, param2, param3, param4, param5);
        public override void Clear() => m_Handler.Clear();
    }
}