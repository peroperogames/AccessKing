using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public interface IAsyncCommandHandlerFactory : ICommandHandlerFactory
    {
        new IEnumerable<ITaskCommandHandler<TNotification, Task>> RequireHandlers<TNotification>() where TNotification : INotification;
    }
}