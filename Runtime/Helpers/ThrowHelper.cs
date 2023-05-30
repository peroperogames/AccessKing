using System;

namespace PeroTools2.AccessKing
{
    internal static class ThrowHelper
    {
        public static void ThrowWhenAccessBusRequireFailed(Type busType) => throw new InvalidCastException($"{busType} require failed. ");

        public static void ThrowWhenAccessBusCastFailed(Type busType) => throw new InvalidCastException($"Access bus must be {busType} type. ");

        public static void ThrowWhenCommandBusCastFailed() => throw new InvalidCastException($"Command bus must be {typeof(IAccessBus)} and {typeof(ICommandHandler<,>)} type. ");

        public static void ThrowWhenHandlerFactoryNeverBeenRegistered<TTheme>(TTheme theme) => throw new InvalidOperationException($"The Schedule for the \"{theme}\" theme has never registered a handler factory. ");

        public static void ThrowWhenHandlerFactoryRepeat<TTheme>(TTheme theme) => throw new InvalidOperationException($"The handler factory is not same with the one registered. Theme : {theme}");
        
        public static void ThrowWhenNotificationCastFailed<TNotification>(INotification notification) => throw new InvalidCastException($"{notification.GetType()} is not a ${typeof(TNotification)} type. ");

        public static void ThrowWhenThemeHasBeenRegistered<TTheme>(TTheme theme) => throw new ArgumentException($"An item with the same theme has already been registered. Key : {theme}. ");
    }
}