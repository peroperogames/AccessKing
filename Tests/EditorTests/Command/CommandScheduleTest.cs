using System;
using System.Collections.Generic;
using NUnit.Framework;
using PeroTools2.AccessKing.Editor.Tests.AccessTests;

namespace PeroTools2.AccessKing.Editor.Tests.CommandTests
{
    public class CommandScheduleTest : AccessScheduleTest
    {
        [Test]
        public void CommandScheduleRegisterTest()
        {
            var schedule = new CommandSchedule<string, TestHandlerFactory>();
            var bus = new CommandBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsTrue(schedule.ContainsBus(theme));
            Assert.IsTrue(schedule.GetBus<TestNotification>(theme) == bus);
        }

        [Test]
        public void CommandScheduleRegisterRepeatTest()
        {
            var schedule = new CommandSchedule<string, TestHandlerFactory>();
            Assert.Catch(() =>
            {
                schedule.AddThemeMapping(theme, new CommandBus<TestNotification>());
                schedule.AddThemeMapping(theme, new CommandBus<TestNotification>());
            });
        }

        [Test]
        public void CommandScheduleRemoveThemeTest()
        {
            var schedule = new CommandSchedule<string, TestHandlerFactory>();
            var bus = new CommandBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsTrue(schedule.RemoveTheme(theme));
            Assert.IsFalse(schedule.ContainsBus(theme));
        }

        [Test]
        public void CommandScheduleRemoveBusTest()
        {
            var schedule = new CommandSchedule<string, TestHandlerFactory>();
            var bus = new CommandBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsTrue(schedule.RemoveBus(bus));
            Assert.IsFalse(schedule.ContainsBus(theme));
        }

        [Test]
        public void CommandScheduleTryGetBusTest()
        {
            var schedule = new CommandSchedule<string, TestHandlerFactory>();
            var bus = new CommandBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsTrue(schedule.TryGetBus<TestNotification>(theme, out _));
            schedule.RemoveTheme(theme);
            Assert.IsFalse(schedule.TryGetBus<TestNotification>(theme, out _));
        }

        [Test]
        public void CommandScheduleGetBusTest()
        {
            var schedule = new CommandSchedule<string, TestHandlerFactory>();
            var bus = new CommandBus<TestNotification>();
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
        public void CommandScheduleRequireByStringThemeTest(int argumentCount)
        {
            var schedule = new CommandSchedule<string, TestHandlerFactory>();
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

        private class TestHandlerFactory : ICommandHandlerFactory
        {
            public IReadOnlyList<ICommandHandler<TNotification>> RequireHandlers<TNotification>() where TNotification : INotification
            {
                return new ICommandHandler<TNotification>[] { };
            }
        }

        protected override IAccessSchedule<TTheme> RequireAccessSchedule<TTheme>()
        {
            return new CommandSchedule<TTheme, TestHandlerFactory>();
        }

        protected override IAccessBus RequireAccessBus<TNotification>()
        {
            return new CommandBus<TNotification>();
        }
    }
}