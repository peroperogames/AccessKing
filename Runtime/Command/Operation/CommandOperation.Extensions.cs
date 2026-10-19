/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/11 09:12:36
 */

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public static class CommandOperationExtensions
    {
        /// <summary>
        /// Pool for UniTask collection.
        /// </summary>
        private static class UniTaskCollection
        {
            private static readonly ConcurrentStack<List<UniTask>> s_Cache = new();

            public static List<UniTask> Rent() => s_Cache.TryPop(out var tasks) ? tasks : new List<UniTask>();

            public static void Return(List<UniTask> tasks)
            {
                tasks.Clear();
                s_Cache.Push(tasks);
            }
        }

        #region SyncOperation

        /// <summary>
        /// Get all the results with the specified type. If there are any task with result type, it will abort current thread and wait.
        /// </summary>
        /// <param name="operation">Result operation.</param>
        /// <typeparam name="TResult">Result collection.</typeparam>
        /// <param name="autoRelease">Release operation.</param>
        /// <returns>Results of specified type collection.</returns>
        public static IReadOnlyList<TResult> GetResults<TResult>(this CommandOperation operation, bool autoRelease = true)
        {
            var results = new List<TResult>();
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

        #endregion

        #region AsyncOperation

        /// <summary>
        /// Wait for all async tasks done.
        /// </summary>
        /// <param name="tasks">Task results.</param>
        public static async UniTask WhenAllDone(this IEnumerable<Task> tasks) => await Task.WhenAll(tasks);

        /// <summary>
        /// Wait for any async task done.
        /// </summary>
        /// <param name="tasks">Task results.</param>
        public static async UniTask WhenAnyDone(this IEnumerable<Task> tasks) => await Task.WhenAny(tasks);

        /// <summary>
        /// Wait for all async tasks done.
        /// </summary>
        /// <param name="tasks">Task results.</param>
        public static async UniTask WhenAllDone(this IEnumerable<UniTask> tasks) => await UniTask.WhenAll(tasks);

        /// <summary>
        /// Wait for any async task done.
        /// </summary>
        /// <param name="tasks">Task results.</param>
        public static async UniTask WhenAnyDone(this IEnumerable<UniTask> tasks) => await UniTask.WhenAny(tasks);

        /// <summary>
        /// Get all results with the specified type and wait for them done if any task type.
        /// </summary>
        /// <param name="operation">Result operation.</param>
        /// <param name="autoRelease">Release operation.</param>
        /// <returns>Results of task type collection.</returns>
        public static async UniTask<IReadOnlyList<TResult>> GetResultsAsync<TResult>(this CommandOperation operation, bool autoRelease = true)
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
        public static async UniTask GetResultsAsync<TResult>(this CommandOperation operation, IList<TResult> results, bool autoRelease = true)
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
                        results.Add(await resultTaskGetter.GetResult());
                        break;
                    case IResultAvailable<UniTask<TResult>> resultUniTaskGetter:
                        results.Add(await resultUniTaskGetter.GetResult());
                        break;
                }
            }
            if (autoRelease)
            {
                operation.ReleaseResults();
            }
        }

        /// <summary>
        /// Get all results with Task type.
        /// </summary>
        /// <param name="operation">Result operation.</param>
        /// <param name="results">Result collection.</param>
        /// <param name="autoRelease">Release operation.</param>
        /// <returns>Results of task type collection.</returns>
        public static IReadOnlyList<UniTask> GetAllAsyncTasks(this CommandOperation operation, bool autoRelease = true)
        {
            var results = new List<UniTask>();
            GetAllAsyncTasks(operation, results, autoRelease);
            return results;
        }

        /// <summary>
        /// Get all results with Task type.
        /// </summary>
        /// <param name="operation">Result operation.</param>
        /// <param name="results">Result collection.</param>
        /// <param name="autoRelease">Release operation.</param>
        /// <returns>Results of task type collection.</returns>
        public static void GetAllAsyncTasks(this CommandOperation operation, IList<UniTask> results, bool autoRelease = true)
        {
            var getters = operation.getters;
            for (var index = 0; index < getters.Count; index++)
            {
                var item = getters[index];
                switch (item)
                {
                    case IResultAvailable<Task> taskResult:
                        results.Add(taskResult.GetResult().AsUniTask());
                        break;
                    case IResultAvailable<UniTask> taskResult:
                        results.Add(taskResult.GetResult());
                        break;
                }
            }
            if (autoRelease)
            {
                operation.ReleaseResults();
            }
        }

        /// <summary>
        /// Wait for all async tasks done.
        /// </summary>
        /// <param name="autoRelease">Release operation.</param>
        public static async UniTask WhenAllDone(this CommandOperation operation, bool autoRelease = true)
        {
            var getters = operation.getters;
            for (var index = 0; index < getters.Count; index++)
            {
                var item = getters[index];
                if (item is IResultAvailable<Task> resultTaskGetter)
                {
                    await resultTaskGetter.GetResult();
                }
                else if (item is IResultAvailable<UniTask> resultUnitaskGetter)
                {
                    await resultUnitaskGetter.GetResult();
                }
            }
            if (autoRelease)
            {
                operation.ReleaseResults();
            }
        }

        /// <summary>
        /// Wait for any async task done.
        /// </summary>
        /// <param name="autoRelease">Release operation.</param>
        public static async UniTask WhenAnyDone(this CommandOperation operation, bool autoRelease = true)
        {
            var getters = operation.getters;
            var tasks = UniTaskCollection.Rent();
            for (var index = 0; index < getters.Count; index++)
            {
                var item = getters[index];
                if (item is IResultAvailable<Task> resultTaskGetter)
                {
                    tasks.Add(resultTaskGetter.GetResult().AsUniTask());
                }
                else if (item is IResultAvailable<UniTask> resultUnitaskGetter)
                {
                    tasks.Add(resultUnitaskGetter.GetResult());
                }
            }
            await UniTask.WhenAny(tasks);
            UniTaskCollection.Return(tasks);
            if (autoRelease)
            {
                operation.ReleaseResults();
            }
        }

        #endregion
    }
}