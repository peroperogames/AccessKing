/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/01 11:06:21
 */

using System;
using System.Collections.Generic;
using UnityEngine.Pool;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Command handlers executed result collection.
    /// </summary>
    public readonly struct CommandOperation
    {
        /// <summary>
        /// Owns the pooled result getter collection so that it can be released at most once.
        /// </summary>
        internal sealed class ResultCollection
        {
            /// <summary>
            /// Pooled result getters.
            /// </summary>
            private readonly List<IResultAvailable> m_Getters;

            /// <summary>
            /// Whether the pooled collection has been released back to the pool.
            /// </summary>
            private bool m_Released;

            internal ResultCollection(List<IResultAvailable> getters) => m_Getters = getters;

            /// <summary>
            /// Get the result getters.
            /// </summary>
            /// <exception cref="InvalidOperationException">Throw when the result has already been released.</exception>
            internal List<IResultAvailable> getters => m_Released
                ? throw new InvalidOperationException(
                    "The command operation result has already been released, its collection is back in the shared pool and may be reused by another Execute. " +
                    "When autoRelease is enabled a CommandOperation can only be consumed once.")
                : m_Getters;

            /// <summary>
            /// Release the pooled collection exactly once.
            /// </summary>
            /// <exception cref="InvalidOperationException">Throw when the collection is released twice.</exception>
            internal void Release()
            {
                if (m_Released)
                {
                    throw new InvalidOperationException(
                        "The command operation result has been released twice. Releasing a pooled collection twice would hand the same instance to two commands and corrupt their results.");
                }
                m_Released = true;
                CollectionPool<List<IResultAvailable>, IResultAvailable>.Release(m_Getters);
            }
        }

        /// <summary>
        /// Result collection owner. All copies of this struct share the same collection.
        /// </summary>
        internal readonly ResultCollection resultCollection;

        internal CommandOperation(List<IResultAvailable> resultGetters) => resultCollection = new ResultCollection(resultGetters);

        /// <summary>
        /// Get the result getter collection of this operation.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throw when this operation holds no result or its result has been released.</exception>
        internal List<IResultAvailable> getters => resultCollection is null
            ? throw new InvalidOperationException(
                "The command operation holds no result. Do not consume the default value of CommandOperation, always use the value returned by Execute.")
            : resultCollection.getters;

        /// <summary>
        /// Release the result collection back to the shared pool.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throw when this operation holds no result or its result has been released.</exception>
        internal void ReleaseResults()
        {
            if (resultCollection is null)
            {
                throw new InvalidOperationException(
                    "The command operation holds no result to release. Do not consume the default value of CommandOperation.");
            }
            resultCollection.Release();
        }
    }
}
