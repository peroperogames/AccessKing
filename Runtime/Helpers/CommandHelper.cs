using System;
using System.Collections.Generic;
using System.Reflection;
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
            s_HandleMethodMaps.Add(executive.GetType(),methodInfo);
            return methodInfo;
        }
    }
}