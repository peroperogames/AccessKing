using System.Collections;

namespace PeroTools2.AccessKing
{
    public class SyncCommandBus : ICommandBus, ICommandBus<SyncCommandResult>
    {
        private readonly ICommandExecutiveFactory m_HandlerFactory;

        public SyncCommandBus(ICommandExecutiveFactory handlerFactory) => m_HandlerFactory = handlerFactory;

        void IAccessBus.Dispatch(INotification notification) => Execute(notification);

        ICommandResult ICommandBus.Execute<TNotification>(TNotification notification) => Execute(notification);

        public SyncCommandResult Execute<TNotification>(TNotification notification) where TNotification : INotification
        {
            var executives = m_HandlerFactory.RequireExecutives<TNotification>();
            var list = ObjectPool<ArrayList>.Require();
            foreach (var executive in executives)
            {
                var result = executive.TryHandle(notification);
                list.Add(result);
            }
            return new SyncCommandResult(list);
        }
    }
}