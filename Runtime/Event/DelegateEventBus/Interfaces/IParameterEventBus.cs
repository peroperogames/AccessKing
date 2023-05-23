namespace PeroTools2.AccessKing
{
    public interface IParameterEventBus<in TEventHandler> : IEventBus<TEventHandler, ParameterNotification> where TEventHandler : IEventHandler<ParameterNotification>
    {
        void Publish();
    }

    public interface IParameterEventBus<in TEventHandler, T> : IEventBus<TEventHandler, ParameterNotification<T>> where TEventHandler : IEventHandler<ParameterNotification<T>>
    {
        void Publish(T param);
    }

    public interface IParameterEventBus<in TEventHandler, T1, T2> : IEventBus<TEventHandler, ParameterNotification<T1, T2>> where TEventHandler : IEventHandler<ParameterNotification<T1, T2>>
    {
        void Publish(T1 param1, T2 param2);
    }

    public interface IParameterEventBus<in TEventHandler, T1, T2, T3> : IEventBus<TEventHandler, ParameterNotification<T1, T2, T3>> where TEventHandler : IEventHandler<ParameterNotification<T1, T2, T3>>
    {
        void Publish(T1 param1, T2 param2, T3 param3);
    }

    public interface IParameterEventBus<in TEventHandler, T1, T2, T3, T4> : IEventBus<TEventHandler, ParameterNotification<T1, T2, T3, T4>> where TEventHandler : IEventHandler<ParameterNotification<T1, T2, T3, T4>>
    {
        void Publish(T1 param1, T2 param2, T3 param3, T4 param4);
    }

    public interface IParameterEventBus<in TEventHandler, T1, T2, T3, T4, T5> : IEventBus<TEventHandler, ParameterNotification<T1, T2, T3, T4, T5>> where TEventHandler : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5>>
    {
        void Publish(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5);
    }
}