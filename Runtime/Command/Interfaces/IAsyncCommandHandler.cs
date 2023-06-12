/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年05月23日
 * Description: CommandHandler with task result.
 */

using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public interface ITaskCommandHandler<TNotification, out TTaskResult> : ICommandHandler<TNotification, TTaskResult>
        where TNotification : INotification 
        where TTaskResult : Task { }
    
    public interface IAsyncCommandHandler<TNotification> : ITaskCommandHandler<TNotification, Task> 
        where TNotification : INotification { }
    
    public interface IAsyncCommandHandler<TNotification, TResult> : ITaskCommandHandler<TNotification, Task<TResult>> 
        where TNotification : INotification { }
}