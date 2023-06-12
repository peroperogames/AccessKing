/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年06月01日
 * Description: Command handlers executed result collection.
 */

using System.Collections;

namespace PeroTools2.AccessKing
{
    public struct CommandOperation
    {
        /// <summary>
        /// Result collection.
        /// </summary>
        public readonly ArrayList handleResults;

        public CommandOperation(ArrayList handleResults)
        {
            this.handleResults = handleResults;
        }
    }
}