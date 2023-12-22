/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/06 17:12:29
 */

using System;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Access bus/schedule extensions.
    /// </summary>
    public static class CommandScheduleExtensions
    {
        /// <summary>
        /// Required access bus from the schedule with <c>TCommandBus</c> theme. If it never been registered, it will create a new one.
        /// </summary>
        /// <returns>Access bus for the corresponding topic.</returns>
        /// <exception cref="InvalidCastException">Throw out when the required type cannot match the first registered bus type.</exception>
        public static TCommandBus Require<TCommandBus>(this ICommandSchedule<Type> schedule) where TCommandBus : new()
        {
            if (schedule.TryGetBus(typeof(TCommandBus), out var bus)) return (TCommandBus) bus;
            var result = new TCommandBus();
            schedule.AddBus(typeof(TCommandBus), result);
            return result;
        }
    }
}