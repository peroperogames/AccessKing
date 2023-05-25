using System.Collections.Generic;
using UnityEngine.Assertions;

namespace PeroTools2.AccessKing
{
    public class EventSchedule<TTheme> : IEventSchedule<TTheme>
    {
        private readonly Dictionary<TTheme, IEventBus> m_EventBusMaps = new Dictionary<TTheme, IEventBus>();

        public IEventBus this[TTheme theme]
        {
            get
            {
                if (!m_EventBusMaps.TryGetValue(theme, out var eventBus))
                {
                    eventBus = new SyncEventBus();
                    m_EventBusMaps.Add(theme, eventBus);
                }

                return eventBus;
            }
            set
            {
                Assert.IsNotNull(value);
                m_EventBusMaps[theme] = value;
            }
        }

        public bool ContainsBus(TTheme theme) => m_EventBusMaps.ContainsKey(theme);
        public bool TryGetBus(TTheme theme, out IEventBus eventBus) => m_EventBusMaps.TryGetValue(theme, out eventBus);
        public bool RemoveTheme(TTheme theme) => m_EventBusMaps.Remove(theme);
    }
}