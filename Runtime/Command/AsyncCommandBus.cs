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
                if (executive is ICommandHandler<TNotification> nonResultHandler)
                {
                    nonResultHandler.Handle(notification);
                    list.Add(Task.CompletedTask);
                }
                else if (executive is ITaskCommandHandler<TNotification, Task> taskHandler)
                    list.Add(taskHandler.Handle(notification));
                else if (executive is ICommandHandler<TNotification, object> resultHandler)
                    list.Add(Task.FromResult(resultHandler.Handle(notification)));
                else if (executive is ICommandHandler<TNotification, int> intResultHandler)
                    list.Add(Task.FromResult(intResultHandler.Handle(notification)));
                else if (executive is ICommandHandler<TNotification, short> shortResultHandler)
                    list.Add(Task.FromResult(shortResultHandler.Handle(notification)));
                else if (executive is ICommandHandler<TNotification, byte> byteResultHandler)
                    list.Add(Task.FromResult(byteResultHandler.Handle(notification)));
                else if (executive is ICommandHandler<TNotification, long> longResultHandler)
                    list.Add(Task.FromResult(longResultHandler.Handle(notification)));
                else if (executive is ICommandHandler<TNotification, uint> uintResultHandler)
                    list.Add(Task.FromResult(uintResultHandler.Handle(notification)));
                else if (executive is ICommandHandler<TNotification, ushort> ushortResultHandler)
                    list.Add(Task.FromResult(ushortResultHandler.Handle(notification)));
                else if (executive is ICommandHandler<TNotification, ulong> ulongResultHandler)
                    list.Add(Task.FromResult(ulongResultHandler.Handle(notification)));
                else if (executive is ICommandHandler<TNotification, sbyte> sbyteResultHandler)
                    list.Add(Task.FromResult(sbyteResultHandler.Handle(notification)));
                else if (executive is ICommandHandler<TNotification, float> floatResultHandler)
                    list.Add(Task.FromResult(floatResultHandler.Handle(notification)));
                else if (executive is ICommandHandler<TNotification, double> doubleResultHandler)
                    list.Add(Task.FromResult(doubleResultHandler.Handle(notification)));
                else if (executive is ICommandHandler<TNotification, decimal> decimalResultHandler)
                    list.Add(Task.FromResult(decimalResultHandler.Handle(notification)));
                else
                {
                    list.Add(Task.FromResult(executive.GetHandleMethod().Invoke(executive, new object[] {notification})));
                }
            }
            return new AsyncCommandResult(list);
        }
    }
}