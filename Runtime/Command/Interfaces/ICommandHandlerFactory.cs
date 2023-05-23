using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public interface ICommandHandlerFactory
    {
        IEnumerable<ICommandHandler<TNotification>> RequireHandlers<TNotification>() where TNotification : INotification;
    }
}