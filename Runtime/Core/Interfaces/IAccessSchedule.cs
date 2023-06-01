using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public interface IAccessSchedule<in TTheme> : IEnumerable<IAccessBus>
    {
        IAccessBus this[TTheme theme] { get; }

        bool TryGetBus(TTheme theme, out IAccessBus bus);

        void AddBus(TTheme theme, IAccessBus bus);

        bool RemoveTheme(TTheme theme);
    }
}