/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2026/10/20 21:40:00
 */

using System;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Tests;

public sealed class CommandOperationTest
{
    [Test]
    public void GetResultsTwiceTest()
    {
        var bus = NewBus(new NineHandler());
        var operation = bus.Execute(new Counter());

        operation.GetResults<int>();

        Assert.Throws<InvalidOperationException>(() => operation.GetResults<int>());
    }

    [Test]
    public void DefaultOperationGetResultsTest()
    {
        CommandOperation operation = default;

        Assert.Throws<InvalidOperationException>(() => operation.GetResults<int>());
    }

    [Test]
    public void DisposeRepeatTest()
    {
        var bus = NewBus(new NineHandler());

        for (var index = 0; index < 8; index++)
        {
            var operation = bus.Execute(new Counter());
            operation.Dispose();
            operation.Dispose();
        }

        var results = bus.Execute(new Counter()).GetResults<int>();

        Assert.That(results, Is.EqualTo(new[] { 9 }));
    }

    [Test]
    public void ThrowingHandlerKeepsPoolUsableTest()
    {
        var throwingBus = NewBus(new ThrowingCommandHandler());
        Assert.Throws<InvalidOperationException>(() => throwingBus.Execute(new Counter()).Dispose());

        var healthyBus = NewBus(new NineHandler());
        var results = healthyBus.Execute(new Counter()).GetResults<int>();

        Assert.That(results, Is.EqualTo(new[] { 9 }));
    }

    private static CommandBus<Counter> NewBus(ICommandHandler<Counter> handler)
    {
        var factory = new RegistryCommandHandlerFactory();
        factory.RegisterHandler(handler);
        return new CommandBus<Counter>(factory);
    }
}