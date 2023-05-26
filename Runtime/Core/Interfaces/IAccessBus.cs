namespace PeroTools2.AccessKing
{
    public interface IAccessBus
    {
        public void Dispatch(INotification notification);
    }
}