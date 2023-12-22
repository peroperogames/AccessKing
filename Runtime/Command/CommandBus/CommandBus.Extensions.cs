/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/11 10:12:16
 */

using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Extensions for <see cref="ICommandBus{TNotification}"/>.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    public static class CommandBusExtensions
    {
        /// <summary>
        /// Execute all handler's handle method in bus with 0 argument types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute(this ICommandBus<Empty> commandBus)
        {
            var notification = ParameterNotification.Empty;
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 1 argument types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T>(this ICommandBus<ParameterNotification<T>> commandBus, T param)
        {
            var notification = ParameterNotification.Create(param);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 2 arguments types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2>(this ICommandBus<ParameterNotification<T1, T2>> commandBus, T1 param1, T2 param2)
        {
            var notification = ParameterNotification.Create(param1, param2);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 3 arguments types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3>(this ICommandBus<ParameterNotification<T1, T2, T3>> commandBus, T1 param1, T2 param2, T3 param3)
        {
            var notification = ParameterNotification.Create(param1, param2, param3);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 4 arguments types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3, T4>(this ICommandBus<ParameterNotification<T1, T2, T3, T4>> commandBus, T1 param1, T2 param2, T3 param3, T4 param4)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 5 arguments types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3, T4, T5>(this ICommandBus<ParameterNotification<T1, T2, T3, T4, T5>> commandBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4, param5);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 6 arguments types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3, T4, T5, T6>(this ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6>> commandBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4, param5, param6);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 7 arguments types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3, T4, T5, T6, T7>(this ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7>> commandBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 8 arguments types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3, T4, T5, T6, T7, T8>(this ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>> commandBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 9 arguments types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9>> commandBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 10 arguments types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> commandBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 11 arguments types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> commandBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 12 arguments types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> commandBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 13 arguments types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> commandBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 14 arguments types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> commandBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 15 arguments types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> commandBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14, T15 param15)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15);
            return commandBus.Execute(ref notification);
        }

        /// <summary>
        /// Execute all handler's handle method in bus with 16 arguments types parameter notification.
        /// </summary>
        /// <param name="commandBus">Command Bus.</param>
        public static CommandOperation Execute<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this ICommandBus<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> commandBus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14, T15 param15, T16 param16)
        {
            var notification = ParameterNotification.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16);
            return commandBus.Execute(ref notification);
        }
    }
}