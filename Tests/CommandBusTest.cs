/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/01 17:06:57
 */

using System.Threading.Tasks;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Tests;

public sealed class CommandBusTest
{
    private static int s_HandleCount;

    [SetUp]
    public void SetUp()
    {
        s_HandleCount = 0;
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void CommandBusExecuteTest(int handlerCount)
    {
        var testNotification = new CheckNotification();
        var factory = new RegistryCommandHandlerFactory();
        var bus = new CommandBus<CheckNotification>(factory);
        for (var i = 0; i < handlerCount; i++)
        {
            factory.RegisterHandler(new TestHandler<CheckNotification>());
        }

        bus.Execute(ref testNotification);
        Assert.That(s_HandleCount == handlerCount, Is.True);
    }

    [TestCase(1, ExpectedResult = 0)]
    [TestCase(2, ExpectedResult = 1)]
    [TestCase(10, ExpectedResult = 9)]
    public int CommandHandlerFactoryUnregisterTest(int handlerCount)
    {
        var testNotification = new CheckNotification();
        var factory = new RegistryCommandHandlerFactory();
        var bus = new CommandBus<CheckNotification>(factory);

        var handler = new TestHandler<CheckNotification>();
        factory.RegisterHandler(handler);
        for (var i = 0; i < handlerCount - 1; i++)
        {
            var testHandler = new TestHandler<CheckNotification>();
            factory.RegisterHandler(testHandler);
        }

        Assert.That(factory.UnregisterHandler(handler), Is.True);
        bus.Execute(ref testNotification);
        if (handlerCount <= 1)
        {
            Assert.That(testNotification.isSucceed, Is.False);
        }
        return s_HandleCount;
    }

    [TestCase(0, ExpectedResult = 0)]
    [TestCase(1, ExpectedResult = 0)]
    [TestCase(2, ExpectedResult = 0)]
    [TestCase(10, ExpectedResult = 0)]
    public int CommandHandlerFactoryClearTest(int handlerCount)
    {
        var testNotification = new CheckNotification();
        var factory = new RegistryCommandHandlerFactory();
        var bus = new CommandBus<CheckNotification>(factory);
        for (var i = 0; i < handlerCount; i++)
        {
            var testHandler = new TestHandler<CheckNotification>();
            factory.RegisterHandler(testHandler);
        }

        factory.ClearHandlers();
        bus.Execute(ref testNotification);
        Assert.That(testNotification.isSucceed, Is.False);
        return s_HandleCount;
    }

    [Test]
    public void DifferentNotificationExecuteTest()
    {
        var factory = new RegistryCommandHandlerFactory();
        var testNotification = new CheckNotification();
        var bus = new CommandBus<CheckNotification>(factory);
        factory.RegisterHandler(new TestHandler<CheckNotification>());
        factory.RegisterHandler(new TestHandler<OtherNotification>());
        var results = bus.Execute(ref testNotification).GetResults<string>();
        Assert.That(results.Count == 1, Is.True);
    }

    private sealed class TestHandler<TNotification> : ICommandHandler<TNotification, string> where TNotification : ITestNotification
    {
        public void Handle(ref TNotification notification)
        {
            s_HandleCount++;
        }

        public string GetResult() => "Test";

        object IResultAvailable.GetResult() => "Test";
    }

    private interface ITestNotification : INotification;

    private sealed class CheckNotification : ITestNotification
    {
        public bool isSucceed { get; set; }
    }

    private sealed class OtherNotification : ITestNotification;
}