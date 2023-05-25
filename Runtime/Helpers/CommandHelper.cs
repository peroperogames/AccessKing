using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine.Assertions;

namespace PeroTools2.AccessKing
{
    public static class CommandHelper
    {
        private static readonly Dictionary<Type, MethodInfo> s_HandleMethodMaps = new Dictionary<Type, MethodInfo>();

        public static MethodInfo GetHandleMethod<TNotification>(this ICommandExecutive<TNotification> executive) where TNotification : INotification
        {
            if (s_HandleMethodMaps.TryGetValue(executive.GetType(), out var methodInfo))
                return methodInfo;
            methodInfo = executive.GetType().GetMethod("Handle", new Type[] {typeof(TNotification)});
            Assert.IsNotNull(methodInfo);
            s_HandleMethodMaps.Add(executive.GetType(), methodInfo);
            return methodInfo;
        }

        public static object TryHandle<TNotification>(this ICommandExecutive<TNotification> executive,TNotification notification) where TNotification : INotification
        {
            object result = null;
            switch (executive)
            {
                case ICommandHandler<TNotification> nonResultHandler:
                    nonResultHandler.Handle(notification);
                    break;
                case ITaskCommandHandler<TNotification, Task> taskHandler:
                    result = taskHandler.Handle(notification);
                    break;
                case ICommandHandler<TNotification, object> resultHandler:
                    result = resultHandler.Handle(notification);
                    break;
                case ICommandHandler<TNotification, int> intResultHandler:
                    result = intResultHandler.Handle(notification);
                    break;
                case ICommandHandler<TNotification, short> shortResultHandler:
                    result = shortResultHandler.Handle(notification);
                    break;
                case ICommandHandler<TNotification, byte> byteResultHandler:
                    result = byteResultHandler.Handle(notification);
                    break;
                case ICommandHandler<TNotification, long> longResultHandler:
                    result = longResultHandler.Handle(notification);
                    break;
                case ICommandHandler<TNotification, uint> uintResultHandler:
                    result = uintResultHandler.Handle(notification);
                    break;
                case ICommandHandler<TNotification, ushort> ushortResultHandler:
                    result = ushortResultHandler.Handle(notification);
                    break;
                case ICommandHandler<TNotification, ulong> ulongResultHandler:
                    result = ulongResultHandler.Handle(notification);
                    break;
                case ICommandHandler<TNotification, sbyte> sbyteResultHandler:
                    result = sbyteResultHandler.Handle(notification);
                    break;
                case ICommandHandler<TNotification, float> floatResultHandler:
                    result = floatResultHandler.Handle(notification);
                    break;
                case ICommandHandler<TNotification, double> doubleResultHandler:
                    result = doubleResultHandler.Handle(notification);
                    break;
                case ICommandHandler<TNotification, decimal> decimalResultHandler:
                    result = decimalResultHandler.Handle(notification);
                    break;
                default:
                    result = executive.GetHandleMethod().Invoke(executive, new object[] {notification});
                    break;
            }
            return result;
        }
    }
}