namespace PeroTools2.AccessKing
{
    public interface IResultAvailable
    {
        object GetResult();
    }
    public interface IResultAvailable<out TResult> : IResultAvailable
    {
        TResult GetResult();
    }
}