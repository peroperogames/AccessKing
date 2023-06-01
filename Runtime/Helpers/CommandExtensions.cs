using System;
using System.Text.RegularExpressions;

namespace PeroTools2.AccessKing
{
    public static class CommandExtensions
    {
        internal static Type GetNotificationType<TBus>() where TBus : ICommandBus
        {
            Type notificationType = null;
            var commandBusName = typeof(ICommandBus<,>).FullName;
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

        public static TOperation Execute<TOperation>(this ICommandBus<ParameterNotification, TOperation> bus) where TOperation : ICommandOperation
            => bus.Execute(ParameterNotification.Default);

        public static TOperation Execute<T, TOperation>(this ICommandBus<ParameterNotification<T>, TOperation> bus, T param) where TOperation : ICommandOperation
            => bus.Execute(ParameterNotification.Create(param));

        public static TOperation Execute<T1, T2, TOperation>(this ICommandBus<ParameterNotification<T1, T2>, TOperation> bus, T1 param1, T2 param2) where TOperation : ICommandOperation
            => bus.Execute(ParameterNotification.Create(param1, param2));

        public static TOperation Execute<T1, T2, T3, TOperation>(this ICommandBus<ParameterNotification<T1, T2, T3>, TOperation> bus, T1 param1, T2 param2, T3 param3) where TOperation : ICommandOperation
            => bus.Execute(ParameterNotification.Create(param1, param2, param3));

        public static TOperation Execute<T1, T2, T3, T4, TOperation>(this ICommandBus<ParameterNotification<T1, T2, T3, T4>, TOperation> bus, T1 param1, T2 param2, T3 param3, T4 param4) where TOperation : ICommandOperation
            => bus.Execute(ParameterNotification.Create(param1, param2, param3, param4));

        public static TOperation Execute<T1, T2, T3, T4, T5, TOperation>(this ICommandBus<ParameterNotification<T1, T2, T3, T4, T5>, TOperation> bus, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5) where TOperation : ICommandOperation
            => bus.Execute(ParameterNotification.Create(param1, param2, param3, param4, param5));
    }
}