/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2026/10/22 18:20:00
 */

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Tests;

/// <summary>
/// Covers the weak subscription that lives in the engine free assembly. The host installs the lifetime comparer,
/// these tests install a fake one that counts a flagged owner as dead.
/// </summary>
public sealed class WeakActionEventHandlerTest
{
    private IEqualityComparer<object> m_Previous;

    [SetUp]
    public void SetUp()
    {
        m_Previous = OwnerLifetime.comparer;
        OwnerLifetime.comparer = new FakeOwnerComparer();
    }

    [TearDown]
    public void TearDown() => OwnerLifetime.comparer = m_Previous;

    [Test]
    public void BroadcastWeakSubscriptionTest()
    {
        var bus = new ParameterEventBus<int>();
        var owner = new FakeOwner();

        bus.SubscribeWeakly(owner, owner.Handle);
        bus.Broadcast(7);

        Assert.That(owner.calls, Is.EqualTo(7));
    }

    [Test]
    public void UnsubscribeWithFreshDelegateTest()
    {
        var bus = new ParameterEventBus<int>();
        var owner = new FakeOwner();
        bus.SubscribeWeakly(owner, owner.Handle);

        var removed = bus.Unsubscribe(owner.Handle);
        bus.Broadcast(9);

        Assert.That(removed, Is.True);
        Assert.That(owner.calls, Is.Zero);
    }

    [Test]
    public void DestroyedOwnerDeadTest()
    {
        var bus = new ParameterEventBus<int>();
        var owner = new FakeOwner();
        bus.SubscribeWeakly(owner, owner.Handle);

        owner.destroyed = true;
        bus.Broadcast(11);

        Assert.That(owner.calls, Is.Zero);
    }

    [Test]
    public void HandlerDiesWithCollectedProviderTest()
    {
        var handler = CreateHandler();
        Assert.That(handler.isAlive, Is.True);

        for (var index = 0; index < 3; index++)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        Assert.That(handler.isAlive, Is.False);
        Assert.That(handler.TryHandle(1), Is.False);
    }

    private static WeakActionEventHandler<int> CreateHandler()
    {
        var provider = new Provider();
        return new WeakActionEventHandler<int>(provider.Handle, provider);
    }

    private sealed class FakeOwner
    {
        public bool destroyed;
        public int calls;

        public void Handle(int value) => calls = value;
    }

    private sealed class Provider
    {
        public void Handle(int value)
        {
        }
    }

    private sealed class FakeOwnerComparer : IEqualityComparer<object>
    {
        public new bool Equals(object a, object b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is FakeOwner owner) return b is null ? owner.destroyed : owner.Equals(b);
            if (a is null || b is null) return false;
            return a.Equals(b);
        }

        public int GetHashCode(object o) => o?.GetHashCode() ?? 0;
    }
}