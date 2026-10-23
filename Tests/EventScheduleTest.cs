/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/06 21:06:07
 */

using System;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Tests;

public sealed class EventScheduleTest : AccessScheduleTest
{
    [Test]
    public void EventScheduleRegisterTest()
    {
        var schedule = new EventSchedule<string>();
        var bus = new EventBus<TestNotification>();
        schedule.AddBus(theme, bus);
        Assert.That(schedule.ContainsBus(theme), Is.True);
        Assert.That(schedule.GetBus<TestNotification>(theme) == bus, Is.True);
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
        Assert.That(schedule.RemoveBus(theme), Is.True);
        Assert.That(schedule.ContainsBus(theme), Is.False);
    }

    [Test]
    public void EventScheduleRemoveBusTest()
    {
        var schedule = new EventSchedule<string>();
        var bus = new EventBus<TestNotification>();
        schedule.AddBus(theme, bus);
        Assert.That(schedule.RemoveBus(bus), Is.True);
        Assert.That(schedule.ContainsBus(theme), Is.False);
    }

    [Test]
    public void EventScheduleTryGetBusTest()
    {
        var schedule = new EventSchedule<string>();
        var bus = new EventBus<TestNotification>();
        schedule.AddBus(theme, bus);
        Assert.That(schedule.TryGetBus<TestNotification>(theme, out _), Is.True);
        schedule.RemoveBus(theme);
        Assert.That(schedule.TryGetBus<TestNotification>(theme, out _), Is.False);
    }

    [Test]
    public void EventScheduleGetBusTest()
    {
        var schedule = new EventSchedule<string>();
        var bus = new EventBus<TestNotification>();
        schedule.AddBus(theme, bus);
        Assert.That(schedule.GetBus<TestNotification>(theme), Is.Not.Null);
        schedule.RemoveBus(theme);
        Assert.Catch(() => schedule.GetBus<TestNotification>(theme));
    }

    [Test]
    public void EventScheduleRequireByStringThemeTest()
    {
        var schedule = new EventSchedule<string>();
        var bus = schedule.Require<int>(theme);
        Assert.That(schedule.ContainsBus(theme), Is.True);
        Assert.That(schedule.GetBus<ParameterNotification<int>>(theme) == bus, Is.True);
    }

    [Test]
    public void EventScheduleRequireByTypeThemeTest()
    {
        var schedule = new EventSchedule<Type>();
        var bus = schedule.Require<TestBus>();
        Assert.That(schedule.ContainsBus(typeof(TestBus)), Is.True);
        Assert.That(schedule.GetBus<TestNotification>(typeof(TestBus)) == bus, Is.True);
    }

    protected override IAccessSchedule<TTheme> RequireAccessSchedule<TTheme>() => new EventSchedule<TTheme>();

    protected override object RequireAccessBus<TNotification>() => new TestBus();

    private class TestBus : IEventBus<TestNotification>
    {
        public void Subscribe(IEventHandler<TestNotification> handler) => throw new NotImplementedException();

        public bool Unsubscribe(IEventHandler<TestNotification> handler) => throw new NotImplementedException();

        public void Clear() => throw new NotImplementedException();

        public void Broadcast(in TestNotification notification) => throw new NotImplementedException();

        public void SubscribeWeakly(IWeakEventHandler<TestNotification> handler) => throw new NotImplementedException();
    }
}