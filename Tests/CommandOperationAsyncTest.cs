/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2026/10/22 19:10:00
 */

using System.Threading.Tasks;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Tests;

/// <summary>
/// Covers the Task based async helpers. The Unity configuration leaves them to the Unity layer, which implements the
/// same helpers on top of UniTask, so this fixture is compiled out of that configuration.
/// </summary>
public sealed class CommandOperationAsyncTest
{
    [Test]
    public async Task GetResultsAsyncTaskResultsTest()
    {
        var bus = NewBus(new TaskResultHandler(5));

        var results = await bus.Execute(new Counter()).GetResultsAsync<int>();

        Assert.That(results, Is.EqualTo(new[] { 5 }));
    }

    [Test]
    public async Task GetResultsAsyncMixedResultsTest()
    {
        var factory = new RegistryCommandHandlerFactory();
        factory.RegisterHandler(new NineHandler());
        factory.RegisterHandler(new TaskResultHandler(5));
        var bus = new CommandBus<Counter>(factory);

        var results = await bus.Execute(new Counter()).GetResultsAsync<int>();

        Assert.That(results, Is.EqualTo(new[] { 9, 5 }));
    }

    [Test]
    public async Task WhenAllDoneTest()
    {
        var handler = new SignalingTaskHandler();
        var bus = NewBus(handler);

        await bus.Execute(new Counter()).WhenAllDone();

        Assert.That(handler.finished, Is.True);
    }

    [Test]
    public async Task WhenAnyDoneTest()
    {
        var handler = new SignalingTaskHandler();
        var bus = NewBus(handler);

        await bus.Execute(new Counter()).WhenAnyDone();

        Assert.That(handler.finished, Is.True);
    }

    [Test]
    public void GetAllAsyncTasksTest()
    {
        var bus = NewBus(new SignalingTaskHandler());

        var tasks = bus.Execute(new Counter()).GetAllAsyncTasks(false);

        Assert.That(tasks, Has.Count.EqualTo(1));
        Assert.That(tasks[0], Is.Not.Null);
    }

    private static CommandBus<Counter> NewBus(ICommandHandler<Counter> handler)
    {
        var factory = new RegistryCommandHandlerFactory();
        factory.RegisterHandler(handler);
        return new CommandBus<Counter>(factory);
    }

    private sealed class TaskResultHandler : ICommandHandler<Counter, Task<int>>
    {
        private readonly int m_Value;

        public TaskResultHandler(int value) => m_Value = value;

        public void Handle(ref Counter notification)
        {
        }

        public Task<int> GetResult() => Task.FromResult(m_Value);

        object IResultAvailable.GetResult() => GetResult();
    }

    private sealed class SignalingTaskHandler : ICommandHandler<Counter, Task>
    {
        public bool finished;

        public void Handle(ref Counter notification)
        {
        }

        public async Task GetResult()
        {
            await Task.Delay(1);
            finished = true;
        }

        object IResultAvailable.GetResult() => GetResult();
    }
}