/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月29日
 * Description: Unified exception throwing helper.
 */

using System;

namespace PeroTools2.AccessKing
{
    internal static class ThrowHelper
    {
        public static void AccessBusRequireFailed(Type busType) => throw new InvalidCastException($"{busType} require failed. ");
        public static void ScheduleCommandBusCastFailed() => throw new InvalidCastException($"Command bus must be {typeof(ISchedulableCommandBus<>)} type. ");
        public static void ScheduleEventBusCastFailed() => throw new InvalidCastException($"Event bus must be {typeof(ISchedulableCommandBus<>)} type. ");
        public static void NotificationCastFailed<TNotification>(INotification notification) => throw new InvalidCastException($"{notification.GetType()} is not a ${typeof(TNotification)} type. ");
    }
}