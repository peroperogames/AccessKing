namespace PeroTools2.AccessKing
{
    public interface ICommandSchedule<in TTheme>
    {
        void AddFactory(TTheme theme, ICommandHandlerFactory factory);
        bool ContainsFactory(TTheme theme);
        bool TryGetBus<TNotification, TOperation>(TTheme theme, out ICommandBus<TNotification, TOperation> bus) where TNotification : INotification where TOperation : ICommandOperation;

        TBus AddBus<TBus, TNotification, TOperation>(TTheme theme)
            where TBus : CommandBus<TNotification, TOperation>
            where TOperation : ICommandOperation
            where TNotification : INotification;
    }
}