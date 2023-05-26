using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public interface ICommandHandlerFactory
    {
        IReadOnlyList<ICommandHandler<TNotification>> RequireExecutives<TNotification>() where TNotification : INotification;
    }
}