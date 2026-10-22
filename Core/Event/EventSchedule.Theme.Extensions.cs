/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/06 17:12:55
 */

using System;

namespace PeroTools2.AccessKing;

/// <summary>
/// Extensions for <see cref="EventSchedule{TTheme}"/>
/// </summary>
public static class EventScheduleExtensions
{
    /// <summary>
    /// Required event bus from the schedule with <c>TEventBus</c> theme. If it never been registered, it will create a new one.
    /// </summary>
    /// <returns>Access bus for the corresponding topic.</returns>
    /// <exception cref="InvalidCastException">Throw out when the required type cannot match the first registered bus type.</exception>
    public static TEventBus Require<TEventBus>(this IEventSchedule<Type> schedule) where TEventBus : new()
    {
        if (schedule.TryGetBus(typeof(TEventBus), out var bus)) return (TEventBus) bus;

        var result = new TEventBus();
        schedule.AddBus(typeof(TEventBus), result);
        return result;
    }
}