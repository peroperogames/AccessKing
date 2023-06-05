/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月26日
 * Description: Allow the command handler to return the result after the handling is finished.
 */

namespace PeroTools2.AccessKing
{
    public interface IResultAvailable
    {
        /// <summary>
        /// Get the handle Result.
        /// </summary>
        /// <returns>Result</returns>
        object GetResult();
    }

    public interface IResultAvailable<out TResult> : IResultAvailable
    {
        /// <summary>
        /// Get the handle Result.
        /// </summary>
        /// <returns>Result</returns>
        TResult GetResult();
    }
}