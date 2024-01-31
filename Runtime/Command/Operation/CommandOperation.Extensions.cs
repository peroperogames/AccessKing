/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/11 09:12:36
 */

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public static class CommandOperationExtensions
    {
        #region SyncOperation

        /// <summary>
        /// Get all the results with the specified type. If there are any task with result type, it will abort current thread and wait.
        /// </summary>
        /// <param name="operation">Result operation.</param>
        /// <typeparam name="TResult">Result collection.</typeparam>
        /// <returns>Results of specified type collection.</returns>
        public static List<TResult> GetResults<TResult>(this CommandOperation operation)
        {
            var results = new List<TResult>();
            var getters = operation.resultGetters;
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

            return results;
        }

        #endregion

        #region AsyncOperation

        /// <summary>
        /// Get all results with Task type.
        /// </summary>
        /// <param name="operation">Result operation.</param>
        /// <returns>Results of task type collection.</returns>
        public static IReadOnlyList<Task> GetAllAsyncTask(this CommandOperation operation) => operation.GetResults<Task>();

        /// <summary>
        /// Wait for all async tasks done.
        /// </summary>
        /// <param name="tasks">Task results.</param>
        public static async Task WhenAllDone(this IEnumerable<Task> tasks)
        {
            await Task.WhenAll(tasks);
        }

        /// <summary>
        /// Wait for any async task done.
        /// </summary>
        /// <param name="tasks">Task results.</param>
        public static async Task WhenAnyDone(this IEnumerable<Task> tasks)
        {
            await Task.WhenAny(tasks);
        }

        /// <summary>
        /// Get all results with the specified type and wait for them done if any task type.
        /// </summary>
        /// <param name="operation">Result operation.</param>
        /// <returns>Results of task type collection.</returns>
        public static async Task<List<TResult>> GetResultsAsync<TResult>(this CommandOperation operation)
        {
            var results = new List<TResult>();
            var getters = operation.resultGetters;
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

            return results;
        }

        #endregion
    }
}