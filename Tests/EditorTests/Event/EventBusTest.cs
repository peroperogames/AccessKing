using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;
using PeroTools2.AccessKing.Editor.Tests.AccessTests;

namespace PeroTools2.AccessKing.Editor.Tests.EventTests
{
    public class EventBusTest : AccessBusTest
    {
        private static int s_HandleCount;
        private IEventHandler<TestNotification> m_Handler;

        [SetUp]
        public void SetUp()
        {
            s_HandleCount = 0;
            m_Handler = null;
        }
        
        [Test]
        public override void DispatchTest()
        {
            var testNotification = new TestNotification();
            var bus = new EventBus<TestNotification>();
            var testHandler = new TestHandler<TestNotification>();
            bus.Subscribe(testHandler);
            ((IAccessBus)bus).Dispatch(testNotification);
            Assert.IsTrue(testNotification.isSucceed);
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
                Assert.IsTrue(testNotification.isSucceed);
            Assert.IsTrue(s_HandleCount == handlerCount);
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

            Assert.IsTrue(bus.Unsubscribe(handler));
            bus.Broadcast(testNotification);
            if (handlerCount <= 1)
                Assert.IsFalse(testNotification.isSucceed);
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
            for (int i = 0; i < handlerCount; i++)
            {
                var handler = new TestHandler<TestNotification>();
                bus.Subscribe(handler);
            }
            bus.Clear();
            bus.Broadcast(testNotification);
            Assert.IsFalse(testNotification.isSucceed);
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
                CreateInstance(bus);
            else
                m_Handler = CreateInstance(bus);

            CreateBigMemory(10);

            if (isInvokeGC)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            var notification = new TestNotification();
            bus.Broadcast(notification);
            return notification.isSucceed;
        }

        private TestHandler<TestNotification> CreateInstance(EventBus<TestNotification> eventBus)
        {
            var handler = new TestHandler<TestNotification>();
            eventBus.SubscribeWeakly(handler);
            return handler;
        }

        private static void CreateBigMemory(int count)
        {
            var programs = new List<Data>();
            for (var i = 0; i < count; i++)
            {
                programs.Add(new Data());
            }

            programs.Clear();
            programs = null;
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

        private class OtherNotification : ITestNotification
        {
            public bool isSucceed { get; set; }
        }

        private class TestNotification : ITestNotification
        {
            public bool isSucceed { get; set; }
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public class Data
    {
        [FieldOffset(0)] public long a = 0;
        [FieldOffset(67789)] long a2 = 0;
    }
}