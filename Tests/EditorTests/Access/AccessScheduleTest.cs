using System;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Editor.Tests.AccessTests
{
    public abstract class AccessScheduleTest
    {
        protected const string theme = "TestTheme";

        protected abstract IAccessSchedule<TTheme> RequireAccessSchedule<TTheme>();
        protected abstract IAccessBus RequireAccessBus<TNotification>() where TNotification : INotification;

        [Test]
        public void AccessScheduleRequireByTypeThemeTest()
        {
            var schedule = RequireAccessSchedule<Type>();
            var bus = schedule.Require<TestBus>();
            Assert.IsTrue(schedule.ContainsBus(typeof(TestBus)));
            Assert.IsTrue(schedule.GetBus(typeof(TestBus)) == bus);
        }

        [Test]
        public void AccessScheduleRegisterTest()
        {
            var schedule = RequireAccessSchedule<string>();
            var bus = RequireAccessBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsTrue(schedule.ContainsBus(theme));
            Assert.IsTrue(schedule.GetBus(theme) == bus);
        }

        [Test]
        public void AccessScheduleRemoveThemeTest()
        {
            var schedule = RequireAccessSchedule<string>();
            var bus = RequireAccessBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsTrue(schedule.RemoveTheme(theme));
            Assert.IsFalse(schedule.ContainsBus(theme));
        }

        [Test]
        public void AccessScheduleRemoveBusTest()
        {
            var schedule = RequireAccessSchedule<string>();
            var bus = RequireAccessBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsTrue(schedule.RemoveBus(bus));
            Assert.IsFalse(schedule.ContainsBus(theme));
        }

        [Test]
        public void AccessScheduleClearTest()
        {
            var schedule = RequireAccessSchedule<string>();
            var bus = RequireAccessBus<TestNotification>();
            schedule.AddThemeMapping("1", bus);
            schedule.AddThemeMapping("2", bus);
            schedule.AddThemeMapping("3", bus);
            schedule.ClearTheme();
            foreach (var _ in schedule)
            {
                Assert.IsTrue(false);
            }
        }

        [Test]
        public void AccessScheduleAccessorTest()
        {
            var schedule = RequireAccessSchedule<string>();
            Assert.Catch(() => { _ = schedule[theme]; });
            var bus = RequireAccessBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsTrue(bus == schedule[theme]);
        }

        private class TestBus : ISchedulableCommandBus<TestNotification>, ISchedulableEventBus<TestNotification>
        {
            private ICommandHandlerFactory m_Factory;
            
            public void Dispatch(INotification notification) => throw new NotImplementedException();

            public CommandOperation Execute(ref TestNotification notification) => throw new NotImplementedException();

            public void SetFactory(ICommandHandlerFactory handlerFactory) => m_Factory = handlerFactory;

            public bool Unsubscribe(IEventHandler<TestNotification> handler) => throw new NotImplementedException();

            public void Subscribe(IEventHandler<TestNotification> handler) => throw new NotImplementedException();

            public void Broadcast(in TestNotification notification) => throw new NotImplementedException();

            public void Clear() => throw new NotImplementedException();
        }

        protected struct TestNotification : INotification { }
    }
}