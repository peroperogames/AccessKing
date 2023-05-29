namespace PeroTools2.AccessKing
{
    public interface IAccessBus
    {
        void Dispatch(INotification notification);
    }
}