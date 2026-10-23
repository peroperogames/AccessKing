/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2026/10/12 10:10:00
 */

using System.Collections.Concurrent;
using System.Collections.Generic;

namespace PeroTools2.AccessKing;

/// <summary>
/// Minimal collection pool. The core assembly owns it so that it does not depend on the engine pool.
/// </summary>
/// <remarks>
/// Renting and releasing are thread safe, because the asynchronous result helpers may release the collection from a
/// different thread than the one that executed the command.
/// </remarks>
internal static class CollectionPool<TCollection, TItem> where TCollection : class, ICollection<TItem>, new()
{
    /// <summary>
    /// Rented collections.
    /// </summary>
    private static readonly ConcurrentStack<TCollection> s_Pool = new();

    /// <summary>
    /// Rent a collection, the pool creates one when it is empty.
    /// </summary>
    internal static TCollection Get() => s_Pool.TryPop(out var collection) ? collection : [];

    /// <summary>
    /// Return a collection to the pool.
    /// </summary>
    internal static void Release(TCollection collection)
    {
        collection.Clear();
        s_Pool.Push(collection);
    }
}