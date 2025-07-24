/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/01 11:06:21
 */

using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Command handlers executed result collection.
    /// </summary>
    public readonly struct CommandOperation
    {
        /// <summary>
        /// Result collection.
        /// </summary>
        internal readonly List<IResultAvailable> resultGetters;

        internal CommandOperation(List<IResultAvailable> resultGetters) => this.resultGetters = resultGetters;
    }
}