using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Assertions;

namespace PeroTools2.AccessKing
{
    internal static unsafe class EventHelper
    {
        private const int error_offset = -1;
        private static int s_DelegateTargetFieldOffset = error_offset;
        private static bool s_HasGC;
        private static readonly List<WeakReference<IGCListener>> m_GCListeners = new List<WeakReference<IGCListener>>();
        private static readonly Dictionary<Type, MethodInfo> s_HandleMethods = new Dictionary<Type, MethodInfo>();
        private static WeakReference s_GCNotifier = new WeakReference(new GCNotifier());

        internal static bool TryGetNotificationType(this IEventObserver observer,out Type notificationType)
        {
            notificationType = null;
            foreach (var iEventHandler in observer.GetType().GetInterfaces())
            {
                if (!Regex.Replace(iEventHandler.Name, @"/[.*/]", "TNotification").Equals(typeof(IEventHandler<>).Name)) continue;
                notificationType = iEventHandler.GenericTypeArguments[0];
                return true;
            }
            return false;
        }

        
        internal static MethodInfo RequireEventHandlerHandleMethod(Type handlerType,Type notificationType)
        {
            if (s_HandleMethods.TryGetValue(notificationType, out var method))
            {
                return method;
            }
            method = handlerType.GetMethods().FirstOrDefault(m => m.ToString().Equals($"Void Handle({notificationType.Name} ByRef)"));
            Assert.IsNotNull(method);
            s_HandleMethods.Add(notificationType, method);
            Delegate.CreateDelegate(typeof(Action<INotification>), method);
            return method;
        }
        
        internal static MethodInfo RequireAsyncEventHandlerHandleMethod(Type handlerType,Type notificationType)
        {
            if (s_HandleMethods.TryGetValue(notificationType, out var method))
            {
                return method;
            }
            method = handlerType.GetMethods().FirstOrDefault(m => m.ToString().Equals($"Task HandleAsync({notificationType.Name})"));
            Assert.IsNotNull(method);
            s_HandleMethods.Add(notificationType, method);
            return method;
        }

        internal static void WaitForGCFinishCallbackCheck(this IGCListener gcListener)
        {
            if (!s_HasGC && s_GCNotifier.IsAlive) return;
            lock (m_GCListeners)
            {
                for (var index = m_GCListeners.Count - 1; index >= 0; index--)
                {
                    if (m_GCListeners[index].TryGetTarget(out gcListener))
                        gcListener.OnGCFinished();
                    else
                    {
                        m_GCListeners.RemoveAt(index);
                    }
                }

                s_GCNotifier = new WeakReference(new GCNotifier()) ;
                s_HasGC = false;
            }
        }

        internal static void RegisterGCFinishListener(this IGCListener gcListener)
        {
            lock (m_GCListeners)
            {
                m_GCListeners.Add(new WeakReference<IGCListener>(gcListener));
                if (s_GCNotifier == null)
                {
                    s_GCNotifier = new WeakReference(new GCNotifier());
                }
            }
        }

        internal static Delegate ToWeakTargetDelegate(this Delegate delegation)
        {
            var result = (Delegate)delegation.Clone();
            SetWeakReferenceSource(result);
            return result;
        }
        
        private static void SetWeakReferenceSource(Delegate target)
        {
            if (target.Target == null || target.GetType() == typeof(WeakObjectProxy)) return;
            var ptr = PointerConverter.ConvertToBytePtr(target);
            ptr += GetDelegateTargetFieldOffset();
            *(IntPtr*) ptr = PointerConverter.ConvertToIntPtr(new WeakObjectProxy(target.Target));
        }
        
        private static int GetDelegateTargetFieldOffset()
        {
            if (s_DelegateTargetFieldOffset != error_offset)
            {
                return s_DelegateTargetFieldOffset;
            }

            var fieldInfo = typeof(Delegate)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(field => field.Name.ToLower().Contains("_target"));
            Assert.IsNotNull(fieldInfo);
            return s_DelegateTargetFieldOffset = UnsafeUtility.GetFieldOffset(fieldInfo);
        }

        
        private class GCNotifier 
        {
            ~GCNotifier() => s_HasGC = true;
        }
    }
}