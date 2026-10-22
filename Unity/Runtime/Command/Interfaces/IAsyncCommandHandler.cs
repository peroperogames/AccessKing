/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/23 16:05:45
 */

using Cysharp.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Command handler with async task.
    /// </summary>
    /// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
    public interface IAsyncCommandHandler<TNotification> : ICommandHandler<TNotification, UniTask>
        where TNotification : INotification { }

    /// <summary>
    /// Command handler with async task result.
    /// </summary>
    /// <typeparam name="TNotification">Implementation type of <see cref="INotification"/>.</typeparam>
    /// <typeparam name="TResult">Result of handling.</typeparam>
    public interface IAsyncCommandHandler<TNotification, TResult> : ICommandHandler<TNotification, UniTask<TResult>>
        where TNotification : INotification { }
}
