/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/01 11:06:21
 */

using System;
using System.Collections.Generic;

namespace PeroTools2.AccessKing;

/// <summary>
/// Command handlers executed result collection. The collection is rented from a shared pool, so it is
/// released by the first read when <c>autoRelease</c> is enabled and by <see cref="Dispose"/> otherwise.
/// </summary>
public readonly struct CommandOperation : IDisposable
{
    /// <summary>
    /// Pooled result getter collection. It carries a generation that is bumped every time the collection is
    /// returned, so a copy of an operation that still refers to a recycled collection can be told apart from
    /// the operation that currently owns it.
    /// </summary>
    internal sealed class ResultCollection : List<IResultAvailable>
    {
        /// <summary>
        /// Generation of the rental. Bumped when the collection goes back to the pool.
        /// </summary>
        internal int generation;
    }

    /// <summary>
    /// The rented result collection.
    /// </summary>
    internal readonly ResultCollection resultCollection;

    /// <summary>
    /// Generation of the collection at the moment this operation was created.
    /// </summary>
    internal readonly int generation;

    internal CommandOperation(ResultCollection collection)
    {
        resultCollection = collection;
        generation = collection.generation;
    }

    /// <summary>
    /// Rent a result collection from the shared pool. In steady state this does not allocate.
    /// </summary>
    internal static ResultCollection Rent() => CollectionPool<ResultCollection, IResultAvailable>.Get();

    /// <summary>
    /// Return the result collection to the shared pool. The generation bump invalidates every copy of the
    /// operation that still refers to it, so the same collection can never be returned twice.
    /// </summary>
    internal static void Return(ResultCollection collection)
    {
        collection.generation++;
        CollectionPool<ResultCollection, IResultAvailable>.Release(collection);
    }

    /// <summary>
    /// Get the result getters of this operation.
    /// </summary>
    /// <exception cref="InvalidOperationException">Throw when this operation holds no result or its result has been released.</exception>
    internal List<IResultAvailable> getters
    {
        get
        {
            if (resultCollection is null)
            {
                throw new InvalidOperationException(
                    "The command operation holds no result. Do not consume the default value of CommandOperation, always use the value returned by Execute.");
            }
            if (resultCollection.generation != generation)
            {
                throw new InvalidOperationException(
                    "The command operation result has already been released, its collection is back in the shared pool and may be reused by another Execute.");
            }
            return resultCollection;
        }
    }

    /// <summary>
    /// Release the result collection back to the shared pool. Disposing twice is a no-op, so the value can be
    /// used with a using statement when the results were read with <c>autoRelease</c> disabled.
    /// </summary>
    public void Dispose()
    {
        if (resultCollection is null || resultCollection.generation != generation) return;
        Return(resultCollection);
    }

    /// <summary>
    /// Release the result collection back to the shared pool.
    /// </summary>
    /// <exception cref="InvalidOperationException">Throw when this operation holds no result or its result has been released.</exception>
    internal void ReleaseResults()
    {
        // Reading the getters validates that this operation still owns the collection, which is what makes a
        // second release impossible.
        _ = getters;
        Return(resultCollection);
    }
}