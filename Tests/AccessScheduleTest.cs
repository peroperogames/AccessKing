/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/07 17:06:05
 */

using NUnit.Framework;

namespace PeroTools2.AccessKing.Tests;

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
        Assert.That(schedule.ContainsBus(theme), Is.True);
        Assert.That(schedule.GetBus(theme) == bus, Is.True);
    }

    [Test]
    public void AccessScheduleRemoveBusTest()
    {
        var schedule = RequireAccessSchedule<string>();
        var bus = RequireAccessBus<TestNotification>();
        schedule.AddBus(theme, bus);
        Assert.That(schedule.RemoveBus(theme), Is.True);
        Assert.That(schedule.ContainsBus(theme), Is.False);
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
        Assert.That(schedule.busCount == 0, Is.True);
    }

    [Test]
    public void AccessScheduleAccessorTest()
    {
        var schedule = RequireAccessSchedule<string>();
        Assert.Catch(() => { _ = schedule.GetBus(theme); });
        var bus = RequireAccessBus<TestNotification>();
        schedule.AddBus(theme, bus);
        Assert.That(bus == schedule.GetBus(theme), Is.True);
    }

    protected struct TestNotification : INotification;
}