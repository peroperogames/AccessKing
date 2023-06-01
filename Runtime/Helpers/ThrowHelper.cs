using System;

namespace PeroTools2.AccessKing
{
    internal static class ThrowHelper
    {
        public static void AccessBusCastFailed() => throw new InvalidCastException("Bus must implement from IAccessBus.");
        public static void AccessBusRequireFailed(Type busType) => throw new InvalidCastException($"{busType} require failed. ");

        public static void CommandBusCastFailed<TNotification>() where TNotification : INotification => throw new InvalidCastException($"Command bus must be {typeof(IAccessBus)} and {typeof(ICommandBus<TNotification>)} type. ");

        public static void CommandBusCastFailed() => throw new InvalidCastException($"Command bus must be {typeof(IAccessBus)} and {typeof(ICommandBus<>)} type. ");

        public static void NotificationCastFailed<TNotification>(INotification notification) => throw new InvalidCastException($"{notification.GetType()} is not a ${typeof(TNotification)} type. ");
    }
}