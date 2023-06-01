using System;

namespace PeroTools2.AccessKing
{
    internal static class ThrowHelper
    {
        public static void AccessBusRequireFailed(Type busType) => throw new InvalidCastException($"{busType} require failed. ");
        public static void ScheduleCommandBusCastFailed() => throw new InvalidCastException($"Command bus must be {typeof(ISchedulableCommandBus<>)} type. ");
        public static void NotificationCastFailed<TNotification>(INotification notification) => throw new InvalidCastException($"{notification.GetType()} is not a ${typeof(TNotification)} type. ");
    }
}