/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: shuaishuai
 * Created On: 2024/04/08
 * Description:
 */

using System;

namespace PeroTools2.AccessKing
{
    internal static class EventHandlerExtension
    {
        /// <summary>
        /// Get reference target and considering that the situation is UnityEngine.Object
        /// </summary>
        /// <param name="weakReference">Weak reference of the handler.</param>
        /// <param name="source">The handler that the weak reference points to.</param>
        /// <typeparam name="TSource">Type of the referenced handler.</typeparam>
        /// <returns>Whether the reference is still alive and is not a destroyed <see cref="UnityEngine.Object"/>.</returns>
        internal static bool TryGetReference<TSource>(this WeakReference<TSource> weakReference, out TSource source) where TSource : class
        {
            if (!weakReference.TryGetTarget(out source))
            {
                return false;
            }
            if (source is UnityEngine.Object obj)
            {
                return obj != null;
            }
            return true;
        }
    }
}