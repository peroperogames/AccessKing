/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/01 16:06:12
 */

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Tests;

public sealed class EventBusTest
{
    private static int s_HandleCount;
    private IEventHandler<TestNotification> m_Handler;

    [SetUp]
    public void SetUp()
    {
        s_HandleCount = 0;
        m_Handler = null;
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void EventBusBroadcastTest(int handlerCount)
    {
        var testNotification = new TestNotification();
        var bus = new EventBus<TestNotification>();
        for (var i = 0; i < handlerCount; i++)
        {
            var testHandler = new TestHandler<TestNotification>();
            bus.Subscribe(testHandler);
        }

        bus.Broadcast(testNotification);
        if (handlerCount > 0)
            Assert.That(testNotification.isSucceed, Is.True);
        Assert.That(s_HandleCount == handlerCount, Is.True);
    }

    [TestCase(1, ExpectedResult = 0)]
    [TestCase(2, ExpectedResult = 1)]
    [TestCase(10, ExpectedResult = 9)]
    public int EventBusUnsubscribeTest(int handlerCount)
    {
        var testNotification = new TestNotification();
        var bus = new EventBus<TestNotification>();
        var handler = new TestHandler<TestNotification>();
        bus.Subscribe(handler);
        for (var i = 0; i < handlerCount - 1; i++)
        {
            var testHandler = new TestHandler<TestNotification>();
            bus.Subscribe(testHandler);
        }

        Assert.That(bus.Unsubscribe(handler), Is.True);
        bus.Broadcast(testNotification);
        if (handlerCount <= 1)
            Assert.That(testNotification.isSucceed, Is.False);
        return s_HandleCount;
    }

    [TestCase(0, ExpectedResult = 0)]
    [TestCase(1, ExpectedResult = 0)]
    [TestCase(2, ExpectedResult = 0)]
    [TestCase(10, ExpectedResult = 0)]
    public int EventBusClearTest(int handlerCount)
    {
        var testNotification = new TestNotification();
        var bus = new EventBus<TestNotification>();
        for (var i = 0; i < handlerCount; i++)
        {
            var handler = new TestHandler<TestNotification>();
            bus.Subscribe(handler);
        }
        bus.Clear();
        bus.Broadcast(testNotification);
        Assert.That(testNotification.isSucceed, Is.False);
        return s_HandleCount;
    }

    [TestCase(true, true, ExpectedResult = true)]
    [TestCase(true, false, ExpectedResult = true)]
    [TestCase(false, true, ExpectedResult = false)]
    [TestCase(false, false, ExpectedResult = true)]
    public bool EventBusSubscribeWeaklyTest(bool isKeepInstanceAlive, bool isInvokeGC)
    {
        var bus = new EventBus<TestNotification>();
        if (!isKeepInstanceAlive)
            CreateInstanceAndForget(bus);
        else
            m_Handler = CreateInstance(bus);

        CreateBlob(10);

        if (isInvokeGC)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        var notification = new TestNotification();
        bus.Broadcast(notification);
        return notification.isSucceed;

        [MethodImpl(MethodImplOptions.NoInlining)]
        static void CreateInstanceAndForget(EventBus<TestNotification> eventBus)
        {
            var handler = new TestHandler<TestNotification>();
            eventBus.SubscribeWeakly(handler);
        }
    }

    [Test]
    public void ConsecutiveWeakEventCalls()
    {
        IEventBus<Empty> bus = new EventBus<Empty>();
        {
            var handler1 = new TestWeakEventHandler(null);
            var handler2 = new TestWeakEventHandler(null);
            var handler3 = new TestWeakEventHandler(() => handler2.isAlive = false);
            var handler4 = new TestWeakEventHandler(() => handler1.isAlive = false);
            bus.SubscribeWeakly(handler4);
            bus.SubscribeWeakly(handler3);
            bus.SubscribeWeakly(handler2);
            bus.SubscribeWeakly(handler1);
            bus.Broadcast();
            Assert.That(handler1.isAlive, Is.False);
            Assert.That(handler2.isAlive, Is.False);
            Assert.That(handler3.isAlive, Is.True);
            Assert.That(handler4.isAlive, Is.True);
            Assert.That(handler1.invokedCount, Is.EqualTo(0));
            Assert.That(handler2.invokedCount, Is.EqualTo(0));
            Assert.That(handler3.invokedCount, Is.EqualTo(1));
            Assert.That(handler4.invokedCount, Is.EqualTo(1));
        }
        {
            ((IWeakEventSubscriable<Empty>) bus).Clear();
            var handler = new TestWeakEventHandler(null);
            handler.onHandle = () =>
            {
                handler.isAlive = false;
                bus.Broadcast();
            };
            bus.SubscribeWeakly(handler);
            Assert.Catch<InvalidOperationException>(() => { bus.Broadcast(); });
        }
    }

    private TestHandler<TestNotification> CreateInstance(EventBus<TestNotification> eventBus)
    {
        var handler = new TestHandler<TestNotification>();
        eventBus.SubscribeWeakly(handler);
        return handler;
    }

    private static void CreateBlob(int count)
    {
        List<Blob> trash = [];
        for (var i = 0; i < count; i++)
        {
            trash.Add(new Blob());
        }

        trash.Clear();
    }

    private class TestHandler<TNotification> : IEventHandler<TNotification> where TNotification : ITestNotification
    {
        public void Handle(in TNotification notification)
        {
            s_HandleCount++;
            notification.isSucceed = true;
        }
    }

    private interface ITestNotification : INotification
    {
        bool isSucceed { get; set; }
    }

    private class TestNotification : ITestNotification
    {
        public bool isSucceed { get; set; }
    }

    private class TestWeakEventHandler : IWeakEventHandler
    {
        /// <inheritdoc />
        public bool isAlive { get; set; } = true;

        public int invokedCount;
        public Action onHandle;

        public TestWeakEventHandler(Action onHandle) => this.onHandle = onHandle;

        /// <inheritdoc />
        public bool TryHandle(in Empty notification)
        {
            if (isAlive)
            {
                onHandle?.Invoke();
                invokedCount++;
            }
            return isAlive;
        }

        /// <inheritdoc />
        public void Handle(in Empty notification)
        {
            if (isAlive)
            {
                onHandle?.Invoke();
                invokedCount++;
            }
        }
    }
}