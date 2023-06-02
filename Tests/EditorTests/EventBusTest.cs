using NUnit.Framework;

namespace PeroTools2.AccessKing.Editor.Tests
{
    public class EventBusTest
    {
        [Test]
        public void EventBusBroadcastTest()
        {
            var testNotification = new TestNotification();
            var bus = new EventBus<TestNotification>();
            bus.Subscribe(new TestHandler());
            bus.Broadcast(testNotification);
            Assert.IsTrue(testNotification.isSucceed);
        }
        
        [Test]
        public void EventBusUnregisterTest()
        {
            var testNotification = new TestNotification();
            var bus = new EventBus<TestNotification>();
            var handler = new TestHandler();
            bus.Subscribe(handler);
            Assert.IsTrue(bus.Unsubscribe(handler));
            bus.Broadcast(testNotification);
            Assert.IsFalse(testNotification.isSucceed);
        }

        private class TestHandler : IEventHandler<TestNotification>
        {
            public void Handle(in TestNotification notification)
            {
                notification.isSucceed = true;
            }
        }

        private class TestNotification : INotification
        {
            public bool isSucceed;
        }
    }
}