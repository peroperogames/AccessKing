using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public class AsyncCommandBus<TNotification> : CommandBus<TNotification, AsyncCommandOperation> where TNotification : INotification
    {
        public AsyncCommandBus(ICommandHandlerFactory factory) : base(factory) { }

        protected override AsyncCommandOperation Execute(ICommandHandlerFactory handlerFactory, TNotification notification)
        {
            var executives = handlerFactory.RequireHandlers<TNotification>();
            var results = ObjectPool<List<Task>>.Require();
            foreach (var handler in executives)
            {
                handler.Handle(notification);
                if (handler is IResultAvailable resultGetter)
                {
                    if (resultGetter is IResultAvailable<Task> taskResultGetter)
                    {
                        results.Add(taskResultGetter.GetResult());
                    }
                    else
                    {
                        results.Add(Task.FromResult(resultGetter.GetResult()));
                    }
                }
            }

            return new AsyncCommandOperation(results, executives.Count);
        }
    }
}