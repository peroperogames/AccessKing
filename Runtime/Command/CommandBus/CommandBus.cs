namespace PeroTools2.AccessKing
{
    public abstract class CommandBus<TNotification, TOperation> : ICommandBus<TNotification, TOperation>, IAccessBus
        where TNotification : INotification
        where TOperation : ICommandOperation
    {
        private readonly ICommandHandlerFactory m_HandlerFactory;
        ICommandHandlerFactory ICommandBus.handlerFactory => m_HandlerFactory;

        public CommandBus(ICommandHandlerFactory factory) => m_HandlerFactory = factory;


        void IAccessBus.Dispatch(INotification notification)
        {
            if (m_HandlerFactory == null)
                return;
            if (notification is TNotification tNotification)
                Execute(tNotification);
            else
                ThrowHelper.ThrowWhenNotificationCastFailed<TNotification>(notification);
        }

        public TOperation Execute(TNotification notification) => Execute(m_HandlerFactory, notification);
        protected abstract TOperation Execute(ICommandHandlerFactory handlerFactory, TNotification notification);
    }

    public class CommandBusTest
    {
        public void Test(CommandSchedule<string> schedule)
        {
            var operation = schedule.RequireWithParams<int, SyncCommandOperation>("GetAllCharacterInfo").Execute(4);
            var playerInfos = operation.GetResults<PlayerInfo>();
            var monsterInfos = operation.GetResults<MonsterInfo>();
        }
    }

    public class PlayerInfo
    {
        public string Name { get; }
    }

    public class Player : ICommandHandler<ParameterNotification<int>, PlayerInfo>
    {
        public void Handle(ParameterNotification<int> notification)
        {
        }

        public PlayerInfo GetResult()
        {
            return new PlayerInfo();
        }

        object IResultAvailable.GetResult()
        {
            return GetResult();
        }
    }

    public class MonsterInfo
    {
        public string Name { get; }
    }

    public class Monster : ICommandHandler<ParameterNotification<int>, MonsterInfo>
    {
        public void Handle(ParameterNotification<int> notification)
        {
        }

        public MonsterInfo GetResult()
        {
            return new MonsterInfo();
        }

        object IResultAvailable.GetResult()
        {
            return GetResult();
        }
    }
}