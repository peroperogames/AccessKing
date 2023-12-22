/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/01 11:06:21
 */

using System.Collections;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Command handlers executed result collection.
    /// </summary>
    public struct CommandOperation
    {
        /// <summary>
        /// Result collection.
        /// </summary>
        internal readonly ArrayList handleResults;

        internal CommandOperation(ArrayList handleResults) => this.handleResults = handleResults;
    }
}