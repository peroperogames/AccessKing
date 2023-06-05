using NUnit.Framework;

namespace PeroTools2.AccessKing.Editor.Tests
{
    public class CommandBusTest
    {
        [Test]
        public void CommandBusExecuteTest()
        {
            var testNotification = new TestNotification();
            var factory = new RegistryCommandHandlerFactory();
            var bus = new CommandBus<TestNotification>(factory);
            factory.RegisterHandler(new TestHandler<TestNotification>());
            bus.Execute(ref testNotification);
            Assert.IsTrue(testNotification.isSucceed);
        }

        [Test]
        public void CommandFactoryUnregisterTest()
        {
            var testNotification = new TestNotification();
            var factory = new RegistryCommandHandlerFactory();
            var bus = new CommandBus<TestNotification>(factory);
            var handler = new TestHandler<TestNotification>();
            factory.RegisterHandler(handler);
            Assert.IsTrue(factory.UnregisterHandler(handler));
            bus.Execute(ref testNotification);
            Assert.IsFalse(testNotification.isSucceed);
        }
        
        [Test]
        public void DifferentNotificationExecuteTest()
        {
            var factory = new RegistryCommandHandlerFactory();
            var testNotification = new TestNotification();
            var bus = new CommandBus<TestNotification>(factory);
            factory.RegisterHandler(new TestHandler<TestNotification>());
            factory.RegisterHandler(new TestHandler<OtherNotification>());
            var  results = bus.Execute(ref testNotification).GetResults<string>();
            Assert.IsTrue(results.Count == 1);
        }
        
        

        private class TestHandler<TNotification> : ICommandHandler<TNotification,string> where TNotification : ITestNotification
        {
            public void Handle(ref TNotification notification)
            {
                notification.isSucceed = true;
            }

            public string GetResult() => "Test";

            object IResultAvailable.GetResult() => "Test";
        }
        
        private interface ITestNotification : INotification
        {
            bool isSucceed { get; set; }
        }

        private class TestNotification : ITestNotification
        {
            public bool isSucceed { get; set; }
        }
        private class OtherNotification : ITestNotification
        {
            public bool isSucceed { get; set; }
        }
    }
}