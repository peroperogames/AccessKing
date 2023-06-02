using NUnit.Framework;

namespace PeroTools2.AccessKing
{
    public class CommandBusTest
    {
        [Test]
        public void CommandBusExecuteTest()
        {
            var testNotification = new TestNotification();
            var factory = new RegistryCommandHandlerFactory();
            var bus = new CommandBus<TestNotification>(factory);
            factory.RegisterHandler(new TestHandler());
            bus.Execute(ref testNotification);
            Assert.IsTrue(testNotification.isSucceed);
        }

        [Test]
        public void CommandBusUnregisterTest()
        {
            var testNotification = new TestNotification();
            var factory = new RegistryCommandHandlerFactory();
            var bus = new CommandBus<TestNotification>(factory);
            var handler = new TestHandler();
            factory.RegisterHandler(handler);
            Assert.IsTrue(factory.UnRegisterHandler(handler));
            bus.Execute(ref testNotification);
            Assert.IsFalse(testNotification.isSucceed);
        }

        private class TestHandler : ICommandHandler<TestNotification>
        {
            public void Handle(ref TestNotification notification)
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