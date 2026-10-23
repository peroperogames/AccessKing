/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2026/10/20 21:40:00
 */

using System;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Tests;

[TestFixture]
internal sealed class CommandOperationTests
{
    [Test]
    public void Consuming_the_results_twice_throws()
    {
        var bus = NewBus(new NineHandler());
        var operation = bus.Execute(new Counter());

        operation.GetResults<int>();

        Assert.Throws<InvalidOperationException>(() => operation.GetResults<int>());
    }

    [Test]
    public void Reading_the_default_operation_throws()
    {
        CommandOperation operation = default;

        Assert.Throws<InvalidOperationException>(() => operation.GetResults<int>());
    }

    [Test]
    public void Dispose_is_idempotent_and_keeps_the_pool_usable()
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
    public void A_throwing_handler_does_not_poison_the_pooled_collections()
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