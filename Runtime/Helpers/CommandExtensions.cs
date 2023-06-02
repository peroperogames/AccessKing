using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public static class CommandExtensions
    {

        #region Reflection

        internal static Type GetNotificationType(Type busType)
        {
            Type notificationType = null;
            var commandBusName = typeof(ISchedulableCommandBus<>).FullName;
            foreach (var @interface in busType.GetInterfaces())
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

        #region SyncOperation

        public static IReadOnlyList<TResult> GetResults<TResult>(this CommandOperation operation)
        {
            var results = new List<TResult>();
            foreach (var item in operation.handleResults)
            {
                if (item is TResult result)
                    results.Add(result);
                else if (item is Task<TResult> resultTask)
                {
                    if (!resultTask.IsCompleted)
                        resultTask.Wait();
                    results.Add(resultTask.Result);
                }
            }

            return results;
        }

        #endregion

        #region AsyncOperation

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

        #region RegisterHandler

        public static void RegisterActionHandler(this RegistryCommandHandlerFactory factory, Action action)
            => factory.RegisterHandler(new ActionCommandHandler(action));

        public static void RegisterActionHandler<T>(this RegistryCommandHandlerFactory factory, Action<T> action)
            => factory.RegisterHandler(new ActionCommandHandler<T>(action));

        public static void RegisterActionHandler<T1, T2>(this RegistryCommandHandlerFactory factory, Action<T1, T2> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2>(action));

        public static void RegisterActionHandler<T1, T2, T3>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3>(action));

        public static void RegisterActionHandler<T1, T2, T3, T4>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4>(action));

        public static void RegisterActionHandler<T1, T2, T3, T4, T5>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5>(action));

        public static void RegisterFuncHandler<TResult>(this RegistryCommandHandlerFactory factory, Func<TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<TResult>(func));

        public static void RegisterFuncHandler<T, TResult>(this RegistryCommandHandlerFactory factory, Func<T, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T, TResult>(func));

        public static void RegisterFuncHandler<T1, T2, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, TResult>(func));

        public static void RegisterFuncHandler<T1, T2, T3, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, TResult>(func));

        public static void RegisterFuncHandler<T1, T2, T3, T4, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, T4, TResult>(func));

        public static void RegisterFuncHandler<T1, T2, T3, T4, T5, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, TResult>(func));

        #endregion

        #region Execute

        public static CommandOperation Execute(this ICommandBus<Empty> bus)
        {
            var notification = ParameterNotification.Empty;
            return bus.Execute(ref notification);
        }

        public static CommandOperation Execute<T>(this ICommandBus<ParameterNotification<T>> bus, T param)
        {
            var notification = ParameterNotification.Create(param);
            return bus.Execute(ref notification);
        }

        public static CommandOperation Execute<T1, T2>(this ICommandBus<ParameterNotification<T1, T2>> bus, T1 param1, T2 param2)
        {
            var notification = ParameterNotification.Create(param1, param2);
            return bus.Execute(ref notification);
        }

        public static CommandOperation Execute<T1, T2, T3>(this ICommandBus<ParameterNotification<T1, T2, T3>> bus, T1 param1, T2 param2, T3 param3)
        {
            var notification = ParameterNotification.Create(param1, param2, param3);
            return bus.Execute(ref notification);
        }

        public static CommandOperation Execute<T1, T2, T3, T4>(this ICommandBus<ParameterNotification<T1, T2, T3, T4>> bus, T1 param1, T2 param2, T3 param3, T4 param4)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4);
            return bus.Execute(ref notification);
        }

        public static CommandOperation Execute<T1, T2, T3, T4, T5>(this ICommandBus<ParameterNotification<T1, T2, T3, T4, T5>> bus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4, param5);
            return bus.Execute(ref notification);
        }

        #endregion
    }
}