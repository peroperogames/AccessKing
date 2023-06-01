namespace PeroTools2.AccessKing
{
    public class ParameterCommandBus : CommandBus<Empty> { }

    public class ParameterCommandBus<T> : CommandBus<ParameterNotification<T>> { }

    public class ParameterCommandBus<T1, T2> : CommandBus<ParameterNotification<T1, T2>> { }

    public class ParameterCommandBus<T1, T2, T3> : CommandBus<ParameterNotification<T1, T2, T3>> { }

    public class ParameterCommandBus<T1, T2, T3, T4> : CommandBus<ParameterNotification<T1, T2, T3, T4>> { }

    public class ParameterCommandBus<T1, T2, T3, T4, T5> : CommandBus<ParameterNotification<T1, T2, T3, T4, T5>> { }
}