using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Editor.Tests.CommandTests
{
    public class CommandScheduleTest
    {
        private const string theme = "TestCommand";

        [Test]
        public void ScheduleRegisterTest()
        {
            var schedule = new CommandSchedule<string, TestHandlerFactory>();
            var bus = new CommandBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsTrue(schedule.ContainsBus(theme));
            Assert.IsTrue(schedule.GetBus<TestNotification>(theme) == bus);
        }

        [Test]
        public void ScheduleRegisterRepeatTest()
        {
            var schedule = new CommandSchedule<string, TestHandlerFactory>();
            Assert.Catch(() =>
            {
                schedule.AddThemeMapping(theme, new CommandBus<TestNotification>());
                schedule.AddThemeMapping(theme, new CommandBus<TestNotification>());
            });
        }

        [Test]
        public void ScheduleRemoveThemeTest()
        {
            var schedule = new CommandSchedule<string, TestHandlerFactory>();
            var bus = new CommandBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsTrue(schedule.RemoveTheme(theme));
            Assert.IsFalse(schedule.ContainsBus(theme));
        }

        [Test]
        public void ScheduleRemoveBusTest()
        {
            var schedule = new CommandSchedule<string, TestHandlerFactory>();
            var bus = new CommandBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsTrue(schedule.RemoveBus(bus));
            Assert.IsFalse(schedule.ContainsBus(theme));
        }

        [Test]
        public void ScheduleTryGetBusTest()
        {
            var schedule = new CommandSchedule<string, TestHandlerFactory>();
            var bus = new CommandBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsTrue(schedule.TryGetBus<TestNotification>(theme, out _));
            schedule.RemoveTheme(theme);
            Assert.IsFalse(schedule.TryGetBus<TestNotification>(theme, out _));
        }

        [Test]
        public void ScheduleGetBusTest()
        {
            var schedule = new CommandSchedule<string, TestHandlerFactory>();
            var bus = new CommandBus<TestNotification>();
            schedule.AddThemeMapping(theme, bus);
            Assert.IsNotNull(schedule.GetBus<TestNotification>(theme));
            schedule.RemoveTheme(theme);
            Assert.Catch(() => schedule.GetBus<TestNotification>(theme));
        }

        [Test]
        public void ScheduleRequireByTypeThemeTest()
        {
            var schedule = new CommandSchedule<Type,TestHandlerFactory>();
            var bus = schedule.Require<TestBus>();
            Assert.IsTrue(schedule.ContainsBus(typeof(TestBus)));
            Assert.IsTrue(schedule.GetBus<TestNotification>(typeof(TestBus)) == bus);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void ScheduleRequireByStringThemeTest(int argumentCount)
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

        private class TestBus : CommandBus<TestNotification>
        {
        }

        private class TestNotification : INotification
        {
        }
    }
}