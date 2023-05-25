namespace PeroTools2.AccessKing
{
    public interface IEventSchedule<in TTheme> : IAccessSchedule<IEventBus, TTheme>
    {
        IEventBus this[TTheme theme] { get; set; }

        bool ContainsBus(TTheme theme);
        bool TryGetBus(TTheme theme, out IEventBus eventBus);

        bool RemoveTheme(TTheme theme);
    }
}