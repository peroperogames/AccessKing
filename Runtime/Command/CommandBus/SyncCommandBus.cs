using System.Collections;

namespace PeroTools2.AccessKing
{
    public class SyncCommandBus<TNotification> : CommandBus<TNotification, SyncCommandOperation> where TNotification : INotification
    {
        public SyncCommandBus(ICommandHandlerFactory factory) : base(factory)
        {
        }

        public override SyncCommandOperation Execute(ICommandHandlerFactory factory, TNotification notification)
        {
            var handlers = factory.RequireHandlers<TNotification>();
            var results = ObjectPool<ArrayList>.Require();
            foreach (var handler in handlers)
            {
                handler.Handle(notification);
                if (handler is IResultAvailable resultGetter)
                {
                    results.Add(resultGetter.GetResult());
                }
            }
            return new SyncCommandOperation(results, handlers.Count);
        }
    }
}