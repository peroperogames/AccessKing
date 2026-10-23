/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/01 16:06:12
 */

using System;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Tests;

// ReSharper disable All
public sealed class ActionEventHandlerTest
{
    private int m_HandleCount;
    private bool m_IsInvoke;

    [SetUp]
    public void SetUp()
    {
        m_HandleCount = 0;
        m_IsInvoke = false;
    }

    private void Test()
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

    private void Test(object p)
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

    private void Test(object p1, object p2)
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

    private void Test(object p1, object p2, object p3)
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

    private void Test(object p1, object p2, object p3, object p4)
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

    private void Test(object p1, object p2, object p3, object p4, object p5)
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

    private void Test(object p1, object p2, object p3, object p4, object p5, object p6)
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

    private void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7)
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

    private void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8)
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

    private void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9)
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

    private void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9, object p10)
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

    private void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9, object p10, object p11)
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

    private void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9, object p10, object p11, object p12)
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

    private void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9, object p10, object p11, object p12, object p13)
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

    private void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9, object p10, object p11, object p12, object p13, object p14)
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

    private void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9, object p10, object p11, object p12, object p13, object p14, object p15)
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

    private void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9, object p10, object p11, object p12, object p13, object p14, object p15, object p16)
    {
        m_HandleCount++;
        m_IsInvoke = true;
    }

		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		[TestCase(4)]
		[TestCase(5)]
		[TestCase(6)]
		[TestCase(7)]
		[TestCase(8)]
		[TestCase(9)]
		[TestCase(10)]
		[TestCase(11)]
		[TestCase(12)]
		[TestCase(13)]
		[TestCase(14)]
		[TestCase(15)]
		[TestCase(16)]
    public void HandlerInvokeTest(int argumentCount)
    {
        switch (argumentCount)
        {
            case 0:
                var handler0 = new ActionEventHandler(Test);
                handler0.Handle();
                break;
            case 1:
                var handler1 = new ActionEventHandler<object>(Test);
                handler1.Handle(default);
                break;
            case 2:
                var handler2 = new ActionEventHandler<object, object>(Test);
                handler2.Handle(default, default);
                break;
            case 3:
                var handler3 = new ActionEventHandler<object, object, object>(Test);
                handler3.Handle(default, default, default);
                break;
            case 4:
                var handler4 = new ActionEventHandler<object, object, object, object>(Test);
                handler4.Handle(default, default, default, default);
                break;
            case 5:
                var handler5 = new ActionEventHandler<object, object, object, object, object>(Test);
                handler5.Handle(default, default, default, default, default);
                break;
            case 6:
                var handler6 = new ActionEventHandler<object, object, object, object, object, object>(Test);
                handler6.Handle(default, default, default, default, default, default);
                break;
            case 7:
                var handler7 = new ActionEventHandler<object, object, object, object, object, object, object>(Test);
                handler7.Handle(default, default, default, default, default, default, default);
                break;
            case 8:
                var handler8 = new ActionEventHandler<object, object, object, object, object, object, object, object>(Test);
                handler8.Handle(default, default, default, default, default, default, default, default);
                break;
            case 9:
                var handler9 = new ActionEventHandler<object, object, object, object, object, object, object, object, object>(Test);
                handler9.Handle(default, default, default, default, default, default, default, default, default);
                break;
            case 10:
                var handler10 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object>(Test);
                handler10.Handle(default, default, default, default, default, default, default, default, default, default);
                break;
            case 11:
                var handler11 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object>(Test);
                handler11.Handle(default, default, default, default, default, default, default, default, default, default, default);
                break;
            case 12:
                var handler12 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                handler12.Handle(default, default, default, default, default, default, default, default, default, default, default, default);
                break;
            case 13:
                var handler13 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                handler13.Handle(default, default, default, default, default, default, default, default, default, default, default, default, default);
                break;
            case 14:
                var handler14 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                handler14.Handle(default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                break;
            case 15:
                var handler15 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                handler15.Handle(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                break;
            case 16:
                var handler16 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                handler16.Handle(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                break;
        }
        Assert.That(m_IsInvoke, Is.True);
    }

		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		[TestCase(4)]
		[TestCase(5)]
		[TestCase(6)]
		[TestCase(7)]
		[TestCase(8)]
		[TestCase(9)]
		[TestCase(10)]
		[TestCase(11)]
		[TestCase(12)]
		[TestCase(13)]
		[TestCase(14)]
		[TestCase(15)]
		[TestCase(16)]
    public void EqualsWithActionEventHandlerTest(int argumentCount)
    {
        switch (argumentCount)
        {
            case 0:
                var handler0_1 = new ActionEventHandler(Test);
                var handler0_2 = new ActionEventHandler(Test);
                Assert.That(handler0_1 == handler0_2, Is.True);
                Assert.That(handler0_1.Equals(handler0_2), Is.True);
                break;
            case 1:
                var handler1_1 = new ActionEventHandler<object>(Test);
                var handler1_2 = new ActionEventHandler<object>(Test);
                Assert.That(handler1_1 == handler1_2, Is.True);
                Assert.That(handler1_1.Equals(handler1_2), Is.True);
                break;
            case 2:
                var handler2_1 = new ActionEventHandler<object, object>(Test);
                var handler2_2 = new ActionEventHandler<object, object>(Test);
                Assert.That(handler2_1 == handler2_2, Is.True);
                Assert.That(handler2_1.Equals(handler2_2), Is.True);
                break;
            case 3:
                var handler3_1 = new ActionEventHandler<object, object, object>(Test);
                var handler3_2 = new ActionEventHandler<object, object, object>(Test);
                Assert.That(handler3_1 == handler3_2, Is.True);
                Assert.That(handler3_1.Equals(handler3_2), Is.True);
                break;
            case 4:
                var handler4_1 = new ActionEventHandler<object, object, object, object>(Test);
                var handler4_2 = new ActionEventHandler<object, object, object, object>(Test);
                Assert.That(handler4_1 == handler4_2, Is.True);
                Assert.That(handler4_1.Equals(handler4_2), Is.True);
                break;
            case 5:
                var handler5_1 = new ActionEventHandler<object, object, object, object, object>(Test);
                var handler5_2 = new ActionEventHandler<object, object, object, object, object>(Test);
                Assert.That(handler5_1 == handler5_2, Is.True);
                Assert.That(handler5_1.Equals(handler5_2), Is.True);
                break;
            case 6:
                var handler6_1 = new ActionEventHandler<object, object, object, object, object, object>(Test);
                var handler6_2 = new ActionEventHandler<object, object, object, object, object, object>(Test);
                Assert.That(handler6_1 == handler6_2, Is.True);
                Assert.That(handler6_1.Equals(handler6_2), Is.True);
                break;
            case 7:
                var handler7_1 = new ActionEventHandler<object, object, object, object, object, object, object>(Test);
                var handler7_2 = new ActionEventHandler<object, object, object, object, object, object, object>(Test);
                Assert.That(handler7_1 == handler7_2, Is.True);
                Assert.That(handler7_1.Equals(handler7_2), Is.True);
                break;
            case 8:
                var handler8_1 = new ActionEventHandler<object, object, object, object, object, object, object, object>(Test);
                var handler8_2 = new ActionEventHandler<object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler8_1 == handler8_2, Is.True);
                Assert.That(handler8_1.Equals(handler8_2), Is.True);
                break;
            case 9:
                var handler9_1 = new ActionEventHandler<object, object, object, object, object, object, object, object, object>(Test);
                var handler9_2 = new ActionEventHandler<object, object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler9_1 == handler9_2, Is.True);
                Assert.That(handler9_1.Equals(handler9_2), Is.True);
                break;
            case 10:
                var handler10_1 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object>(Test);
                var handler10_2 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler10_1 == handler10_2, Is.True);
                Assert.That(handler10_1.Equals(handler10_2), Is.True);
                break;
            case 11:
                var handler11_1 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object>(Test);
                var handler11_2 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler11_1 == handler11_2, Is.True);
                Assert.That(handler11_1.Equals(handler11_2), Is.True);
                break;
            case 12:
                var handler12_1 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                var handler12_2 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler12_1 == handler12_2, Is.True);
                Assert.That(handler12_1.Equals(handler12_2), Is.True);
                break;
            case 13:
                var handler13_1 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                var handler13_2 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler13_1 == handler13_2, Is.True);
                Assert.That(handler13_1.Equals(handler13_2), Is.True);
                break;
            case 14:
                var handler14_1 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                var handler14_2 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler14_1 == handler14_2, Is.True);
                Assert.That(handler14_1.Equals(handler14_2), Is.True);
                break;
            case 15:
                var handler15_1 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                var handler15_2 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler15_1 == handler15_2, Is.True);
                Assert.That(handler15_1.Equals(handler15_2), Is.True);
                break;
            case 16:
                var handler16_1 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                var handler16_2 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler16_1 == handler16_2, Is.True);
                Assert.That(handler16_1.Equals(handler16_2), Is.True);
                break;
        }
    }

		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		[TestCase(4)]
		[TestCase(5)]
		[TestCase(6)]
		[TestCase(7)]
		[TestCase(8)]
		[TestCase(9)]
		[TestCase(10)]
		[TestCase(11)]
		[TestCase(12)]
		[TestCase(13)]
		[TestCase(14)]
		[TestCase(15)]
		[TestCase(16)]
    public void EqualsWithActionDelegateTest(int argumentCount)
    {
        switch (argumentCount)
        {
            case 0:
                var handler0_1 = new ActionEventHandler(Test);
                var handler0_2 = new Action(Test);
                Assert.That(handler0_1 == handler0_2, Is.True);
                Assert.That(handler0_1.Equals(handler0_2), Is.True);
                break;
            case 1:
                var handler1_1 = new ActionEventHandler<object>(Test);
                var handler1_2 = new Action<object>(Test);
                Assert.That(handler1_1 == handler1_2, Is.True);
                Assert.That(handler1_1.Equals(handler1_2), Is.True);
                break;
            case 2:
                var handler2_1 = new ActionEventHandler<object, object>(Test);
                var handler2_2 = new Action<object, object>(Test);
                Assert.That(handler2_1 == handler2_2, Is.True);
                Assert.That(handler2_1.Equals(handler2_2), Is.True);
                break;
            case 3:
                var handler3_1 = new ActionEventHandler<object, object, object>(Test);
                var handler3_2 = new Action<object, object, object>(Test);
                Assert.That(handler3_1 == handler3_2, Is.True);
                Assert.That(handler3_1.Equals(handler3_2), Is.True);
                break;
            case 4:
                var handler4_1 = new ActionEventHandler<object, object, object, object>(Test);
                var handler4_2 = new Action<object, object, object, object>(Test);
                Assert.That(handler4_1 == handler4_2, Is.True);
                Assert.That(handler4_1.Equals(handler4_2), Is.True);
                break;
            case 5:
                var handler5_1 = new ActionEventHandler<object, object, object, object, object>(Test);
                var handler5_2 = new Action<object, object, object, object, object>(Test);
                Assert.That(handler5_1 == handler5_2, Is.True);
                Assert.That(handler5_1.Equals(handler5_2), Is.True);
                break;
            case 6:
                var handler6_1 = new ActionEventHandler<object, object, object, object, object, object>(Test);
                var handler6_2 = new Action<object, object, object, object, object, object>(Test);
                Assert.That(handler6_1 == handler6_2, Is.True);
                Assert.That(handler6_1.Equals(handler6_2), Is.True);
                break;
            case 7:
                var handler7_1 = new ActionEventHandler<object, object, object, object, object, object, object>(Test);
                var handler7_2 = new Action<object, object, object, object, object, object, object>(Test);
                Assert.That(handler7_1 == handler7_2, Is.True);
                Assert.That(handler7_1.Equals(handler7_2), Is.True);
                break;
            case 8:
                var handler8_1 = new ActionEventHandler<object, object, object, object, object, object, object, object>(Test);
                var handler8_2 = new Action<object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler8_1 == handler8_2, Is.True);
                Assert.That(handler8_1.Equals(handler8_2), Is.True);
                break;
            case 9:
                var handler9_1 = new ActionEventHandler<object, object, object, object, object, object, object, object, object>(Test);
                var handler9_2 = new Action<object, object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler9_1 == handler9_2, Is.True);
                Assert.That(handler9_1.Equals(handler9_2), Is.True);
                break;
            case 10:
                var handler10_1 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object>(Test);
                var handler10_2 = new Action<object, object, object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler10_1 == handler10_2, Is.True);
                Assert.That(handler10_1.Equals(handler10_2), Is.True);
                break;
            case 11:
                var handler11_1 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object>(Test);
                var handler11_2 = new Action<object, object, object, object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler11_1 == handler11_2, Is.True);
                Assert.That(handler11_1.Equals(handler11_2), Is.True);
                break;
            case 12:
                var handler12_1 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                var handler12_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler12_1 == handler12_2, Is.True);
                Assert.That(handler12_1.Equals(handler12_2), Is.True);
                break;
            case 13:
                var handler13_1 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                var handler13_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler13_1 == handler13_2, Is.True);
                Assert.That(handler13_1.Equals(handler13_2), Is.True);
                break;
            case 14:
                var handler14_1 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                var handler14_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler14_1 == handler14_2, Is.True);
                Assert.That(handler14_1.Equals(handler14_2), Is.True);
                break;
            case 15:
                var handler15_1 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                var handler15_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler15_1 == handler15_2, Is.True);
                Assert.That(handler15_1.Equals(handler15_2), Is.True);
                break;
            case 16:
                var handler16_1 = new ActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                var handler16_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                Assert.That(handler16_1 == handler16_2, Is.True);
                Assert.That(handler16_1.Equals(handler16_2), Is.True);
                break;
        }
    }

		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		[TestCase(4)]
		[TestCase(5)]
		[TestCase(6)]
		[TestCase(7)]
		[TestCase(8)]
		[TestCase(9)]
		[TestCase(10)]
		[TestCase(11)]
		[TestCase(12)]
		[TestCase(13)]
		[TestCase(14)]
		[TestCase(15)]
		[TestCase(16)]
    public void EventBusInvokeWithActionHandlerTest(int argumentCount)
    {
        switch (argumentCount)
        {
            case 0:
                var bus0 = new EventBus<Empty>();
                bus0.Subscribe(Test);
                bus0.Broadcast();
                break;
            case 1:
                var bus1 = new EventBus<ParameterNotification<object>>();
                bus1.Subscribe(Test);
                bus1.Broadcast(default);
                break;
            case 2:
                var bus2 = new EventBus<ParameterNotification<object, object>>();
                bus2.Subscribe(Test);
                bus2.Broadcast(default, default);
                break;
            case 3:
                var bus3 = new EventBus<ParameterNotification<object, object, object>>();
                bus3.Subscribe(Test);
                bus3.Broadcast(default, default, default);
                break;
            case 4:
                var bus4 = new EventBus<ParameterNotification<object, object, object, object>>();
                bus4.Subscribe(Test);
                bus4.Broadcast(default, default, default, default);
                break;
            case 5:
                var bus5 = new EventBus<ParameterNotification<object, object, object, object, object>>();
                bus5.Subscribe(Test);
                bus5.Broadcast(default, default, default, default, default);
                break;
            case 6:
                var bus6 = new EventBus<ParameterNotification<object, object, object, object, object, object>>();
                bus6.Subscribe(Test);
                bus6.Broadcast(default, default, default, default, default, default);
                break;
            case 7:
                var bus7 = new EventBus<ParameterNotification<object, object, object, object, object, object, object>>();
                bus7.Subscribe(Test);
                bus7.Broadcast(default, default, default, default, default, default, default);
                break;
            case 8:
                var bus8 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object>>();
                bus8.Subscribe(Test);
                bus8.Broadcast(default, default, default, default, default, default, default, default);
                break;
            case 9:
                var bus9 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object>>();
                bus9.Subscribe(Test);
                bus9.Broadcast(default, default, default, default, default, default, default, default, default);
                break;
            case 10:
                var bus10 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object>>();
                bus10.Subscribe(Test);
                bus10.Broadcast(default, default, default, default, default, default, default, default, default, default);
                break;
            case 11:
                var bus11 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object>>();
                bus11.Subscribe(Test);
                bus11.Broadcast(default, default, default, default, default, default, default, default, default, default, default);
                break;
            case 12:
                var bus12 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object>>();
                bus12.Subscribe(Test);
                bus12.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default);
                break;
            case 13:
                var bus13 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                bus13.Subscribe(Test);
                bus13.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default);
                break;
            case 14:
                var bus14 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                bus14.Subscribe(Test);
                bus14.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                break;
            case 15:
                var bus15 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                bus15.Subscribe(Test);
                bus15.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                break;
            case 16:
                var bus16 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                bus16.Subscribe(Test);
                bus16.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                break;
        }
        Assert.That(m_HandleCount == 1, Is.True);
    }

		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		[TestCase(4)]
		[TestCase(5)]
		[TestCase(6)]
		[TestCase(7)]
		[TestCase(8)]
		[TestCase(9)]
		[TestCase(10)]
		[TestCase(11)]
		[TestCase(12)]
		[TestCase(13)]
		[TestCase(14)]
		[TestCase(15)]
		[TestCase(16)]
    public void EventBusUnsubscribeWithActionHandlerTest(int argumentCount)
    {
        const int handlerCount = 5;
        switch (argumentCount)
        {
            case 0:
                var bus0 = new EventBus<Empty>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus0.Subscribe(Test);
                }
                Assert.That(bus0.Unsubscribe(Test), Is.True);
                bus0.Broadcast();
                break;
            case 1:
                var bus1 = new EventBus<ParameterNotification<object>>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus1.Subscribe(Test);
                }
                Assert.That(bus1.Unsubscribe(Test), Is.True);
                bus1.Broadcast(default);
                break;
            case 2:
                var bus2 = new EventBus<ParameterNotification<object, object>>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus2.Subscribe(Test);
                }
                Assert.That(bus2.Unsubscribe(Test), Is.True);
                bus2.Broadcast(default, default);
                break;
            case 3:
                var bus3 = new EventBus<ParameterNotification<object, object, object>>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus3.Subscribe(Test);
                }
                Assert.That(bus3.Unsubscribe(Test), Is.True);
                bus3.Broadcast(default, default, default);
                break;
            case 4:
                var bus4 = new EventBus<ParameterNotification<object, object, object, object>>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus4.Subscribe(Test);
                }
                Assert.That(bus4.Unsubscribe(Test), Is.True);
                bus4.Broadcast(default, default, default, default);
                break;
            case 5:
                var bus5 = new EventBus<ParameterNotification<object, object, object, object, object>>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus5.Subscribe(Test);
                }
                Assert.That(bus5.Unsubscribe(Test), Is.True);
                bus5.Broadcast(default, default, default, default, default);
                break;
            case 6:
                var bus6 = new EventBus<ParameterNotification<object, object, object, object, object, object>>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus6.Subscribe(Test);
                }
                Assert.That(bus6.Unsubscribe(Test), Is.True);
                bus6.Broadcast(default, default, default, default, default, default);
                break;
            case 7:
                var bus7 = new EventBus<ParameterNotification<object, object, object, object, object, object, object>>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus7.Subscribe(Test);
                }
                Assert.That(bus7.Unsubscribe(Test), Is.True);
                bus7.Broadcast(default, default, default, default, default, default, default);
                break;
            case 8:
                var bus8 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object>>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus8.Subscribe(Test);
                }
                Assert.That(bus8.Unsubscribe(Test), Is.True);
                bus8.Broadcast(default, default, default, default, default, default, default, default);
                break;
            case 9:
                var bus9 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object>>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus9.Subscribe(Test);
                }
                Assert.That(bus9.Unsubscribe(Test), Is.True);
                bus9.Broadcast(default, default, default, default, default, default, default, default, default);
                break;
            case 10:
                var bus10 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object>>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus10.Subscribe(Test);
                }
                Assert.That(bus10.Unsubscribe(Test), Is.True);
                bus10.Broadcast(default, default, default, default, default, default, default, default, default, default);
                break;
            case 11:
                var bus11 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object>>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus11.Subscribe(Test);
                }
                Assert.That(bus11.Unsubscribe(Test), Is.True);
                bus11.Broadcast(default, default, default, default, default, default, default, default, default, default, default);
                break;
            case 12:
                var bus12 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object>>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus12.Subscribe(Test);
                }
                Assert.That(bus12.Unsubscribe(Test), Is.True);
                bus12.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default);
                break;
            case 13:
                var bus13 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus13.Subscribe(Test);
                }
                Assert.That(bus13.Unsubscribe(Test), Is.True);
                bus13.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default);
                break;
            case 14:
                var bus14 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus14.Subscribe(Test);
                }
                Assert.That(bus14.Unsubscribe(Test), Is.True);
                bus14.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                break;
            case 15:
                var bus15 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus15.Subscribe(Test);
                }
                Assert.That(bus15.Unsubscribe(Test), Is.True);
                bus15.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                break;
            case 16:
                var bus16 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                for (var i = 0; i < handlerCount; i++)
                {
                    bus16.Subscribe(Test);
                }
                Assert.That(bus16.Unsubscribe(Test), Is.True);
                bus16.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                break;
        }
        Assert.That(m_HandleCount == handlerCount - 1, Is.True);
    }
}