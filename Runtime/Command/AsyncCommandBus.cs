using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public class AsyncCommandBus : ICommandBus, ICommandBus<AsyncCommandResult>
    {
        private readonly ICommandExecutiveFactory m_HandlerFactory;

        public AsyncCommandBus(ICommandExecutiveFactory handlerFactory) => m_HandlerFactory = handlerFactory;

        void IAccessBus.Dispatch(INotification notification) => Execute(notification);

        ICommandResult ICommandBus.Execute<TNotification>(TNotification notification) => Execute(notification);

        public AsyncCommandResult Execute<TNotification>(TNotification notification) where TNotification : INotification
        {
            var executives = m_HandlerFactory.RequireExecutives<TNotification>();
            var list = ObjectPool<List<Task>>.Require();
            foreach (var executive in executives)
            {
                var result = executive.TryHandle(notification);
                switch (result)
                {
                    case null:
                        list.Add(Task.CompletedTask);
                        break;
                    case Task taskResult:
                        list.Add(taskResult);
                        break;
                    default:
                        list.Add(Task.FromResult(result));
                        break;
                }
            }
            return new AsyncCommandResult(list);
        }
    }
}