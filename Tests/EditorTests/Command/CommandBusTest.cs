using NUnit.Framework;
using PeroTools2.AccessKing.Editor.Tests.AccessTests;

namespace PeroTools2.AccessKing.Editor.Tests.CommandTests
{
    public class CommandBusTest : AccessBusTest
    {
        private static int s_HandleCount;

        [SetUp]
        public void SetUp()
        {
            s_HandleCount = 0;
        }

        [Test]
        public override void DispatchTest()
        {
            var testNotification = new TestNotification();
            var factory = new RegistryCommandHandlerFactory();
            var bus = new CommandBus<TestNotification>(factory);
            var testHandler = new TestHandler<TestNotification>();
            factory.RegisterHandler(testHandler);
            ((IAccessBus) bus).Dispatch(testNotification);
            Assert.IsTrue(testNotification.isSucceed);
        }

        [Test]
        public void CommandHandlerFactoryModifyTest()
        {
            var testNotification = new TestNotification();
            var factory1 = new RegistryCommandHandlerFactory();
            var factory2 = new RegistryCommandHandlerFactory();
            factory2.RegisterHandler(new TestHandler<TestNotification>());
            var bus = new CommandBus<TestNotification>(factory1);
            ((ICommandHandlerFactoryModifiable) bus).factory = factory2;
            bus.Execute(ref testNotification);
            Assert.IsTrue(testNotification.isSucceed);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        public void CommandBusExecuteTest(int handlerCount)
        {
            var testNotification = new TestNotification();
            var factory = new RegistryCommandHandlerFactory();
            var bus = new CommandBus<TestNotification>(factory);
            for (var i = 0; i < handlerCount; i++)
            {
                var testHandler = new TestHandler<TestNotification>();
                factory.RegisterHandler(testHandler);
            }

            bus.Execute(ref testNotification);
            if (handlerCount > 0)
                Assert.IsTrue(testNotification.isSucceed);
            Assert.IsTrue(s_HandleCount == handlerCount);
        }

        [TestCase(1, ExpectedResult = 0)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(10, ExpectedResult = 9)]
        public int CommandHandlerFactoryUnregisterTest(int handlerCount)
        {
            var testNotification = new TestNotification();
            var factory = new RegistryCommandHandlerFactory();
            var bus = new CommandBus<TestNotification>(factory);

            var handler = new TestHandler<TestNotification>();
            factory.RegisterHandler(handler);
            for (var i = 0; i < handlerCount - 1; i++)
            {
                var testHandler = new TestHandler<TestNotification>();
                factory.RegisterHandler(testHandler);
            }

            Assert.IsTrue(factory.UnregisterHandler(handler));
            bus.Execute(ref testNotification);
            if (handlerCount <= 1)
                Assert.IsFalse(testNotification.isSucceed);
            return s_HandleCount;
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 0)]
        [TestCase(2, ExpectedResult = 0)]
        [TestCase(10, ExpectedResult = 0)]
        public int CommandHandlerFactoryClearTest(int handlerCount)
        {
            var testNotification = new TestNotification();
            var factory = new RegistryCommandHandlerFactory();
            var bus = new CommandBus<TestNotification>(factory);
            for (var i = 0; i < handlerCount; i++)
            {
                var testHandler = new TestHandler<TestNotification>();
                factory.RegisterHandler(testHandler);
            }

            factory.ClearHandlers();
            bus.Execute(ref testNotification);
            Assert.IsFalse(testNotification.isSucceed);
            return s_HandleCount;
        }


        [Test]
        public void DifferentNotificationExecuteTest()
        {
            var factory = new RegistryCommandHandlerFactory();
            var testNotification = new TestNotification();
            var bus = new CommandBus<TestNotification>(factory);
            factory.RegisterHandler(new TestHandler<TestNotification>());
            factory.RegisterHandler(new TestHandler<OtherNotification>());
            var results = bus.Execute(ref testNotification).GetResults<string>();
            Assert.IsTrue(results.Count == 1);
        }

        private class TestHandler<TNotification> : ICommandHandler<TNotification, string> where TNotification : ITestNotification
        {
            public void Handle(ref TNotification notification)
            {
                s_HandleCount++;
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