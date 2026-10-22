/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/11 09:12:36
 */

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeroTools2.AccessKing;

/// <summary>
/// Extensions that consume the results of a <see cref="CommandOperation"/>.
/// </summary>
public static class CommandOperationExtensions
{
    /// <summary>
    /// Get all the results with the specified type. If there are any task with result type, it will abort current thread and wait.
    /// </summary>
    /// <param name="operation">Result operation.</param>
    /// <typeparam name="TResult">Result collection.</typeparam>
    /// <param name="autoRelease">Release operation.</param>
    /// <returns>Results of specified type collection.</returns>
    public static IReadOnlyList<TResult> GetResults<TResult>(this CommandOperation operation, bool autoRelease = true)
    {
        List<TResult> results = [];
        GetResults(operation, results, autoRelease);
        return results;
    }

    /// <summary>
    /// Get all the results with the specified type. If there are any task with result type, it will abort current thread and wait.
    /// </summary>
    /// <param name="operation">Result operation.</param>
    /// <param name="results">Result collection.</param>
    /// <typeparam name="TResult">Result collection.</typeparam>
    /// <param name="autoRelease">Release operation.</param>
    /// <returns>Results of specified type collection.</returns>
    public static void GetResults<TResult>(this CommandOperation operation, List<TResult> results, bool autoRelease = true)
    {
        var getters = operation.getters;
        for (var index = 0; index < getters.Count; index++)
        {
            var item = getters[index];
            switch (item)
            {
                case IResultAvailable<TResult> resultGetter:
                    results.Add(resultGetter.GetResult());
                    break;
                case IResultAvailable<Task<TResult>> resultTaskGetter:
                {
                    var resultTask = resultTaskGetter.GetResult();
                    if (!resultTask.IsCompleted)
                    {
                        resultTask.Wait();
                    }
                    results.Add(resultTask.Result);
                    break;
                }
            }
        }
        if (autoRelease)
        {
            operation.ReleaseResults();
        }
    }
}