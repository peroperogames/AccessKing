/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/01 16:06:12
 */

using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace PeroTools2.AccessKing.Editor.Tests
{
    // ReSharper disable All
    public sealed class WeakActionEventHandlerTest
    {
        private int m_HandleCount;
        private bool m_IsInvoke;

        [SetUp]
        public void SetUp()
        {
            m_HandleCount = 0;
            m_IsInvoke = false;
        }

        private static void CreateBlob(int count)
        {
            var trash = new List<Blob>();
            for (var i = 0; i < count; i++)
            {
                trash.Add(new Blob());
            }

            trash.Clear();
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
        public void HandlerInvokeTest(int argumentCount)
        {
            switch (argumentCount)
            {
                case 0:
                    var handler0 = new WeakActionEventHandler<WeakActionEventHandlerTest>(Test, this);
                    handler0.Handle();
                    break;
                case 1:
                    var handler1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object>(Test, this);
                    handler1.Handle(default);
                    break;
                case 2:
                    var handler2 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object>(Test, this);
                    handler2.Handle(default, default);
                    break;
                case 3:
                    var handler3 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object>(Test, this);
                    handler3.Handle(default, default, default);
                    break;
                case 4:
                    var handler4 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object>(Test, this);
                    handler4.Handle(default, default, default, default);
                    break;
                case 5:
                    var handler5 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object>(Test, this);
                    handler5.Handle(default, default, default, default, default);
                    break;
                case 6:
                    var handler6 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object>(Test, this);
                    handler6.Handle(default, default, default, default, default, default);
                    break;
                case 7:
                    var handler7 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object>(Test, this);
                    handler7.Handle(default, default, default, default, default, default, default);
                    break;
                case 8:
                    var handler8 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object>(Test, this);
                    handler8.Handle(default, default, default, default, default, default, default, default);
                    break;
                case 9:
                    var handler9 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object>(Test, this);
                    handler9.Handle(default, default, default, default, default, default, default, default, default);
                    break;
                case 10:
                    var handler10 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    handler10.Handle(default, default, default, default, default, default, default, default, default, default);
                    break;
                case 11:
                    var handler11 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    handler11.Handle(default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 12:
                    var handler12 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    handler12.Handle(default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 13:
                    var handler13 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    handler13.Handle(default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 14:
                    var handler14 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    handler14.Handle(default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 15:
                    var handler15 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    handler15.Handle(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
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
        public void HandlerInvokeWithNonRefGCTest(int argumentCount)
        {
            object RegisterWithGarbage(int argumentCount)
            {
                switch (argumentCount)
                {
                    case 0: return new WeakActionEventHandler<WeakActionEventHandlerTest>(Test, new WeakActionEventHandlerTest());
                    case 1: return new WeakActionEventHandler<WeakActionEventHandlerTest, object>(Test, new WeakActionEventHandlerTest());
                    case 2: return new WeakActionEventHandler<WeakActionEventHandlerTest, object, object>(Test, new WeakActionEventHandlerTest());
                    case 3: return new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object>(Test, new WeakActionEventHandlerTest());
                    case 4: return new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object>(Test, new WeakActionEventHandlerTest());
                    case 5: return new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object>(Test, new WeakActionEventHandlerTest());
                    case 6: return new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object>(Test, new WeakActionEventHandlerTest());
                    case 7: return new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object>(Test, new WeakActionEventHandlerTest());
                    case 8: return new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object>(Test, new WeakActionEventHandlerTest());
                    case 9: return new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object>(Test, new WeakActionEventHandlerTest());
                    case 10: return new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object>(Test, new WeakActionEventHandlerTest());
                    case 11: return new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object>(Test, new WeakActionEventHandlerTest());
                    case 12: return new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object>(Test, new WeakActionEventHandlerTest());
                    case 13: return new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test, new WeakActionEventHandlerTest());
                    case 14: return new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test, new WeakActionEventHandlerTest());
                    case 15: return new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test, new WeakActionEventHandlerTest());
                    default: return null;
                }
            }
            var handler = RegisterWithGarbage(argumentCount);
            CreateBlob(10);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            switch (argumentCount)
            {
                case 0:
                    (handler as WeakActionEventHandler<WeakActionEventHandlerTest>).Handle();
                    break;
                case 1:
                    (handler as WeakActionEventHandler<WeakActionEventHandlerTest, object>).Handle(default);
                    break;
                case 2:
                    (handler as WeakActionEventHandler<WeakActionEventHandlerTest, object, object>).Handle(default, default);
                    break;
                case 3:
                    (handler as WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object>).Handle(default, default, default);
                    break;
                case 4:
                    (handler as WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object>).Handle(default, default, default, default);
                    break;
                case 5:
                    (handler as WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object>).Handle(default, default, default, default, default);
                    break;
                case 6:
                    (handler as WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object>).Handle(default, default, default, default, default, default);
                    break;
                case 7:
                    (handler as WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default);
                    break;
                case 8:
                    (handler as WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default, default);
                    break;
                case 9:
                    (handler as WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default, default, default);
                    break;
                case 10:
                    (handler as WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default, default, default, default);
                    break;
                case 11:
                    (handler as WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 12:
                    (handler as WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 13:
                    (handler as WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 14:
                    (handler as WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 15:
                    (handler as WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
            }
            Assert.IsFalse(m_IsInvoke);
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
        public void EqualsWithWeakActionEventHandlerTest(int argumentCount)
        {
            switch (argumentCount)
            {
                case 0:
                    var handler0_1 = new WeakActionEventHandler<WeakActionEventHandlerTest>(Test, this);
                    var handler0_2 = new WeakActionEventHandler<WeakActionEventHandlerTest>(Test, this);
                    Assert.IsTrue(handler0_1 == handler0_2);
                    Assert.IsTrue(handler0_1.Equals(handler0_2));
                    break;
                case 1:
                    var handler1_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object>(Test, this);
                    var handler1_2 = new WeakActionEventHandler<WeakActionEventHandlerTest, object>(Test, this);
                    Assert.IsTrue(handler1_1 == handler1_2);
                    Assert.IsTrue(handler1_1.Equals(handler1_2));
                    break;
                case 2:
                    var handler2_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object>(Test, this);
                    var handler2_2 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object>(Test, this);
                    Assert.IsTrue(handler2_1 == handler2_2);
                    Assert.IsTrue(handler2_1.Equals(handler2_2));
                    break;
                case 3:
                    var handler3_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object>(Test, this);
                    var handler3_2 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object>(Test, this);
                    Assert.IsTrue(handler3_1 == handler3_2);
                    Assert.IsTrue(handler3_1.Equals(handler3_2));
                    break;
                case 4:
                    var handler4_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object>(Test, this);
                    var handler4_2 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object>(Test, this);
                    Assert.IsTrue(handler4_1 == handler4_2);
                    Assert.IsTrue(handler4_1.Equals(handler4_2));
                    break;
                case 5:
                    var handler5_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object>(Test, this);
                    var handler5_2 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object>(Test, this);
                    Assert.IsTrue(handler5_1 == handler5_2);
                    Assert.IsTrue(handler5_1.Equals(handler5_2));
                    break;
                case 6:
                    var handler6_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object>(Test, this);
                    var handler6_2 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object>(Test, this);
                    Assert.IsTrue(handler6_1 == handler6_2);
                    Assert.IsTrue(handler6_1.Equals(handler6_2));
                    break;
                case 7:
                    var handler7_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object>(Test, this);
                    var handler7_2 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object>(Test, this);
                    Assert.IsTrue(handler7_1 == handler7_2);
                    Assert.IsTrue(handler7_1.Equals(handler7_2));
                    break;
                case 8:
                    var handler8_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object>(Test, this);
                    var handler8_2 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object>(Test, this);
                    Assert.IsTrue(handler8_1 == handler8_2);
                    Assert.IsTrue(handler8_1.Equals(handler8_2));
                    break;
                case 9:
                    var handler9_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object>(Test, this);
                    var handler9_2 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object>(Test, this);
                    Assert.IsTrue(handler9_1 == handler9_2);
                    Assert.IsTrue(handler9_1.Equals(handler9_2));
                    break;
                case 10:
                    var handler10_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    var handler10_2 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    Assert.IsTrue(handler10_1 == handler10_2);
                    Assert.IsTrue(handler10_1.Equals(handler10_2));
                    break;
                case 11:
                    var handler11_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    var handler11_2 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    Assert.IsTrue(handler11_1 == handler11_2);
                    Assert.IsTrue(handler11_1.Equals(handler11_2));
                    break;
                case 12:
                    var handler12_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    var handler12_2 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    Assert.IsTrue(handler12_1 == handler12_2);
                    Assert.IsTrue(handler12_1.Equals(handler12_2));
                    break;
                case 13:
                    var handler13_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    var handler13_2 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    Assert.IsTrue(handler13_1 == handler13_2);
                    Assert.IsTrue(handler13_1.Equals(handler13_2));
                    break;
                case 14:
                    var handler14_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    var handler14_2 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    Assert.IsTrue(handler14_1 == handler14_2);
                    Assert.IsTrue(handler14_1.Equals(handler14_2));
                    break;
                case 15:
                    var handler15_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    var handler15_2 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    Assert.IsTrue(handler15_1 == handler15_2);
                    Assert.IsTrue(handler15_1.Equals(handler15_2));
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
        public void EqualsWithWeakActionDelegateTest(int argumentCount)
        {
            switch (argumentCount)
            {
                case 0:
                    var handler0_1 = new WeakActionEventHandler<WeakActionEventHandlerTest>(Test, this);
                    var handler0_2 = new Action(Test);
                    Assert.IsTrue(handler0_1 == handler0_2);
                    Assert.IsTrue(handler0_1.Equals(handler0_2));
                    break;
                case 1:
                    var handler1_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object>(Test, this);
                    var handler1_2 = new Action<object>(Test);
                    Assert.IsTrue(handler1_1 == handler1_2);
                    Assert.IsTrue(handler1_1.Equals(handler1_2));
                    break;
                case 2:
                    var handler2_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object>(Test, this);
                    var handler2_2 = new Action<object, object>(Test);
                    Assert.IsTrue(handler2_1 == handler2_2);
                    Assert.IsTrue(handler2_1.Equals(handler2_2));
                    break;
                case 3:
                    var handler3_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object>(Test, this);
                    var handler3_2 = new Action<object, object, object>(Test);
                    Assert.IsTrue(handler3_1 == handler3_2);
                    Assert.IsTrue(handler3_1.Equals(handler3_2));
                    break;
                case 4:
                    var handler4_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object>(Test, this);
                    var handler4_2 = new Action<object, object, object, object>(Test);
                    Assert.IsTrue(handler4_1 == handler4_2);
                    Assert.IsTrue(handler4_1.Equals(handler4_2));
                    break;
                case 5:
                    var handler5_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object>(Test, this);
                    var handler5_2 = new Action<object, object, object, object, object>(Test);
                    Assert.IsTrue(handler5_1 == handler5_2);
                    Assert.IsTrue(handler5_1.Equals(handler5_2));
                    break;
                case 6:
                    var handler6_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object>(Test, this);
                    var handler6_2 = new Action<object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler6_1 == handler6_2);
                    Assert.IsTrue(handler6_1.Equals(handler6_2));
                    break;
                case 7:
                    var handler7_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object>(Test, this);
                    var handler7_2 = new Action<object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler7_1 == handler7_2);
                    Assert.IsTrue(handler7_1.Equals(handler7_2));
                    break;
                case 8:
                    var handler8_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object>(Test, this);
                    var handler8_2 = new Action<object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler8_1 == handler8_2);
                    Assert.IsTrue(handler8_1.Equals(handler8_2));
                    break;
                case 9:
                    var handler9_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object>(Test, this);
                    var handler9_2 = new Action<object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler9_1 == handler9_2);
                    Assert.IsTrue(handler9_1.Equals(handler9_2));
                    break;
                case 10:
                    var handler10_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    var handler10_2 = new Action<object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler10_1 == handler10_2);
                    Assert.IsTrue(handler10_1.Equals(handler10_2));
                    break;
                case 11:
                    var handler11_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    var handler11_2 = new Action<object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler11_1 == handler11_2);
                    Assert.IsTrue(handler11_1.Equals(handler11_2));
                    break;
                case 12:
                    var handler12_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    var handler12_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler12_1 == handler12_2);
                    Assert.IsTrue(handler12_1.Equals(handler12_2));
                    break;
                case 13:
                    var handler13_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    var handler13_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler13_1 == handler13_2);
                    Assert.IsTrue(handler13_1.Equals(handler13_2));
                    break;
                case 14:
                    var handler14_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    var handler14_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler14_1 == handler14_2);
                    Assert.IsTrue(handler14_1.Equals(handler14_2));
                    break;
                case 15:
                    var handler15_1 = new WeakActionEventHandler<WeakActionEventHandlerTest, object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test, this);
                    var handler15_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(Test);
                    Assert.IsTrue(handler15_1 == handler15_2);
                    Assert.IsTrue(handler15_1.Equals(handler15_2));
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
        public void EventBusInvokeWithWeakActionHandlerTest(int argumentCount)
        {
            switch (argumentCount)
            {
                case 0:
                    var bus0 = new EventBus<Empty>();
                    bus0.SubscribeWeakly(Test, this);
                    bus0.Broadcast();
                    break;
                case 1:
                    var bus1 = new EventBus<ParameterNotification<object>>();
                    bus1.SubscribeWeakly(Test, this);
                    bus1.Broadcast(default);
                    break;
                case 2:
                    var bus2 = new EventBus<ParameterNotification<object, object>>();
                    bus2.SubscribeWeakly(Test, this);
                    bus2.Broadcast(default, default);
                    break;
                case 3:
                    var bus3 = new EventBus<ParameterNotification<object, object, object>>();
                    bus3.SubscribeWeakly(Test, this);
                    bus3.Broadcast(default, default, default);
                    break;
                case 4:
                    var bus4 = new EventBus<ParameterNotification<object, object, object, object>>();
                    bus4.SubscribeWeakly(Test, this);
                    bus4.Broadcast(default, default, default, default);
                    break;
                case 5:
                    var bus5 = new EventBus<ParameterNotification<object, object, object, object, object>>();
                    bus5.SubscribeWeakly(Test, this);
                    bus5.Broadcast(default, default, default, default, default);
                    break;
                case 6:
                    var bus6 = new EventBus<ParameterNotification<object, object, object, object, object, object>>();
                    bus6.SubscribeWeakly(Test, this);
                    bus6.Broadcast(default, default, default, default, default, default);
                    break;
                case 7:
                    var bus7 = new EventBus<ParameterNotification<object, object, object, object, object, object, object>>();
                    bus7.SubscribeWeakly(Test, this);
                    bus7.Broadcast(default, default, default, default, default, default, default);
                    break;
                case 8:
                    var bus8 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object>>();
                    bus8.SubscribeWeakly(Test, this);
                    bus8.Broadcast(default, default, default, default, default, default, default, default);
                    break;
                case 9:
                    var bus9 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object>>();
                    bus9.SubscribeWeakly(Test, this);
                    bus9.Broadcast(default, default, default, default, default, default, default, default, default);
                    break;
                case 10:
                    var bus10 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object>>();
                    bus10.SubscribeWeakly(Test, this);
                    bus10.Broadcast(default, default, default, default, default, default, default, default, default, default);
                    break;
                case 11:
                    var bus11 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object>>();
                    bus11.SubscribeWeakly(Test, this);
                    bus11.Broadcast(default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 12:
                    var bus12 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object>>();
                    bus12.SubscribeWeakly(Test, this);
                    bus12.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 13:
                    var bus13 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                    bus13.SubscribeWeakly(Test, this);
                    bus13.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 14:
                    var bus14 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                    bus14.SubscribeWeakly(Test, this);
                    bus14.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 15:
                    var bus15 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                    bus15.SubscribeWeakly(Test, this);
                    bus15.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
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
        public void EventBusUnsubscribeWithWeakActionHandlerTest(int argumentCount)
        {
            const int handlerCount = 5;
            switch (argumentCount)
            {
                case 0:
                    var bus0 = new EventBus<Empty>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus0.SubscribeWeakly(Test, this);
                    }
                    Assert.IsTrue(bus0.Unsubscribe(Test));
                    bus0.Broadcast();
                    break;
                case 1:
                    var bus1 = new EventBus<ParameterNotification<object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus1.SubscribeWeakly(Test, this);
                    }
                    Assert.IsTrue(bus1.Unsubscribe(Test));
                    bus1.Broadcast(default);
                    break;
                case 2:
                    var bus2 = new EventBus<ParameterNotification<object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus2.SubscribeWeakly(Test, this);
                    }
                    Assert.IsTrue(bus2.Unsubscribe(Test));
                    bus2.Broadcast(default, default);
                    break;
                case 3:
                    var bus3 = new EventBus<ParameterNotification<object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus3.SubscribeWeakly(Test, this);
                    }
                    Assert.IsTrue(bus3.Unsubscribe(Test));
                    bus3.Broadcast(default, default, default);
                    break;
                case 4:
                    var bus4 = new EventBus<ParameterNotification<object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus4.SubscribeWeakly(Test, this);
                    }
                    Assert.IsTrue(bus4.Unsubscribe(Test));
                    bus4.Broadcast(default, default, default, default);
                    break;
                case 5:
                    var bus5 = new EventBus<ParameterNotification<object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus5.SubscribeWeakly(Test, this);
                    }
                    Assert.IsTrue(bus5.Unsubscribe(Test));
                    bus5.Broadcast(default, default, default, default, default);
                    break;
                case 6:
                    var bus6 = new EventBus<ParameterNotification<object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus6.SubscribeWeakly(Test, this);
                    }
                    Assert.IsTrue(bus6.Unsubscribe(Test));
                    bus6.Broadcast(default, default, default, default, default, default);
                    break;
                case 7:
                    var bus7 = new EventBus<ParameterNotification<object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus7.SubscribeWeakly(Test, this);
                    }
                    Assert.IsTrue(bus7.Unsubscribe(Test));
                    bus7.Broadcast(default, default, default, default, default, default, default);
                    break;
                case 8:
                    var bus8 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus8.SubscribeWeakly(Test, this);
                    }
                    Assert.IsTrue(bus8.Unsubscribe(Test));
                    bus8.Broadcast(default, default, default, default, default, default, default, default);
                    break;
                case 9:
                    var bus9 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus9.SubscribeWeakly(Test, this);
                    }
                    Assert.IsTrue(bus9.Unsubscribe(Test));
                    bus9.Broadcast(default, default, default, default, default, default, default, default, default);
                    break;
                case 10:
                    var bus10 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus10.SubscribeWeakly(Test, this);
                    }
                    Assert.IsTrue(bus10.Unsubscribe(Test));
                    bus10.Broadcast(default, default, default, default, default, default, default, default, default, default);
                    break;
                case 11:
                    var bus11 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus11.SubscribeWeakly(Test, this);
                    }
                    Assert.IsTrue(bus11.Unsubscribe(Test));
                    bus11.Broadcast(default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 12:
                    var bus12 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus12.SubscribeWeakly(Test, this);
                    }
                    Assert.IsTrue(bus12.Unsubscribe(Test));
                    bus12.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 13:
                    var bus13 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus13.SubscribeWeakly(Test, this);
                    }
                    Assert.IsTrue(bus13.Unsubscribe(Test));
                    bus13.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 14:
                    var bus14 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus14.SubscribeWeakly(Test, this);
                    }
                    Assert.IsTrue(bus14.Unsubscribe(Test));
                    bus14.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 15:
                    var bus15 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus15.SubscribeWeakly(Test, this);
                    }
                    Assert.IsTrue(bus15.Unsubscribe(Test));
                    bus15.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
            }
            Assert.IsTrue(m_HandleCount == handlerCount - 1);
        }
    }
}