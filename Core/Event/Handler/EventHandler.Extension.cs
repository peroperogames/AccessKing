/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: shuaishuai
 * Created On: 2024/04/08
 * Description:
 */

using System;

namespace PeroTools2.AccessKing;

internal static class EventHandlerExtension
{
    /// <summary>
    /// Get the reference target, and treat an owner that the host considers dead as a missing reference.
    /// </summary>
    /// <param name="weakReference">Weak reference of the handler.</param>
    /// <param name="source">The handler that the weak reference points to.</param>
    /// <typeparam name="TSource">Type of the referenced handler.</typeparam>
    /// <returns>Whether the reference is still alive and is not an owner that the host counts as null.</returns>
    internal static bool TryGetReference<TSource>(this WeakReference<TSource> weakReference, out TSource source) where TSource : class
        => weakReference.TryGetTarget(out source) && !OwnerLifetime.comparer.Equals(source, null);
}