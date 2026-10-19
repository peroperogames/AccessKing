/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/29 17:05:44
 */

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Default command schedule implementation.
    /// </summary>
    /// <typeparam name="TTheme">Theme of the command bus.</typeparam>
    public partial class CommandSchedule<TTheme> : ICommandSchedule<TTheme>
    {
        /// <summary>
        /// Theme to command bus mapping.
        /// </summary>
        private readonly Dictionary<TTheme, object> m_CommandBusMaps = new();

        /// <inheritdoc cref="IAccessSchedule{TTheme}.busCount"/>
        public int busCount => m_CommandBusMaps.Count;

        /// <inheritdoc cref="IAccessSchedule{TTheme}.RemoveBus(TTheme)"/>
        public bool RemoveBus(TTheme theme) => m_CommandBusMaps.Remove(theme);

        /// <inheritdoc cref="IAccessSchedule{TTheme}.RemoveBus(object)"/>
        bool IAccessSchedule<TTheme>.RemoveBus(object bus)
        {
            var pair = m_CommandBusMaps.FirstOrDefault(kv => kv.Value.Equals(bus));
            return pair.Value != null && m_CommandBusMaps.Remove(pair.Key);
        }

        /// <inheritdoc cref="ICommandSchedule{TTheme}.RemoveBus{TNotification}(ICommandBus{TNotification})"/>
        public bool RemoveBus<TNotification>(ICommandBus<TNotification> bus) where TNotification : INotification => ((IAccessSchedule<TTheme>) this).RemoveBus(bus);

        /// <inheritdoc cref="IAccessSchedule{TTheme}.ContainsBus(TTheme)"/>
        public bool ContainsBus(TTheme theme) => m_CommandBusMaps.ContainsKey(theme);

        /// <inheritdoc cref="IAccessSchedule{TTheme}.Clear()"/>
        public void Clear() => m_CommandBusMaps.Clear();

        /// <inheritdoc cref="IAccessSchedule{TTheme}.AddBus(TTheme, object)"/>
        /// <exception cref="ArgumentException">Throw when the bus can't assign to <see cref="IEventBus{TNotification}"/> type.</exception>
        void IAccessSchedule<TTheme>.AddBus(TTheme theme, object bus)
        {
            if (bus == null) throw new ArgumentNullException(nameof(bus));

            // ReSharper disable once UseIsOperator.2
            // Check whether implements ICommand<>
            if (!bus.GetType().GetInterfaces().Any(@interface =>
                    @interface.IsGenericType &&
                    @interface.GetGenericTypeDefinition() == typeof(ICommandBus<>)))
            {
                throw new ArgumentException($"The bus must be an instance of {typeof(ICommandBus<>)} type. Buse type : {bus.GetType()}.");
            }
            if (!m_CommandBusMaps.TryAdd(theme, bus))
            {
                throw new ArgumentException("Duplicate theme: " + theme);
            }
        }

        /// <inheritdoc cref="ICommandSchedule{TTheme}.AddBus{TNotification}(TTheme, ICommandBus{TNotification})"/>
        public void AddBus<TNotification>(TTheme theme, ICommandBus<TNotification> bus) where TNotification : INotification
        {
            if (!m_CommandBusMaps.TryAdd(theme, bus))
            {
                throw new ArgumentException("Duplicate theme: " + theme);
            }
        }

        /// <inheritdoc cref="IEventSchedule{TTheme}.TryGetBus(TTheme, out object)"/>
        bool IAccessSchedule<TTheme>.TryGetBus(TTheme theme, out object bus) => m_CommandBusMaps.TryGetValue(theme, out bus);

        /// <inheritdoc cref="ICommandSchedule{TTheme}.TryGetBus{TNotification}(TTheme, out ICommandBus{TNotification})"/>
        public bool TryGetBus<TNotification>(TTheme theme, out ICommandBus<TNotification> bus) where TNotification : INotification
        {
            if (m_CommandBusMaps.TryGetValue(theme, out var accessBus))
            {
                if (accessBus is ICommandBus<TNotification> commandBus)
                {
                    bus = commandBus;
                    return true;
                }
            }

            bus = null;
            return false;
        }

        /// <inheritdoc cref="IAccessSchedule{TTheme}.GetBus(TTheme)"/>
        object IAccessSchedule<TTheme>.GetBus(TTheme theme)
        {
            if (m_CommandBusMaps.TryGetValue(theme, out var bus))
            {
                return bus;
            }
            throw new ArgumentException("Non existing theme: " + theme);
        }

        /// <inheritdoc cref="ICommandSchedule{TTheme}.GetBus{TNotification}(TTheme)"/>
        public ICommandBus<TNotification> GetBus<TNotification>(TTheme theme) where TNotification : INotification
        {
            if (m_CommandBusMaps.TryGetValue(theme, out var bus))
            {
                return (ICommandBus<TNotification>) bus;
            }
            throw new ArgumentException("Non existing theme: " + theme);
        }
    }
}