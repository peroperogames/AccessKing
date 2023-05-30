namespace PeroTools2.AccessKing
{
    public class SyncParameterCommandBus : SyncCommandBus<ParameterNotification>
    {
        public SyncParameterCommandBus(ICommandHandlerFactory factory) : base(factory) { }
    }
    public class SyncParameterCommandBus<T> : SyncCommandBus<ParameterNotification<T>>
    {
        public SyncParameterCommandBus(ICommandHandlerFactory factory) : base(factory) { }
    }
    public class SyncParameterCommandBus<T1,T2> : SyncCommandBus<ParameterNotification<T1,T2>>
    {
        public SyncParameterCommandBus(ICommandHandlerFactory factory) : base(factory) { }
    }
    public class SyncParameterCommandBus<T1,T2,T3> : SyncCommandBus<ParameterNotification<T1,T2,T3>>
    {
        public SyncParameterCommandBus(ICommandHandlerFactory factory) : base(factory) { }
    }
    public class SyncParameterCommandBus<T1,T2,T3,T4> : SyncCommandBus<ParameterNotification<T1,T2,T3,T4>>
    {
        public SyncParameterCommandBus(ICommandHandlerFactory factory) : base(factory) { }
    }
    public class SyncParameterCommandBus<T1,T2,T3,T4,T5> : SyncCommandBus<ParameterNotification<T1,T2,T3,T4,T5>>
    {
        public SyncParameterCommandBus(ICommandHandlerFactory factory) : base(factory) { }
    }
}