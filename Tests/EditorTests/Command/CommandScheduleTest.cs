/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/07 16:06:40
 */

using System;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Editor.Tests.CommandTests
{
    public sealed class CommandScheduleTest : AccessScheduleTest
    {
        [Test]
        public void CommandScheduleRegisterTest()
        {
            var schedule = new CommandSchedule<string>();
            var bus = new CommandBus<TestNotification>();
            schedule.AddBus(theme, bus);
            Assert.IsTrue(schedule.ContainsBus(theme));
            Assert.IsTrue(schedule.GetBus<TestNotification>(theme) == bus);
        }

        [Test]
        public void CommandScheduleRegisterRepeatTest()
        {
            var schedule = new CommandSchedule<string>();
            Assert.Catch(() =>
            {
                schedule.AddBus(theme, new CommandBus<TestNotification>());
                schedule.AddBus(theme, new CommandBus<TestNotification>());
            });
        }

        [Test]
        public void CommandScheduleRemoveThemeTest()
        {
            var schedule = new CommandSchedule<string>();
            var bus = new CommandBus<TestNotification>();
            schedule.AddBus(theme, bus);
            Assert.IsTrue(schedule.RemoveBus(theme));
            Assert.IsFalse(schedule.ContainsBus(theme));
        }

        [Test]
        public void CommandScheduleRemoveBusTest()
        {
            var schedule = new CommandSchedule<string>();
            var bus = new CommandBus<TestNotification>();
            schedule.AddBus(theme, bus);
            Assert.IsTrue(schedule.RemoveBus(bus));
            Assert.IsFalse(schedule.ContainsBus(theme));
        }

        [Test]
        public void CommandScheduleTryGetBusTest()
        {
            var schedule = new CommandSchedule<string>();
            var bus = new CommandBus<TestNotification>();
            schedule.AddBus(theme, bus);
            Assert.IsTrue(schedule.TryGetBus<TestNotification>(theme, out _));
            schedule.RemoveBus(theme);
            Assert.IsFalse(schedule.TryGetBus<TestNotification>(theme, out _));
        }

        [Test]
        public void CommandScheduleGetBusTest()
        {
            var schedule = new CommandSchedule<string>();
            var bus = new CommandBus<TestNotification>();
            schedule.AddBus(theme, bus);
            Assert.IsNotNull(schedule.GetBus<TestNotification>(theme));
            schedule.RemoveBus(theme);
            Assert.Catch(() => schedule.GetBus<TestNotification>(theme));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void CommandScheduleRequireByStringThemeTest(int argumentCount)
        {
            var schedule = new CommandSchedule<string>();
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

        [Test]
        public void CommandScheduleRequireByTypeThemeTest()
        {
            var schedule = new CommandSchedule<Type>();
            var bus = schedule.Require<TestBus>();
            Assert.IsTrue(schedule.ContainsBus(typeof(TestBus)));
            Assert.IsTrue(schedule.GetBus<TestNotification>(typeof(TestBus)) == bus);
        }

        protected override IAccessSchedule<TTheme> RequireAccessSchedule<TTheme>() => new CommandSchedule<TTheme>();

        protected override object RequireAccessBus<TNotification>() => new CommandBus<TNotification>();

        private class TestBus : ICommandBus<TestNotification>
        {
            public CommandOperation Execute(ref TestNotification notification) => throw new NotImplementedException();
        }
    }
}