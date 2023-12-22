/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/01 16:06:12
 */

using System;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Editor.Tests
{
    // ReSharper disable All
    public sealed class ActionCommandHandlerTest
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
                    var handler0 = new ActionCommandHandler(Test);
                    handler0.Handle();
                    break;
                case 1:
                    var handler1 = new ActionCommandHandler<object>(Test);
                    handler1.Handle(default);
                    break;
                case 2:
                    var handler2 = new ActionCommandHandler<object, object>(Test);
                    handler2.Handle(default, default);
                    break;
                case 3:
                    var handler3 = new ActionCommandHandler<object, object, object>(Test);
                    handler3.Handle(default, default, default);
                    break;
                case 4:
                    var handler4 = new ActionCommandHandler<object, object, object, object>(Test);
                    handler4.Handle(default, default, default, default);
                    break;
                case 5:
                    var handler5 = new ActionCommandHandler<object, object, object, object, object>(Test);
                    handler5.Handle(default, default, default, default, default);
                    break;
                case 6:
                    var handler6 = new ActionCommandHandler<object, object, object, object, object, object>(Test);
                    handler6.Handle(default, default, default, default, default, default);
                    break;
                case 7:
                    var handler7 = new ActionCommandHandler<object, object, object, object, object, object, object>(Test);
                    handler7.Handle(default, default, default, default, default, default, default);
                    break;
                case 8:
                    var handler8 = new ActionCommandHandler<object, object, object, object, object, object, object, object>(Test);
                    handler8.Handle(default, default, default, default, default, default, default, default);
                    break;
                case 9:
                    var handler9 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object>(Test);
                    handler9.Handle(default, default, default, default, default, default, default, default, default);
                    break;
                case 10:
                    var handler10 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object>(Test);
                    handler10.Handle(default, default, default, default, default, default, default, default, default, default);
                    break;
                case 11:
                    var handler11 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object>(Test);
                    handler11.Handle(default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 12:
                    var handler12 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    handler12.Handle(default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 13:
                    var handler13 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    handler13.Handle(default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 14:
                    var handler14 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    handler14.Handle(default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 15:
                    var handler15 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    handler15.Handle(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 16:
                    var handler16 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    handler16.Handle(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
            }
            Assert.IsTrue(m_IsInvoke);
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
        public void EqualsWithActionCommandHandlerTest(int argumentCount)
        {
            switch (argumentCount)
            {
                case 0:
                    var handler0_1 = new ActionCommandHandler(Test);
                    var handler0_2 = new ActionCommandHandler(Test);
                    Assert.IsTrue(handler0_1 == handler0_2);
                    Assert.IsTrue(handler0_1.Equals(handler0_2));
                    break;
                case 1:
                    var handler1_1 = new ActionCommandHandler<object>(Test);
                    var handler1_2 = new ActionCommandHandler<object>(Test);
                    Assert.IsTrue(handler1_1 == handler1_2);
                    Assert.IsTrue(handler1_1.Equals(handler1_2));
                    break;
                case 2:
                    var handler2_1 = new ActionCommandHandler<object, object>(Test);
                    var handler2_2 = new ActionCommandHandler<object, object>(Test);
                    Assert.IsTrue(handler2_1 == handler2_2);
                    Assert.IsTrue(handler2_1.Equals(handler2_2));
                    break;
                case 3:
                    var handler3_1 = new ActionCommandHandler<object, object, object>(Test);
                    var handler3_2 = new ActionCommandHandler<object, object, object>(Test);
                    Assert.IsTrue(handler3_1 == handler3_2);
                    Assert.IsTrue(handler3_1.Equals(handler3_2));
                    break;
                case 4:
                    var handler4_1 = new ActionCommandHandler<object, object, object, object>(Test);
                    var handler4_2 = new ActionCommandHandler<object, object, object, object>(Test);
                    Assert.IsTrue(handler4_1 == handler4_2);
                    Assert.IsTrue(handler4_1.Equals(handler4_2));
                    break;
                case 5:
                    var handler5_1 = new ActionCommandHandler<object, object, object, object, object>(Test);
                    var handler5_2 = new ActionCommandHandler<object, object, object, object, object>(Test);
                    Assert.IsTrue(handler5_1 == handler5_2);
                    Assert.IsTrue(handler5_1.Equals(handler5_2));
                    break;
                case 6:
                    var handler6_1 = new ActionCommandHandler<object, object, object, object, object, object>(Test);
                    var handler6_2 = new ActionCommandHandler<object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler6_1 == handler6_2);
                    Assert.IsTrue(handler6_1.Equals(handler6_2));
                    break;
                case 7:
                    var handler7_1 = new ActionCommandHandler<object, object, object, object, object, object, object>(Test);
                    var handler7_2 = new ActionCommandHandler<object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler7_1 == handler7_2);
                    Assert.IsTrue(handler7_1.Equals(handler7_2));
                    break;
                case 8:
                    var handler8_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object>(Test);
                    var handler8_2 = new ActionCommandHandler<object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler8_1 == handler8_2);
                    Assert.IsTrue(handler8_1.Equals(handler8_2));
                    break;
                case 9:
                    var handler9_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object>(Test);
                    var handler9_2 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler9_1 == handler9_2);
                    Assert.IsTrue(handler9_1.Equals(handler9_2));
                    break;
                case 10:
                    var handler10_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object>(Test);
                    var handler10_2 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler10_1 == handler10_2);
                    Assert.IsTrue(handler10_1.Equals(handler10_2));
                    break;
                case 11:
                    var handler11_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object>(Test);
                    var handler11_2 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler11_1 == handler11_2);
                    Assert.IsTrue(handler11_1.Equals(handler11_2));
                    break;
                case 12:
                    var handler12_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    var handler12_2 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler12_1 == handler12_2);
                    Assert.IsTrue(handler12_1.Equals(handler12_2));
                    break;
                case 13:
                    var handler13_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    var handler13_2 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler13_1 == handler13_2);
                    Assert.IsTrue(handler13_1.Equals(handler13_2));
                    break;
                case 14:
                    var handler14_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    var handler14_2 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler14_1 == handler14_2);
                    Assert.IsTrue(handler14_1.Equals(handler14_2));
                    break;
                case 15:
                    var handler15_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    var handler15_2 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler15_1 == handler15_2);
                    Assert.IsTrue(handler15_1.Equals(handler15_2));
                    break;
                case 16:
                    var handler16_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    var handler16_2 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler16_1 == handler16_2);
                    Assert.IsTrue(handler16_1.Equals(handler16_2));
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
                    var handler0_1 = new ActionCommandHandler(Test);
                    var handler0_2 = new Action(Test);
                    Assert.IsTrue(handler0_1 == handler0_2);
                    Assert.IsTrue(handler0_1.Equals(handler0_2));
                    break;
                case 1:
                    var handler1_1 = new ActionCommandHandler<object>(Test);
                    var handler1_2 = new Action<object>(Test);
                    Assert.IsTrue(handler1_1 == handler1_2);
                    Assert.IsTrue(handler1_1.Equals(handler1_2));
                    break;
                case 2:
                    var handler2_1 = new ActionCommandHandler<object, object>(Test);
                    var handler2_2 = new Action<object, object>(Test);
                    Assert.IsTrue(handler2_1 == handler2_2);
                    Assert.IsTrue(handler2_1.Equals(handler2_2));
                    break;
                case 3:
                    var handler3_1 = new ActionCommandHandler<object, object, object>(Test);
                    var handler3_2 = new Action<object, object, object>(Test);
                    Assert.IsTrue(handler3_1 == handler3_2);
                    Assert.IsTrue(handler3_1.Equals(handler3_2));
                    break;
                case 4:
                    var handler4_1 = new ActionCommandHandler<object, object, object, object>(Test);
                    var handler4_2 = new Action<object, object, object, object>(Test);
                    Assert.IsTrue(handler4_1 == handler4_2);
                    Assert.IsTrue(handler4_1.Equals(handler4_2));
                    break;
                case 5:
                    var handler5_1 = new ActionCommandHandler<object, object, object, object, object>(Test);
                    var handler5_2 = new Action<object, object, object, object, object>(Test);
                    Assert.IsTrue(handler5_1 == handler5_2);
                    Assert.IsTrue(handler5_1.Equals(handler5_2));
                    break;
                case 6:
                    var handler6_1 = new ActionCommandHandler<object, object, object, object, object, object>(Test);
                    var handler6_2 = new Action<object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler6_1 == handler6_2);
                    Assert.IsTrue(handler6_1.Equals(handler6_2));
                    break;
                case 7:
                    var handler7_1 = new ActionCommandHandler<object, object, object, object, object, object, object>(Test);
                    var handler7_2 = new Action<object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler7_1 == handler7_2);
                    Assert.IsTrue(handler7_1.Equals(handler7_2));
                    break;
                case 8:
                    var handler8_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object>(Test);
                    var handler8_2 = new Action<object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler8_1 == handler8_2);
                    Assert.IsTrue(handler8_1.Equals(handler8_2));
                    break;
                case 9:
                    var handler9_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object>(Test);
                    var handler9_2 = new Action<object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler9_1 == handler9_2);
                    Assert.IsTrue(handler9_1.Equals(handler9_2));
                    break;
                case 10:
                    var handler10_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object>(Test);
                    var handler10_2 = new Action<object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler10_1 == handler10_2);
                    Assert.IsTrue(handler10_1.Equals(handler10_2));
                    break;
                case 11:
                    var handler11_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object>(Test);
                    var handler11_2 = new Action<object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler11_1 == handler11_2);
                    Assert.IsTrue(handler11_1.Equals(handler11_2));
                    break;
                case 12:
                    var handler12_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    var handler12_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler12_1 == handler12_2);
                    Assert.IsTrue(handler12_1.Equals(handler12_2));
                    break;
                case 13:
                    var handler13_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    var handler13_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler13_1 == handler13_2);
                    Assert.IsTrue(handler13_1.Equals(handler13_2));
                    break;
                case 14:
                    var handler14_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    var handler14_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler14_1 == handler14_2);
                    Assert.IsTrue(handler14_1.Equals(handler14_2));
                    break;
                case 15:
                    var handler15_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    var handler15_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler15_1 == handler15_2);
                    Assert.IsTrue(handler15_1.Equals(handler15_2));
                    break;
                case 16:
                    var handler16_1 = new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    var handler16_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler16_1 == handler16_2);
                    Assert.IsTrue(handler16_1.Equals(handler16_2));
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
        public void InvokeTest(int argumentCount)
        {
            var factory = new RegistryCommandHandlerFactory();
            switch (argumentCount)
            {
                case 0:
                    new ActionCommandHandler(Test).Handle();
                    break;
                case 1:
                    new ActionCommandHandler<object>(Test).Handle(default);
                    break;
                case 2:
                    new ActionCommandHandler<object, object>(Test).Handle(default, default);
                    break;
                case 3:
                    new ActionCommandHandler<object, object, object>(Test).Handle(default, default, default);
                    break;
                case 4:
                    new ActionCommandHandler<object, object, object, object>(Test).Handle(default, default, default, default);
                    break;
                case 5:
                    new ActionCommandHandler<object, object, object, object, object>(Test).Handle(default, default, default, default, default);
                    break;
                case 6:
                    new ActionCommandHandler<object, object, object, object, object, object>(Test).Handle(default, default, default, default, default, default);
                    break;
                case 7:
                    new ActionCommandHandler<object, object, object, object, object, object, object>(Test).Handle(default, default, default, default, default, default, default);
                    break;
                case 8:
                    new ActionCommandHandler<object, object, object, object, object, object, object, object>(Test).Handle(default, default, default, default, default, default, default, default);
                    break;
                case 9:
                    new ActionCommandHandler<object, object, object, object, object, object, object, object, object>(Test).Handle(default, default, default, default, default, default, default, default, default);
                    break;
                case 10:
                    new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object>(Test).Handle(default, default, default, default, default, default, default, default, default, default);
                    break;
                case 11:
                    new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object>(Test).Handle(default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 12:
                    new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object>(Test).Handle(default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 13:
                    new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>(Test).Handle(default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 14:
                    new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test).Handle(default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 15:
                    new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test).Handle(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 16:
                    new ActionCommandHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test).Handle(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
            }
            Assert.IsTrue(m_IsInvoke);
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
        public void CommandBusUnsubscribeWithActionHandlerTest(int argumentCount)
        {
            const int handlerCount = 5;
            var factory = new RegistryCommandHandlerFactory();
            switch (argumentCount)
            {
                case 0:
                    var bus0 = new CommandBus<Empty>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler(Test));
                    bus0.Execute();
                    break;
                case 1:
                    var bus1 = new CommandBus<ParameterNotification<object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object>(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler<object>(Test));
                    bus1.Execute(default);
                    break;
                case 2:
                    var bus2 = new CommandBus<ParameterNotification<object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object>(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler<object, object>(Test));
                    bus2.Execute(default, default);
                    break;
                case 3:
                    var bus3 = new CommandBus<ParameterNotification<object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object>(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object>(Test));
                    bus3.Execute(default, default, default);
                    break;
                case 4:
                    var bus4 = new CommandBus<ParameterNotification<object, object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object, object>(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object, object>(Test));
                    bus4.Execute(default, default, default, default);
                    break;
                case 5:
                    var bus5 = new CommandBus<ParameterNotification<object, object, object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object, object, object>(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object, object, object>(Test));
                    bus5.Execute(default, default, default, default, default);
                    break;
                case 6:
                    var bus6 = new CommandBus<ParameterNotification<object, object, object, object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object, object, object, object>(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object, object, object, object>(Test));
                    bus6.Execute(default, default, default, default, default, default);
                    break;
                case 7:
                    var bus7 = new CommandBus<ParameterNotification<object, object, object, object, object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object, object, object, object, object>(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object, object, object, object, object>(Test));
                    bus7.Execute(default, default, default, default, default, default, default);
                    break;
                case 8:
                    var bus8 = new CommandBus<ParameterNotification<object, object, object, object, object, object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object, object, object, object, object, object>(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object, object, object, object, object, object>(Test));
                    bus8.Execute(default, default, default, default, default, default, default, default);
                    break;
                case 9:
                    var bus9 = new CommandBus<ParameterNotification<object, object, object, object, object, object, object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object, object, object, object, object, object, object>(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object, object, object, object, object, object, object>(Test));
                    bus9.Execute(default, default, default, default, default, default, default, default, default);
                    break;
                case 10:
                    var bus10 = new CommandBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object, object, object, object, object, object, object, object>(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object, object, object, object, object, object, object, object>(Test));
                    bus10.Execute(default, default, default, default, default, default, default, default, default, default);
                    break;
                case 11:
                    var bus11 = new CommandBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object, object, object, object, object, object, object, object, object>(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object, object, object, object, object, object, object, object, object>(Test));
                    bus11.Execute(default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 12:
                    var bus12 = new CommandBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object, object, object, object, object, object, object, object, object, object>(Test));
                    bus12.Execute(default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 13:
                    var bus13 = new CommandBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>(Test));
                    bus13.Execute(default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 14:
                    var bus14 = new CommandBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test));
                    bus14.Execute(default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 15:
                    var bus15 = new CommandBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test));
                    bus15.Execute(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 16:
                    var bus16 = new CommandBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    }
                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test));
                    bus16.Execute(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
            }
            Assert.IsTrue(m_HandleCount == handlerCount - 1);
        }
    }
}