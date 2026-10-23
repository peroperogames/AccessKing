/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2026/10/22 19:00:00
 */

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeroTools2.AccessKing;

/// <summary>
/// Task based asynchronous result helpers. The Unity configuration leaves this file out of the compilation, because
/// the Unity layer implements the same helpers on top of UniTask.
/// </summary>
public static class CommandOperationAsyncExtensions
{
    /// <summary>
    /// Pool for UniTask collection.
    /// </summary>
    private static class TaskCollection
    {
        private static readonly ConcurrentStack<List<Task>> s_Cache = new();

        public static List<Task> Rent() => s_Cache.TryPop(out var tasks) ? tasks : new List<Task>();

        public static void Return(List<Task> tasks)
        {
            tasks.Clear();
            s_Cache.Push(tasks);
        }
    }

    /// <summary>
    /// Wait for all async tasks done.
    /// </summary>
    /// <param name="tasks">Task results.</param>
    public static async Task WhenAllDone(this IEnumerable<Task> tasks) => await Task.WhenAll(tasks);

    /// <summary>
    /// Wait for any async task done.
    /// </summary>
    /// <param name="tasks">Task results.</param>
    public static async Task WhenAnyDone(this IEnumerable<Task> tasks) => await Task.WhenAny(tasks);

    /// <summary>
    /// Get all results with the specified type and wait for them done if any task type.
    /// </summary>
    /// <param name="operation">Result operation.</param>
    /// <param name="autoRelease">Release operation.</param>
    /// <returns>Results of task type collection.</returns>
    public static async Task<IReadOnlyList<TResult>> GetResultsAsync<TResult>(this CommandOperation operation, bool autoRelease = true)
    {
        var results = new List<TResult>();
        await GetResultsAsync(operation, results, autoRelease);
        return results;
    }

    /// <summary>
    /// Get all results with the specified type and wait for them done if any task type.
    /// </summary>
    /// <param name="operation">Result operation.</param>
    /// <param name="results">Result collection.</param>
    /// <param name="autoRelease">Release operation.</param>
    /// <returns>Results of task type collection.</returns>
    public static async Task GetResultsAsync<TResult>(this CommandOperation operation, IList<TResult> results, bool autoRelease = true)
    {
        var getters = operation.getters;
        try
        {
            for (var index = 0; index < getters.Count; index++)
            {
                var item = getters[index];
                switch (item)
                {
                    case IResultAvailable<TResult> resultGetter:
                        results.Add(resultGetter.GetResult());
                        break;
                    case IResultAvailable<Task<TResult>> resultTaskGetter:
                        results.Add(await resultTaskGetter.GetResult());
                        break;
                }
            }
        }
        finally
        {
            // A faulted task must not strand the rented collection in the pool.
            if (autoRelease)
            {
                operation.ReleaseResults();
            }
        }
    }

    /// <summary>
    /// Get all results with Task type.
    /// </summary>
    /// <param name="operation">Result operation.</param>
    /// <param name="autoRelease">Release operation.</param>
    /// <returns>Results of task type collection.</returns>
    public static IReadOnlyList<Task> GetAllAsyncTasks(this CommandOperation operation, bool autoRelease = true)
    {
        var results = new List<Task>();
        GetAllAsyncTasks(operation, results, autoRelease);
        return results;
    }

    /// <summary>
    /// Wait for all async tasks done.
    /// </summary>
    /// <param name="autoRelease">Release operation.</param>
    /// <param name="operation">Result operation.</param>
    public static async Task WhenAllDone(this CommandOperation operation, bool autoRelease = true)
    {
        var getters = operation.getters;
        try
        {
            for (var index = 0; index < getters.Count; index++)
            {
                var item = getters[index];
                if (item is IResultAvailable<Task> resultTaskGetter)
                {
                    await resultTaskGetter.GetResult();
                }
            }
        }
        finally
        {
            // A faulted task must not strand the rented collection in the pool.
            if (autoRelease)
            {
                operation.ReleaseResults();
            }
        }
    }

    /// <summary>
    /// Wait for any async task done.
    /// </summary>
    /// <param name="autoRelease">Release operation.</param>
    /// <param name="operation">Result operation.</param>
    public static async Task WhenAnyDone(this CommandOperation operation, bool autoRelease = true)
    {
        var getters = operation.getters;
        var tasks = TaskCollection.Rent();
        try
        {
            for (var index = 0; index < getters.Count; index++)
            {
                var item = getters[index];
                if (item is IResultAvailable<Task> resultTaskGetter)
                {
                    tasks.Add(resultTaskGetter.GetResult());
                }
            }

            await Task.WhenAny(tasks);
        }
        finally
        {
            // Never leak the rented collections, whichever way the wait ends.
            TaskCollection.Return(tasks);
            if (autoRelease)
            {
                operation.ReleaseResults();
            }
        }
    }
    /// <summary>
    /// Get all results with Task type.
    /// </summary>
    /// <param name="operation">Result operation.</param>
    /// <param name="results">Result collection.</param>
    /// <param name="autoRelease">Release operation.</param>
    /// <returns>Results of task type collection.</returns>
    public static void GetAllAsyncTasks(this CommandOperation operation, IList<Task> results, bool autoRelease = true)
    {
        var getters = operation.getters;
        for (var index = 0; index < getters.Count; index++)
        {
            var item = getters[index];
            switch (item)
            {
                case IResultAvailable<Task> taskResult:
                    results.Add(taskResult.GetResult());
                    break;
            }
        }
        if (autoRelease)
        {
            operation.ReleaseResults();
        }
    }
}