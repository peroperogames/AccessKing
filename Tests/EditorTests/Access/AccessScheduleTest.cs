/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/07 17:06:05
 */

using NUnit.Framework;

namespace PeroTools2.AccessKing.Editor.Tests
{
    public abstract class AccessScheduleTest
    {
        protected const string theme = "TestTheme";
        protected abstract IAccessSchedule<TTheme> RequireAccessSchedule<TTheme>();
        protected abstract object RequireAccessBus<TNotification>() where TNotification : INotification;

        [Test]
        public void AccessScheduleRegisterTest()
        {
            var schedule = RequireAccessSchedule<string>();
            var bus = RequireAccessBus<TestNotification>();
            schedule.AddBus(theme, bus);
            Assert.IsTrue(schedule.ContainsBus(theme));
            Assert.IsTrue(schedule.GetBus(theme) == bus);
        }

        [Test]
        public void AccessScheduleRemoveBusTest()
        {
            var schedule = RequireAccessSchedule<string>();
            var bus = RequireAccessBus<TestNotification>();
            schedule.AddBus(theme, bus);
            Assert.IsTrue(schedule.RemoveBus(theme));
            Assert.IsFalse(schedule.ContainsBus(theme));
        }

        [Test]
        public void AccessScheduleClearTest()
        {
            var schedule = RequireAccessSchedule<string>();
            var bus = RequireAccessBus<TestNotification>();
            schedule.AddBus("1", bus);
            schedule.AddBus("2", bus);
            schedule.AddBus("3", bus);
            schedule.Clear();
            Assert.IsTrue(schedule.busCount == 0);
        }

        [Test]
        public void AccessScheduleAccessorTest()
        {
            var schedule = RequireAccessSchedule<string>();
            Assert.Catch(() => { _ = schedule.GetBus(theme); });
            var bus = RequireAccessBus<TestNotification>();
            schedule.AddBus(theme, bus);
            Assert.IsTrue(bus == schedule.GetBus(theme));
        }

        protected struct TestNotification : INotification { }
    }
}