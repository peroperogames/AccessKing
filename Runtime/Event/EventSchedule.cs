using System.Collections.Generic;
using PeroTools2.AccessKing;

namespace Event
{
    public class EventSchedule<TEventHandler,TTheme> where TEventHandler : IEventObserver
    {
        private Dictionary<TTheme, IAccessBus> m_EventBusMaps = new Dictionary<TTheme, IAccessBus>();
        public IEventBus<IEventObserver, TNotification> RequireBus<TNotification>(TTheme theme) where TNotification : INotification
        {
            if (m_EventBusMaps.TryGetValue(theme, out var eventBus))
            {
                //eventBus = new DelegateEventBus();
            }
            return null;
        }
    }
}