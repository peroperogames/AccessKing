namespace PeroTools2.AccessKing
{
    public static class CommandExtensions
    {
        public static TOperation Execute<TOperation>(this CommandExecutive<ParameterNotification, TOperation> exec) where TOperation : ICommandOperation
            => exec.Execute(ParameterNotification.Default);

        public static TOperation Execute<T, TOperation>(this CommandExecutive<ParameterNotification<T>, TOperation> exec, T param) where TOperation : ICommandOperation
            => exec.Execute(ParameterNotification.Create(param));

        public static TOperation Execute<T1, T2, TOperation>(this CommandExecutive<ParameterNotification<T1, T2>, TOperation> exec, T1 param1, T2 param2) where TOperation : ICommandOperation
            => exec.Execute(ParameterNotification.Create(param1, param2));

        public static TOperation Execute<T1, T2, T3, TOperation>(this CommandExecutive<ParameterNotification<T1, T2, T3>, TOperation> exec, T1 param1, T2 param2, T3 param3) where TOperation : ICommandOperation
            => exec.Execute(ParameterNotification.Create(param1, param2, param3));

        public static TOperation Execute<T1, T2, T3, T4, TOperation>(this CommandExecutive<ParameterNotification<T1, T2, T3, T4>, TOperation> exec, T1 param1, T2 param2, T3 param3, T4 param4) where TOperation : ICommandOperation
            => exec.Execute(ParameterNotification.Create(param1, param2, param3, param4));

        public static TOperation Execute<T1, T2, T3, T4, T5, TOperation>(this CommandExecutive<ParameterNotification<T1, T2, T3, T4, T5>, TOperation> exec, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5) where TOperation : ICommandOperation
            => exec.Execute(ParameterNotification.Create(param1, param2, param3, param4, param5));
    }
}