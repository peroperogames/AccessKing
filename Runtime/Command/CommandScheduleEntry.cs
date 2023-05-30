using System.Collections;
using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    internal class CommandScheduleEntry : IEnumerable<IAccessBus>
    {
        private readonly List<IAccessBus> m_Buses = new List<IAccessBus>();

        internal void Add(IAccessBus accessBus)
        {
            m_Buses.Add(accessBus);
        }

        internal IEnumerable<IAccessBus> GetAllAccessBus() => m_Buses;

        public ICommandBus<TNotification, TOperation> GetBus<TNotification, TOperation>() where TNotification : INotification where TOperation : ICommandOperation
        {
            for (var index = 0; index < m_Buses.Count; index++)
            {
                if (m_Buses[index] is ICommandBus<TNotification, TOperation> bus)
                {
                    return bus;
                }
            }

            return default;
        }

        public IEnumerator<IAccessBus> GetEnumerator() => m_Buses.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}