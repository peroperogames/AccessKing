using UnityEngine.Playables;

namespace PeroTools2.AccessKing
{
    public interface ICommandHandler<in TNotification> where TNotification : INotification
    {
        void Handle(TNotification notification);
    }

    public interface ICommandHandler<in TNotification, out TResult> : ICommandHandler<TNotification>, IResultAvailable<TResult> where TNotification : INotification
    {
        
    }
}