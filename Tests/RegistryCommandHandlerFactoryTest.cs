/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/13 14:12:18
 */

using System;
using System.Linq;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Tests;

public sealed class RegistryCommandHandlerFactoryTest
{
    [Test]
    public void FactoryRegisterHandlerTest()
    {
        var factory = new RegistryCommandHandlerFactory();
        var handler = new TestHandler();
        factory.RegisterHandler(handler);
        var handlers = factory.GetHandlers<TestNotification>().ToArray();
        Assert.That(handlers.Length == 1, Is.True);
        Assert.That(Equals(handlers.FirstOrDefault(), handler), Is.True);
    }

    [Test]
    public void FactoryUnregisterHandlerTest()
    {
        var factory = new RegistryCommandHandlerFactory();
        var handler = new TestHandler();
        factory.RegisterHandler(handler);
        factory.UnregisterHandler(handler);
        var handlers = factory.GetHandlers<TestNotification>().ToArray();
        Assert.That(handlers.Length == 0, Is.True);
    }

    [Test]
    public void FactoryClearTest()
    {
        var factory = new RegistryCommandHandlerFactory();
        factory.RegisterHandler(new TestHandler());
        factory.RegisterHandler(new TestHandler());
        factory.ClearHandlers();
        Assert.That(factory.GetHandlers<TestNotification>().ToArray().Length == 0, Is.True);
    }

    private sealed class TestHandler : ICommandHandler<TestNotification>
    {
        public void Handle(ref TestNotification notification) => throw new NotImplementedException();
    }
}