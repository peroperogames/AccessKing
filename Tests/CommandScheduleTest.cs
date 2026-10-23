/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/07 16:06:40
 */

using System;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Tests;

public sealed class CommandScheduleTest : AccessScheduleTest
{
    [Test]
    public void CommandScheduleRegisterTest()
    {
        var schedule = new CommandSchedule<string>();
        var bus = new CommandBus<TestNotification>();
        schedule.AddBus(theme, bus);
        Assert.That(schedule.ContainsBus(theme), Is.True);
        Assert.That(schedule.GetBus<TestNotification>(theme) == bus, Is.True);
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
        Assert.That(schedule.RemoveBus(theme), Is.True);
        Assert.That(schedule.ContainsBus(theme), Is.False);
    }

    [Test]
    public void CommandScheduleRemoveBusTest()
    {
        var schedule = new CommandSchedule<string>();
        var bus = new CommandBus<TestNotification>();
        schedule.AddBus(theme, bus);
        Assert.That(schedule.RemoveBus(bus), Is.True);
        Assert.That(schedule.ContainsBus(theme), Is.False);
    }

    [Test]
    public void CommandScheduleTryGetBusTest()
    {
        var schedule = new CommandSchedule<string>();
        var bus = new CommandBus<TestNotification>();
        schedule.AddBus(theme, bus);
        Assert.That(schedule.TryGetBus<TestNotification>(theme, out _), Is.True);
        schedule.RemoveBus(theme);
        Assert.That(schedule.TryGetBus<TestNotification>(theme, out _), Is.False);
    }

    [Test]
    public void CommandScheduleGetBusTest()
    {
        var schedule = new CommandSchedule<string>();
        var bus = new CommandBus<TestNotification>();
        schedule.AddBus(theme, bus);
        Assert.That(schedule.GetBus<TestNotification>(theme), Is.Not.Null);
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
                Assert.That(schedule.ContainsBus(theme), Is.True);
                Assert.That(schedule.GetBus<Empty>(theme) == bus0, Is.True);
                break;
            case 1:
                var bus1 = schedule.Require<object>(theme);
                Assert.That(schedule.ContainsBus(theme), Is.True);
                Assert.That(schedule.GetBus<ParameterNotification<object>>(theme) == bus1, Is.True);
                break;
            case 2:
                var bus2 = schedule.Require<object, object>(theme);
                Assert.That(schedule.ContainsBus(theme), Is.True);
                Assert.That(schedule.GetBus<ParameterNotification<object, object>>(theme) == bus2, Is.True);
                break;
            case 3:
                var bus3 = schedule.Require<object, object, object>(theme);
                Assert.That(schedule.ContainsBus(theme), Is.True);
                Assert.That(schedule.GetBus<ParameterNotification<object, object, object>>(theme) == bus3, Is.True);
                break;
            case 4:
                var bus4 = schedule.Require<object, object, object, object>(theme);
                Assert.That(schedule.ContainsBus(theme), Is.True);
                Assert.That(schedule.GetBus<ParameterNotification<object, object, object, object>>(theme) == bus4, Is.True);
                break;
            case 5:
                var bus5 = schedule.Require<object, object, object, object, object>(theme);
                Assert.That(schedule.ContainsBus(theme), Is.True);
                Assert.That(schedule.GetBus<ParameterNotification<object, object, object, object, object>>(theme) == bus5, Is.True);
                break;
        }
    }

    [Test]
    public void CommandScheduleRequireByTypeThemeTest()
    {
        var schedule = new CommandSchedule<Type>();
        var bus = schedule.Require<TestBus>();
        Assert.That(schedule.ContainsBus(typeof(TestBus)), Is.True);
        Assert.That(schedule.GetBus<TestNotification>(typeof(TestBus)) == bus, Is.True);
    }

    protected override IAccessSchedule<TTheme> RequireAccessSchedule<TTheme>() => new CommandSchedule<TTheme>();

    protected override object RequireAccessBus<TNotification>() => new CommandBus<TNotification>();

    private class TestBus : ICommandBus<TestNotification>
    {
        public CommandOperation Execute(ref TestNotification notification) => throw new NotImplementedException();
    }
}