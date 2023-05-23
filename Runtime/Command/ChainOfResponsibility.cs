using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public class ChainOfResponsibility : ICommandHandlerFactory
    {
        public void AddHandler<TCommandExecutive>() where TCommandExecutive : ICommandExecutive, IResponsibilityNode
        {
            
        }
        
        public IEnumerable<ICommandHandler<TNotification>> RequireHandlers<TNotification>() where TNotification : INotification
        {
            throw new System.NotImplementedException();
        }
    }
}