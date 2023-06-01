using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;

namespace PeroTools2.AccessKing
{
    public static class CommandExtensions
    {
        #region Reflection

        internal static Type GetNotificationType<TBus>() where TBus : ICommandBus
        {
            Type notificationType = null;
            var commandBusName = typeof(ICommandBus<>).FullName;
            foreach (var @interface in typeof(TBus).GetInterfaces())
            {
                var genericTypeName = Regex.Replace(@interface.FullName, @"\[\[.*\]\]", "");
                if (genericTypeName.Equals(commandBusName))
                {
                    notificationType = @interface.GenericTypeArguments[0];
                }
            }

            return notificationType;
        }

        #endregion

        #region Sync command operation

        public static IReadOnlyList<TResult> GetResults<TResult>(this CommandOperation operation)
        {
            var results = new List<TResult>();
            foreach (var item in operation.handleResults)
            {
                if (item is TResult result)
                    results.Add(result);
                else if (item is Task<TResult> resultTask)
                {
                    resultTask.Wait();
                    results.Add(resultTask.Result);
                }
            }

            return results;
        }

        #endregion

        #region Async command operation

        public static IReadOnlyList<Task> GetAllAsyncTask(this CommandOperation operation) => operation.GetResults<Task>();

        public static async Task WhenAllDone(this IEnumerable<Task> tasks)
        {
            await Task.WhenAll(tasks);
        }

        public static async Task WhenAnyDone(this IEnumerable<Task> tasks)
        {
            await Task.WhenAny(tasks);
        }

        public static async Task<IEnumerable<TResult>> GetResultsAsync<TResult>(this CommandOperation operation)
        {
            var results = new List<TResult>();
            foreach (var item in operation.handleResults)
            {
                if (item is Task<TResult> resultTask)
                    results.Add(await resultTask);
                else if (item is TResult tResult)
                    results.Add(tResult);
            }

            return results;
        }

        #endregion


        #region Command bus execute

        public static CommandOperation Execute(this ICommandBus<Empty> bus)
            => bus.Execute(ParameterNotification.Empty);

        public static CommandOperation Execute<T>(this ICommandBus<ParameterNotification<T>> bus, T param)
            => bus.Execute(ParameterNotification.Create(param));

        public static CommandOperation Execute<T1, T2>(this ICommandBus<ParameterNotification<T1, T2>> bus, T1 param1, T2 param2)
            => bus.Execute(ParameterNotification.Create(param1, param2));

        public static CommandOperation Execute<T1, T2, T3>(this ICommandBus<ParameterNotification<T1, T2, T3>> bus, T1 param1, T2 param2, T3 param3)
            => bus.Execute(ParameterNotification.Create(param1, param2, param3));

        public static CommandOperation Execute<T1, T2, T3, T4>(this ICommandBus<ParameterNotification<T1, T2, T3, T4>> bus, T1 param1, T2 param2, T3 param3, T4 param4)
            => bus.Execute(ParameterNotification.Create(param1, param2, param3, param4));

        public static CommandOperation Execute<T1, T2, T3, T4, T5>(this ICommandBus<ParameterNotification<T1, T2, T3, T4, T5>> bus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
            => bus.Execute(ParameterNotification.Create(param1, param2, param3, param4, param5));

        #endregion
    }
}