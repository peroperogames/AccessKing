using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public interface ICommandExecutiveFactory
    {
        IEnumerable<ICommandExecutive<TNotification>> RequireExecutives<TNotification>() where TNotification : INotification;
    }
}