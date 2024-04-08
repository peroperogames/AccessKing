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
        /// <param name="weakReference"></param>
        /// <param name="source"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
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