using System;

namespace PeroTools2.AccessKing
{
    public static class AccessExtensions
    {
        //Schedule
        public static TBus Require<TBus>(this IAccessSchedule<Type> schedule) where TBus : IAccessBus, new()
        {
            if (!schedule.TryGetBus(typeof(TBus), out var bus))
            {
                bus = new TBus();
                schedule.AddBus(typeof(TBus), bus);
            }

            return (TBus) bus;
        }
    }
}