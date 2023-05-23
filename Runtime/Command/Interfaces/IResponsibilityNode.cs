namespace PeroTools2.AccessKing
{
    public interface IResponsibilityNode
    {
        bool canHandle { get; }
        IResponsibilityNode nextHandler { get; }
        void Handle();
    }
}