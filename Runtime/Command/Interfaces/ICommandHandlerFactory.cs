using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public interface ICommandHandlerFactory
    {
        IReadOnlyList<ICommandHandler<TNotification>> RequireHandlers<TNotification>() where TNotification : INotification;
    }
}