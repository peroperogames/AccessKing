/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/26 15:05:25
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace PeroTools2.AccessKing;

/// <summary>
/// Default event schedule implementation.
/// </summary>
/// <typeparam name="TTheme">Theme of the event bus</typeparam>
public partial class EventSchedule<TTheme> : IEventSchedule<TTheme>
{
    /// <summary>
    /// Theme to event bus mapping.
    /// </summary>
    private readonly Dictionary<TTheme, object> m_EventBusMaps = [];

    /// <inheritdoc cref="IAccessSchedule{TTheme}.busCount"/>
    public int busCount => m_EventBusMaps.Count;

    /// <inheritdoc cref="IAccessSchedule{TTheme}.RemoveBus(TTheme)"/>
    public bool RemoveBus(TTheme theme) => m_EventBusMaps.Remove(theme);

    bool IAccessSchedule<TTheme>.RemoveBus(object bus)
    {
        var pair = m_EventBusMaps.FirstOrDefault(pair => pair.Value == bus);
        return pair.Value is not null && m_EventBusMaps.Remove(pair.Key);
    }

    /// <inheritdoc cref="IEventSchedule{TTheme}.RemoveBus{TNotification}(IEventBus{TNotification})"/>
    public bool RemoveBus<TNotification>(IEventBus<TNotification> bus) where TNotification : INotification => ((IAccessSchedule<TTheme>) this).RemoveBus(bus);

    /// <inheritdoc cref="IAccessSchedule{TTheme}.ContainsBus(TTheme)"/>
    public bool ContainsBus(TTheme theme) => m_EventBusMaps.ContainsKey(theme);

    /// <inheritdoc cref="IAccessSchedule{TTheme}.Clear()"/>
    public void Clear() => m_EventBusMaps.Clear();

    /// <inheritdoc cref="IEventSchedule{TTheme}.GetBus{TNotification}(TTheme)"/>
    public IEventBus<TNotification> GetBus<TNotification>(TTheme theme) where TNotification : INotification
        => m_EventBusMaps.TryGetValue(theme, out var bus)
            ? (IEventBus<TNotification>) bus
            : throw new ArgumentException($"Non existing theme: {theme}");

    /// <inheritdoc cref="IAccessSchedule{TTheme}.GetBus(TTheme)"/>
    object IAccessSchedule<TTheme>.GetBus(TTheme theme)
        => m_EventBusMaps.TryGetValue(theme, out var bus)
            ? bus
            : throw new ArgumentException($"Non existing theme: {theme}");

    /// <inheritdoc cref="IEventSchedule{TTheme}.TryGetBus{TNotification}(TTheme, out IEventBus{TNotification})"/>
    public bool TryGetBus<TNotification>(TTheme theme, out IEventBus<TNotification> bus) where TNotification : INotification
    {
        if (m_EventBusMaps.TryGetValue(theme, out var accessBus) && accessBus is IEventBus<TNotification> eventBus)
        {
            bus = eventBus;
            return true;
        }

        bus = null;
        return false;
    }

    /// <inheritdoc cref="IAccessSchedule{TTheme}.TryGetBus(TTheme, out object)"/>
    bool IAccessSchedule<TTheme>.TryGetBus(TTheme theme, out object bus) => m_EventBusMaps.TryGetValue(theme, out bus);

    /// <inheritdoc cref="IAccessSchedule{TTheme}.AddBus(TTheme, object)"/>
    /// <exception cref="ArgumentException">Throw when the bus can't assign to <see cref="IEventBus{TNotification}"/> type.</exception>
    void IAccessSchedule<TTheme>.AddBus(TTheme theme, object bus)
    {
        if (bus is null) throw new ArgumentNullException(nameof(bus));

        // ReSharper disable once UseIsOperator.2
        // Check whether implements IEventBus<>
        if (!bus.GetType().GetInterfaces().Any(static @interface =>
                @interface.IsGenericType &&
                @interface.GetGenericTypeDefinition() == typeof(IEventBus<>)))
        {
            throw new ArgumentException($"The bus must be an instance of {typeof(IEventBus<>)} type. Bus type: {bus.GetType()}.");
        }

        if (!m_EventBusMaps.TryAdd(theme, bus))
        {
            throw new ArgumentException($"Duplicate theme: {theme}");
        }
    }

    /// <inheritdoc cref="IEventSchedule{TTheme}.AddBus{TNotification}(TTheme, IEventBus{TNotification})"/>
    public void AddBus<TNotification>(TTheme theme, IEventBus<TNotification> bus) where TNotification : INotification
    {
        if (!m_EventBusMaps.TryAdd(theme, bus))
        {
            throw new ArgumentException($"Duplicate theme: {theme}");
        }
    }
}