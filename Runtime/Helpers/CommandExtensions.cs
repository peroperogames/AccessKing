/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月23日
 * Description: Command bus/schedule/handler-factory extensions.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    public static class CommandExtensions
    {
        #region Reflection

        /// <summary>
        /// Try parsing command bus's notification argument.
        /// </summary>
        /// <param name="busType">Command bus type.</param>
        /// <returns>Notification type when it succeed or null when it failed.</returns>
        internal static Type GetNotificationType(Type busType)
        {
            Type notificationType = null;
            var commandBusName = typeof(ISchedulableCommandBus<>).FullName;
            foreach (var @interface in busType.GetInterfaces())
            {
                if (@interface.FullName == null) continue;

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

        /// <summary>
        /// Get all the results with the specified type. If there are any task with result type, it will abort current thread and wait.
        /// </summary>
        /// <param name="operation">Result operation.</param>
        /// <typeparam name="TResult">Result collection.</typeparam>
        /// <returns>Results of specified type collection.</returns>
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

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler(this RegistryCommandHandlerFactory factory, Action action)
            => factory.RegisterHandler(new ActionCommandHandler(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T>(this RegistryCommandHandlerFactory factory, Action<T> action)
            => factory.RegisterHandler(new ActionCommandHandler<T>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2>(this RegistryCommandHandlerFactory factory, Action<T1, T2> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3, T4>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        public static void RegisterActionHandler<T1, T2, T3, T4, T5>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5> action)
            => factory.RegisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5>(action));

        /// <summary>
        /// Convert action delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        public static void RegisterFuncHandler<TResult>(this RegistryCommandHandlerFactory factory, Func<TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<TResult>(func));

        /// <summary>
        /// Convert action delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        public static void RegisterFuncHandler<T, TResult>(this RegistryCommandHandlerFactory factory, Func<T, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T, TResult>(func));

        /// <summary>
        /// Convert action delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, TResult>(func));

        /// <summary>
        /// Convert action delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, T3, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, TResult>(func));

        /// <summary>
        /// Convert action delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, T3, T4, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, T4, TResult>(func));

        /// <summary>
        /// Convert action delegate to FuncCommandHandler, then register to command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        public static void RegisterFuncHandler<T1, T2, T3, T4, T5, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, TResult> func)
            => factory.RegisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, TResult>(func));

        #endregion

        #region UnregisterHandler

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static void UnregisterActionHandler(this RegistryCommandHandlerFactory factory, Action action)
            => factory.UnregisterHandler(new ActionCommandHandler(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static void UnregisterActionHandler<T>(this RegistryCommandHandlerFactory factory, Action<T> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static void UnregisterActionHandler<T1, T2>(this RegistryCommandHandlerFactory factory, Action<T1, T2> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static void UnregisterActionHandler<T1, T2, T3>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static void UnregisterActionHandler<T1, T2, T3, T4>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3, T4>(action));

        /// <summary>
        /// Convert action delegate to ActionCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="action">The delegate which convert to ActionCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static void UnregisterActionHandler<T1, T2, T3, T4, T5>(this RegistryCommandHandlerFactory factory, Action<T1, T2, T3, T4, T5> action)
            => factory.UnregisterHandler(new ActionCommandHandler<T1, T2, T3, T4, T5>(action));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static void UnregisterFuncHandler<TResult>(this RegistryCommandHandlerFactory factory, Func<TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static void UnregisterFuncHandler<T, TResult>(this RegistryCommandHandlerFactory factory, Func<T, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static void UnregisterFuncHandler<T1, T2, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static void UnregisterFuncHandler<T1, T2, T3, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, T3, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static void UnregisterFuncHandler<T1, T2, T3, T4, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, T3, T4, TResult>(func));

        /// <summary>
        /// Convert func delegate to FuncCommandHandler, then remove from command bus.
        /// </summary>
        /// <param name="factory">Command handler factory.</param>
        /// <param name="func">The delegate which convert to FuncCommandHandler.</param>
        /// <returns>Is removed succeed.</returns>
        public static void UnregisterFuncHandler<T1, T2, T3, T4, T5, TResult>(this RegistryCommandHandlerFactory factory, Func<T1, T2, T3, T4, T5, TResult> func)
            => factory.UnregisterHandler(new FuncCommandHandler<T1, T2, T3, T4, T5, TResult>(func));

        #endregion

        #region Execute

        /// <summary>
        /// Execute all handler's handle method in bus with 0 argument type parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute(this ICommandBus<Empty> commandBus)
        {
            var notification = ParameterNotification.Empty;
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 1 argument type parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T>(this ICommandBus<ParameterNotification<T>> commandBus, T param)
        {
            var notification = ParameterNotification.Create(param);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 2 argument types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2>(this ICommandBus<ParameterNotification<T1, T2>> commandBus, T1 param1, T2 param2)
        {
            var notification = ParameterNotification.Create(param1, param2);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 3 argument types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3>(this ICommandBus<ParameterNotification<T1, T2, T3>> commandBus, T1 param1, T2 param2, T3 param3)
        {
            var notification = ParameterNotification.Create(param1, param2, param3);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 4 argument types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3, T4>(this ICommandBus<ParameterNotification<T1, T2, T3, T4>> commandBus, T1 param1, T2 param2, T3 param3, T4 param4)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 5 argument types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3, T4, T5>(this ICommandBus<ParameterNotification<T1, T2, T3, T4, T5>> commandBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4, param5);
            return commandBus.Execute(ref notification);
        }

        #endregion
    }
}