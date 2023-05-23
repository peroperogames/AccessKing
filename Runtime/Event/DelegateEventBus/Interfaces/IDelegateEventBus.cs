using System;

namespace PeroTools2.AccessKing
{
    public interface IDelegateEventBus : IParameterEventBus<ActionHandler>
    {
        void Subscribe(Action action);
        bool Unsubscribe(Action action);
    }

    public interface IDelegateEventBus<T> : IParameterEventBus<ActionHandler<T>, T>
    {
        void Subscribe(Action<T> action);
        bool Unsubscribe(Action<T> action);
    }

    public interface IDelegateEventBus<T1, T2> : IParameterEventBus<ActionHandler<T1, T2>, T1, T2>
    {
        void Subscribe(Action<T1, T2> action);
        bool Unsubscribe(Action<T1, T2> action);
    }

    public interface IDelegateEventBus<T1, T2, T3> : IParameterEventBus<ActionHandler<T1, T2, T3>, T1, T2, T3>
    {
        void Subscribe(Action<T1, T2, T3> action);
        bool Unsubscribe(Action<T1, T2, T3> action);
    }

    public interface IDelegateEventBus<T1, T2, T3, T4> : IParameterEventBus<ActionHandler<T1, T2, T3, T4>, T1, T2, T3, T4>
    {
        void Subscribe(Action<T1, T2, T3, T4> action);
        bool Unsubscribe(Action<T1, T2, T3, T4> action);
    }

    public interface IDelegateEventBus<T1, T2, T3, T4, T5> : IParameterEventBus<ActionHandler<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>
    {
        void Subscribe(Action<T1, T2, T3, T4, T5> action);
        bool Unsubscribe(Action<T1, T2, T3, T4, T5> action);
    }
}