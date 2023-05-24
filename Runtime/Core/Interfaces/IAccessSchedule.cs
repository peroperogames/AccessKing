namespace PeroTools2.AccessKing
{
    public interface IAccessSchedule<out TAccessBus,in TTheme> where TAccessBus : IAccessBus
    {
        TAccessBus this[TTheme theme] { get; }
    }
}