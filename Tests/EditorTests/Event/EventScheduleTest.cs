using System;
using NUnit.Framework;
using PeroTools2.AccessKing.Editor.Tests.AccessTests;

namespace PeroTools2.AccessKing.Editor.Tests.EventTests
{
    public class EventScheduleTest : AccessScheduleTest
    {
        [Test]
        public void EventScheduleRegisterTest()
        {
            var schedule = new EventSchedule<string>();
            var bus = new EventBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsTrue(schedule.ContainsBus(theme));
            Assert.IsTrue(schedule.GetBus<TestNotification>(theme) == bus);
        }

        [Test]
        public void EventScheduleRegisterRepeatTest()
        {
            var schedule = new EventSchedule<string>();
            Assert.Catch(() =>
            {
                schedule.AddThemeMapping(theme, new EventBus<TestNotification>());
                schedule.AddThemeMapping(theme, new EventBus<TestNotification>());
            });
        }

        [Test]
        public void EventScheduleRemoveThemeTest()
        {
            var schedule = new EventSchedule<string>();
            var bus = new EventBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsTrue(schedule.RemoveTheme(theme));
            Assert.IsFalse(schedule.ContainsBus(theme));
        }

        [Test]
        public void EventScheduleRemoveBusTest()
        {
            var schedule = new EventSchedule<string>();
            var bus = new EventBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsTrue(schedule.RemoveBus(bus));
            Assert.IsFalse(schedule.ContainsBus(theme));
        }

        [Test]
        public void EventScheduleTryGetBusTest()
        {
            var schedule = new EventSchedule<string>();
            var bus = new EventBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsTrue(schedule.TryGetBus<TestNotification>(theme, out _));
            schedule.RemoveTheme(theme);
            Assert.IsFalse(schedule.TryGetBus<TestNotification>(theme, out _));
        }

        [Test]
        public void EventScheduleGetBusTest()
        {
            var schedule = new EventSchedule<string>();
            var bus = new EventBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsNotNull(schedule.GetBus<TestNotification>(theme));
            schedule.RemoveTheme(theme);
            Assert.Catch(() => schedule.GetBus<TestNotification>(theme));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void EventScheduleRequireByStringThemeTest(int argumentCount)
        {
            var schedule = new EventSchedule<string>();
            switch (argumentCount)
            {
                case 0:
                    var bus0 = schedule.Require(theme);
                    Assert.IsTrue(schedule.ContainsBus(theme));
                    Assert.IsTrue(schedule.GetBus<Empty>(theme) == bus0);
                    break;
                case 1:
                    var bus1 = schedule.Require<object>(theme);
                    Assert.IsTrue(schedule.ContainsBus(theme));
                    Assert.IsTrue(schedule.GetBus<ParameterNotification<object>>(theme) == bus1);
                    break;
                case 2:
                    var bus2 = schedule.Require<object, object>(theme);
                    Assert.IsTrue(schedule.ContainsBus(theme));
                    Assert.IsTrue(schedule.GetBus<ParameterNotification<object, object>>(theme) == bus2);
                    break;
                case 3:
                    var bus3 = schedule.Require<object, object, object>(theme);
                    Assert.IsTrue(schedule.ContainsBus(theme));
                    Assert.IsTrue(schedule.GetBus<ParameterNotification<object, object, object>>(theme) == bus3);
                    break;
                case 4:
                    var bus4 = schedule.Require<object, object, object, object>(theme);
                    Assert.IsTrue(schedule.ContainsBus(theme));
                    Assert.IsTrue(schedule.GetBus<ParameterNotification<object, object, object, object>>(theme) == bus4);
                    break;
                case 5:
                    var bus5 = schedule.Require<object, object, object, object, object>(theme);
                    Assert.IsTrue(schedule.ContainsBus(theme));
                    Assert.IsTrue(schedule.GetBus<ParameterNotification<object, object, object, object, object>>(theme) == bus5);
                    break;
            }
        }

        protected override IAccessSchedule<TTheme> RequireAccessSchedule<TTheme>()
        {
            return new EventSchedule<TTheme>();
        }

        protected override IAccessBus RequireAccessBus<TNotification>()
        {
            return new EventBus<TNotification>();
        }
    }
}