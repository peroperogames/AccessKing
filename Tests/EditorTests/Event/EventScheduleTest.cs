/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/06 21:06:07
 */

using System;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Editor.Tests
{
    public sealed class EventScheduleTest : AccessScheduleTest
    {
        [Test]
        public void EventScheduleRegisterTest()
        {
            var schedule = new EventSchedule<string>();
            var bus = new EventBus<TestNotification>();
            schedule.AddBus(theme, bus);
            Assert.IsTrue(schedule.ContainsBus(theme));
            Assert.IsTrue(schedule.GetBus<TestNotification>(theme) == bus);
        }

        [Test]
        public void EventScheduleRegisterRepeatTest()
        {
            var schedule = new EventSchedule<string>();
            Assert.Catch(() =>
            {
                schedule.AddBus(theme, new EventBus<TestNotification>());
                schedule.AddBus(theme, new EventBus<TestNotification>());
            });
        }

        [Test]
        public void EventScheduleRemoveThemeTest()
        {
            var schedule = new EventSchedule<string>();
            var bus = new EventBus<TestNotification>();
            schedule.AddBus(theme, bus);
            Assert.IsTrue(schedule.RemoveBus(theme));
            Assert.IsFalse(schedule.ContainsBus(theme));
        }

        [Test]
        public void EventScheduleRemoveBusTest()
        {
            var schedule = new EventSchedule<string>();
            var bus = new EventBus<TestNotification>();
            schedule.AddBus(theme, bus);
            Assert.IsTrue(schedule.RemoveBus(bus));
            Assert.IsFalse(schedule.ContainsBus(theme));
        }

        [Test]
        public void EventScheduleTryGetBusTest()
        {
            var schedule = new EventSchedule<string>();
            var bus = new EventBus<TestNotification>();
            schedule.AddBus(theme, bus);
            Assert.IsTrue(schedule.TryGetBus<TestNotification>(theme, out _));
            schedule.RemoveBus(theme);
            Assert.IsFalse(schedule.TryGetBus<TestNotification>(theme, out _));
        }

        [Test]
        public void EventScheduleGetBusTest()
        {
            var schedule = new EventSchedule<string>();
            var bus = new EventBus<TestNotification>();
            schedule.AddBus(theme, bus);
            Assert.IsNotNull(schedule.GetBus<TestNotification>(theme));
            schedule.RemoveBus(theme);
            Assert.Catch(() => schedule.GetBus<TestNotification>(theme));
        }

        [Test]
        public void EventScheduleRequireByStringThemeTest()
        {
            var schedule = new EventSchedule<string>();
            var bus = schedule.Require<int>(theme);
            Assert.IsTrue(schedule.ContainsBus(theme));
            Assert.IsTrue(schedule.GetBus<ParameterNotification<int>>(theme) == bus);
        }

        [Test]
        public void EventScheduleRequireByTypeThemeTest()
        {
            var schedule = new EventSchedule<Type>();
            var bus = schedule.Require<TestBus>();
            Assert.IsTrue(schedule.ContainsBus(typeof(TestBus)));
            Assert.IsTrue(schedule.GetBus<TestNotification>(typeof(TestBus)) == bus);
        }

        protected override IAccessSchedule<TTheme> RequireAccessSchedule<TTheme>() => new EventSchedule<TTheme>();

        protected override object RequireAccessBus<TNotification>() => new TestBus();

        private class TestBus : IEventBus<TestNotification>
        {
            public void Subscribe(IEventHandler<TestNotification> handler) => throw new NotImplementedException();

            public bool Unsubscribe(IEventHandler<TestNotification> handler) => throw new NotImplementedException();

            public void Clear() => throw new NotImplementedException();

            public void Broadcast(in TestNotification notification) => throw new NotImplementedException();
        }
    }
}