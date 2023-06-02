using System;

namespace PeroTools2.AccessKing
{
    public static class AccessExtensions
    {
        /// <summary>
        /// Required access bus from the schedule. If it never been registered, it will create a new one.
        /// </summary>
        /// <typeparam name="TBus">Access bus with a public parameterless constructor.</typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException">Throw out when the required type cannot match the first registered bus type.</exception>
        public static TBus Require<TBus>(this IAccessSchedule<Type> schedule) where TBus : IAccessBus, new()
        {
            if (!schedule.TryGetBus(typeof(TBus), out var bus))
            {
                bus = new TBus();
                schedule.AddBus(typeof(TBus), bus);
            }

            if (bus is TBus result)
                return result;
            throw new InvalidCastException($"The access bus is not {typeof(TBus)} type.");
        }
    }
}