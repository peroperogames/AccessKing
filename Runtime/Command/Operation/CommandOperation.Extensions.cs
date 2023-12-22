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
        public static IReadOnlyList<TResult> GetResults<TResult>(this CommandOperation operation)
        {
            var results = new List<TResult>();
            var handleResults = operation.handleResults;
            for (int index = 0; index < handleResults.Count; index++)
            {
                object item = operation.handleResults[index];
                switch (item)
                {
                    case TResult result:
                        results.Add(result);
                        break;
                    case Task<TResult> resultTask:
                    {
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
        public static async Task<IReadOnlyList<TResult>> GetResultsAsync<TResult>(this CommandOperation operation)
        {
            var results = new List<TResult>();
            var handleResults = operation.handleResults;
            for (int index = 0; index < handleResults.Count; index++)
            {
                object item = handleResults[index];
                switch (item)
                {
                    case Task<TResult> resultTask:
                        results.Add(await resultTask);
                        break;
                    case TResult tResult:
                        results.Add(tResult);
                        break;
                }
            }

            return results;
        }

        #endregion
    }
}