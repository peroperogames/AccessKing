/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/26 15:05:25
 */

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Allow the command handler to return the result after the handling is finished.
    /// </summary>
    public interface IResultAvailable
    {
        /// <summary>
        /// Get the handle Result.
        /// </summary>
        /// <returns>Result of command.</returns>
        object GetResult();
    }

    /// <inheritdoc cref="IResultAvailable"/>
    public interface IResultAvailable<out TResult> : IResultAvailable
    {
        /// <summary>
        /// Get the handle Result.
        /// </summary>
        /// <returns>Result of command.</returns>
        new TResult GetResult();
    }
}