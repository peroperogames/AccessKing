/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/01 16:06:12
 */

using System;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace PeroTools2.AccessKing.Editor.Tests
{
    // ReSharper disable All
    public sealed class WeakActionEventHandlerTest
    {
        private int m_HandleCount;
        private bool m_IsInvoke;
        private TempScritableObject unityObj;

        [SetUp]
        public void SetUp()
        {
            unityObj = ScriptableObject.CreateInstance<TempScritableObject>();
            unityObj.test = this;
            m_HandleCount = 0;
            m_IsInvoke = false;
        }

        private class TempScritableObject : ScriptableObject
        {
            public WeakActionEventHandlerTest test;

            public void Test()
            {
                test.m_HandleCount++;
                test.m_IsInvoke = true;
            }

            public void Test(object p)
            {
                test.m_HandleCount++;
                test.m_IsInvoke = true;
            }

            public void Test(object p1, object p2)
            {
                test.m_HandleCount++;
                test.m_IsInvoke = true;
            }

            public void Test(object p1, object p2, object p3)
            {
                test.m_HandleCount++;
                test.m_IsInvoke = true;
            }

            public void Test(object p1, object p2, object p3, object p4)
            {
                test.m_HandleCount++;
                test.m_IsInvoke = true;
            }

            public void Test(object p1, object p2, object p3, object p4, object p5)
            {
                test.m_HandleCount++;
                test.m_IsInvoke = true;
            }

            public void Test(object p1, object p2, object p3, object p4, object p5, object p6)
            {
                test.m_HandleCount++;
                test.m_IsInvoke = true;
            }

            public void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7)
            {
                test.m_HandleCount++;
                test.m_IsInvoke = true;
            }

            public void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8)
            {
                test.m_HandleCount++;
                test.m_IsInvoke = true;
            }

            public void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9)
            {
                test.m_HandleCount++;
                test.m_IsInvoke = true;
            }

            public void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9, object p10)
            {
                test.m_HandleCount++;
                test.m_IsInvoke = true;
            }

            public void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9, object p10, object p11)
            {
                test.m_HandleCount++;
                test.m_IsInvoke = true;
            }

            public void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9, object p10, object p11, object p12)
            {
                test.m_HandleCount++;
                test.m_IsInvoke = true;
            }

            public void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9, object p10, object p11, object p12, object p13)
            {
                test.m_HandleCount++;
                test.m_IsInvoke = true;
            }

            public void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9, object p10, object p11, object p12, object p13, object p14)
            {
                test.m_HandleCount++;
                test.m_IsInvoke = true;
            }

            public void Test(object p1, object p2, object p3, object p4, object p5, object p6, object p7, object p8, object p9, object p10, object p11, object p12, object p13, object p14, object p15)
            {
                test.m_HandleCount++;
                test.m_IsInvoke = true;
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
        public void HandlerInvokeTest(int argumentCount)
        {
            switch (argumentCount)
            {
                case 0:
                    var handler0 = new WeakActionEventHandler(unityObj.Test, this.unityObj);
                    handler0.Handle();
                    break;
                case 1:
                    var handler1 = new WeakActionEventHandler<object>(unityObj.Test, this.unityObj);
                    handler1.Handle(default);
                    break;
                case 2:
                    var handler2 = new WeakActionEventHandler<object, object>(unityObj.Test, this.unityObj);
                    handler2.Handle(default, default);
                    break;
                case 3:
                    var handler3 = new WeakActionEventHandler<object, object, object>(unityObj.Test, this.unityObj);
                    handler3.Handle(default, default, default);
                    break;
                case 4:
                    var handler4 = new WeakActionEventHandler<object, object, object, object>(unityObj.Test, this.unityObj);
                    handler4.Handle(default, default, default, default);
                    break;
                case 5:
                    var handler5 = new WeakActionEventHandler<object, object, object, object, object>(unityObj.Test, this.unityObj);
                    handler5.Handle(default, default, default, default, default);
                    break;
                case 6:
                    var handler6 = new WeakActionEventHandler<object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    handler6.Handle(default, default, default, default, default, default);
                    break;
                case 7:
                    var handler7 = new WeakActionEventHandler<object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    handler7.Handle(default, default, default, default, default, default, default);
                    break;
                case 8:
                    var handler8 = new WeakActionEventHandler<object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    handler8.Handle(default, default, default, default, default, default, default, default);
                    break;
                case 9:
                    var handler9 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    handler9.Handle(default, default, default, default, default, default, default, default, default);
                    break;
                case 10:
                    var handler10 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    handler10.Handle(default, default, default, default, default, default, default, default, default, default);
                    break;
                case 11:
                    var handler11 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    handler11.Handle(default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 12:
                    var handler12 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    handler12.Handle(default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 13:
                    var handler13 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    handler13.Handle(default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 14:
                    var handler14 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    handler14.Handle(default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 15:
                    var handler15 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
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
            switch (argumentCount)
            {
                case 0:
                {
                    var handler = new WeakActionEventHandler(unityObj.Test, unityObj);
                    UnityEngine.Object.DestroyImmediate(unityObj);
                    (handler as WeakActionEventHandler).Handle();
                    break;
                }
                case 1:
                {
                    var handler = new WeakActionEventHandler<object>(unityObj.Test, unityObj);
                    UnityEngine.Object.DestroyImmediate(unityObj);
                    (handler as WeakActionEventHandler<object>).Handle(default);
                    break;
                }
                case 2:
                {
                    var handler = new WeakActionEventHandler<object, object>(unityObj.Test, unityObj);
                    UnityEngine.Object.DestroyImmediate(unityObj);
                    (handler as WeakActionEventHandler<object, object>).Handle(default, default);
                    break;
                }
                case 3:
                {
                    var handler = new WeakActionEventHandler<object, object, object>(unityObj.Test, unityObj);
                    UnityEngine.Object.DestroyImmediate(unityObj);
                    (handler as WeakActionEventHandler<object, object, object>).Handle(default, default, default);
                    break;
                }
                case 4:
                {
                    var handler = new WeakActionEventHandler<object, object, object, object>(unityObj.Test, unityObj);
                    UnityEngine.Object.DestroyImmediate(unityObj);
                    (handler as WeakActionEventHandler<object, object, object, object>).Handle(default, default, default, default);
                    break;
                }
                case 5:
                {
                    var handler = new WeakActionEventHandler<object, object, object, object, object>(unityObj.Test, unityObj);
                    UnityEngine.Object.DestroyImmediate(unityObj);
                    (handler as WeakActionEventHandler<object, object, object, object, object>).Handle(default, default, default, default, default);
                    break;
                }
                case 6:
                {
                    var handler = new WeakActionEventHandler<object, object, object, object, object, object>(unityObj.Test, unityObj);
                    UnityEngine.Object.DestroyImmediate(unityObj);
                    (handler as WeakActionEventHandler<object, object, object, object, object, object>).Handle(default, default, default, default, default, default);
                    break;
                }
                case 7:
                {
                    var handler = new WeakActionEventHandler<object, object, object, object, object, object, object>(unityObj.Test, unityObj);
                    UnityEngine.Object.DestroyImmediate(unityObj);
                    (handler as WeakActionEventHandler<object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default);
                    break;
                }
                case 8:
                {
                    var handler = new WeakActionEventHandler<object, object, object, object, object, object, object, object>(unityObj.Test, unityObj);
                    UnityEngine.Object.DestroyImmediate(unityObj);
                    (handler as WeakActionEventHandler<object, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default, default);
                    break;
                }
                case 9:
                {
                    var handler = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object>(unityObj.Test, unityObj);
                    UnityEngine.Object.DestroyImmediate(unityObj);
                    (handler as WeakActionEventHandler<object, object, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default, default, default);
                    break;
                }
                case 10:
                {
                    var handler = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object>(unityObj.Test, unityObj);
                    UnityEngine.Object.DestroyImmediate(unityObj);
                    (handler as WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default, default, default, default);
                    break;
                }
                case 11:
                {
                    var handler = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, unityObj);
                    UnityEngine.Object.DestroyImmediate(unityObj);
                    (handler as WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default, default, default, default, default);
                    break;
                }
                case 12:
                {
                    var handler = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, unityObj);
                    UnityEngine.Object.DestroyImmediate(unityObj);
                    (handler as WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                }
                case 13:
                {
                    var handler = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, unityObj);
                    UnityEngine.Object.DestroyImmediate(unityObj);
                    (handler as WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                }
                case 14:
                {
                    var handler = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, unityObj);
                    UnityEngine.Object.DestroyImmediate(unityObj);
                    (handler as WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                }
                case 15:
                {
                    var handler = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, unityObj);
                    UnityEngine.Object.DestroyImmediate(unityObj);
                    (handler as WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>).Handle(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                }
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
                    var handler0_1 = new WeakActionEventHandler(unityObj.Test, this.unityObj);
                    var handler0_2 = new WeakActionEventHandler(unityObj.Test, this.unityObj);
                    Assert.IsTrue(handler0_1 == handler0_2);
                    Assert.IsTrue(handler0_1.Equals(handler0_2));
                    break;
                case 1:
                    var handler1_1 = new WeakActionEventHandler<object>(unityObj.Test, this.unityObj);
                    var handler1_2 = new WeakActionEventHandler<object>(unityObj.Test, this.unityObj);
                    Assert.IsTrue(handler1_1 == handler1_2);
                    Assert.IsTrue(handler1_1.Equals(handler1_2));
                    break;
                case 2:
                    var handler2_1 = new WeakActionEventHandler<object, object>(unityObj.Test, this.unityObj);
                    var handler2_2 = new WeakActionEventHandler<object, object>(unityObj.Test, this.unityObj);
                    Assert.IsTrue(handler2_1 == handler2_2);
                    Assert.IsTrue(handler2_1.Equals(handler2_2));
                    break;
                case 3:
                    var handler3_1 = new WeakActionEventHandler<object, object, object>(unityObj.Test, this.unityObj);
                    var handler3_2 = new WeakActionEventHandler<object, object, object>(unityObj.Test, this.unityObj);
                    Assert.IsTrue(handler3_1 == handler3_2);
                    Assert.IsTrue(handler3_1.Equals(handler3_2));
                    break;
                case 4:
                    var handler4_1 = new WeakActionEventHandler<object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler4_2 = new WeakActionEventHandler<object, object, object, object>(unityObj.Test, this.unityObj);
                    Assert.IsTrue(handler4_1 == handler4_2);
                    Assert.IsTrue(handler4_1.Equals(handler4_2));
                    break;
                case 5:
                    var handler5_1 = new WeakActionEventHandler<object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler5_2 = new WeakActionEventHandler<object, object, object, object, object>(unityObj.Test, this.unityObj);
                    Assert.IsTrue(handler5_1 == handler5_2);
                    Assert.IsTrue(handler5_1.Equals(handler5_2));
                    break;
                case 6:
                    var handler6_1 = new WeakActionEventHandler<object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler6_2 = new WeakActionEventHandler<object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    Assert.IsTrue(handler6_1 == handler6_2);
                    Assert.IsTrue(handler6_1.Equals(handler6_2));
                    break;
                case 7:
                    var handler7_1 = new WeakActionEventHandler<object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler7_2 = new WeakActionEventHandler<object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    Assert.IsTrue(handler7_1 == handler7_2);
                    Assert.IsTrue(handler7_1.Equals(handler7_2));
                    break;
                case 8:
                    var handler8_1 = new WeakActionEventHandler<object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler8_2 = new WeakActionEventHandler<object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    Assert.IsTrue(handler8_1 == handler8_2);
                    Assert.IsTrue(handler8_1.Equals(handler8_2));
                    break;
                case 9:
                    var handler9_1 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler9_2 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    Assert.IsTrue(handler9_1 == handler9_2);
                    Assert.IsTrue(handler9_1.Equals(handler9_2));
                    break;
                case 10:
                    var handler10_1 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler10_2 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    Assert.IsTrue(handler10_1 == handler10_2);
                    Assert.IsTrue(handler10_1.Equals(handler10_2));
                    break;
                case 11:
                    var handler11_1 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler11_2 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    Assert.IsTrue(handler11_1 == handler11_2);
                    Assert.IsTrue(handler11_1.Equals(handler11_2));
                    break;
                case 12:
                    var handler12_1 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler12_2 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    Assert.IsTrue(handler12_1 == handler12_2);
                    Assert.IsTrue(handler12_1.Equals(handler12_2));
                    break;
                case 13:
                    var handler13_1 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler13_2 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    Assert.IsTrue(handler13_1 == handler13_2);
                    Assert.IsTrue(handler13_1.Equals(handler13_2));
                    break;
                case 14:
                    var handler14_1 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler14_2 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    Assert.IsTrue(handler14_1 == handler14_2);
                    Assert.IsTrue(handler14_1.Equals(handler14_2));
                    break;
                case 15:
                    var handler15_1 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler15_2 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
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
                    var handler0_1 = new WeakActionEventHandler(unityObj.Test, this.unityObj);
                    var handler0_2 = new Action(unityObj.Test);
                    Assert.IsTrue(handler0_1 == handler0_2);
                    Assert.IsTrue(handler0_1.Equals(handler0_2));
                    break;
                case 1:
                    var handler1_1 = new WeakActionEventHandler<object>(unityObj.Test, this.unityObj);
                    var handler1_2 = new Action<object>(unityObj.Test);
                    Assert.IsTrue(handler1_1 == handler1_2);
                    Assert.IsTrue(handler1_1.Equals(handler1_2));
                    break;
                case 2:
                    var handler2_1 = new WeakActionEventHandler<object, object>(unityObj.Test, this.unityObj);
                    var handler2_2 = new Action<object, object>(unityObj.Test);
                    Assert.IsTrue(handler2_1 == handler2_2);
                    Assert.IsTrue(handler2_1.Equals(handler2_2));
                    break;
                case 3:
                    var handler3_1 = new WeakActionEventHandler<object, object, object>(unityObj.Test, this.unityObj);
                    var handler3_2 = new Action<object, object, object>(unityObj.Test);
                    Assert.IsTrue(handler3_1 == handler3_2);
                    Assert.IsTrue(handler3_1.Equals(handler3_2));
                    break;
                case 4:
                    var handler4_1 = new WeakActionEventHandler<object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler4_2 = new Action<object, object, object, object>(unityObj.Test);
                    Assert.IsTrue(handler4_1 == handler4_2);
                    Assert.IsTrue(handler4_1.Equals(handler4_2));
                    break;
                case 5:
                    var handler5_1 = new WeakActionEventHandler<object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler5_2 = new Action<object, object, object, object, object>(unityObj.Test);
                    Assert.IsTrue(handler5_1 == handler5_2);
                    Assert.IsTrue(handler5_1.Equals(handler5_2));
                    break;
                case 6:
                    var handler6_1 = new WeakActionEventHandler<object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler6_2 = new Action<object, object, object, object, object, object>(unityObj.Test);
                    Assert.IsTrue(handler6_1 == handler6_2);
                    Assert.IsTrue(handler6_1.Equals(handler6_2));
                    break;
                case 7:
                    var handler7_1 = new WeakActionEventHandler<object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler7_2 = new Action<object, object, object, object, object, object, object>(unityObj.Test);
                    Assert.IsTrue(handler7_1 == handler7_2);
                    Assert.IsTrue(handler7_1.Equals(handler7_2));
                    break;
                case 8:
                    var handler8_1 = new WeakActionEventHandler<object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler8_2 = new Action<object, object, object, object, object, object, object, object>(unityObj.Test);
                    Assert.IsTrue(handler8_1 == handler8_2);
                    Assert.IsTrue(handler8_1.Equals(handler8_2));
                    break;
                case 9:
                    var handler9_1 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler9_2 = new Action<object, object, object, object, object, object, object, object, object>(unityObj.Test);
                    Assert.IsTrue(handler9_1 == handler9_2);
                    Assert.IsTrue(handler9_1.Equals(handler9_2));
                    break;
                case 10:
                    var handler10_1 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler10_2 = new Action<object, object, object, object, object, object, object, object, object, object>(unityObj.Test);
                    Assert.IsTrue(handler10_1 == handler10_2);
                    Assert.IsTrue(handler10_1.Equals(handler10_2));
                    break;
                case 11:
                    var handler11_1 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler11_2 = new Action<object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test);
                    Assert.IsTrue(handler11_1 == handler11_2);
                    Assert.IsTrue(handler11_1.Equals(handler11_2));
                    break;
                case 12:
                    var handler12_1 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler12_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test);
                    Assert.IsTrue(handler12_1 == handler12_2);
                    Assert.IsTrue(handler12_1.Equals(handler12_2));
                    break;
                case 13:
                    var handler13_1 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler13_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test);
                    Assert.IsTrue(handler13_1 == handler13_2);
                    Assert.IsTrue(handler13_1.Equals(handler13_2));
                    break;
                case 14:
                    var handler14_1 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler14_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test);
                    Assert.IsTrue(handler14_1 == handler14_2);
                    Assert.IsTrue(handler14_1.Equals(handler14_2));
                    break;
                case 15:
                    var handler15_1 = new WeakActionEventHandler<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test, this.unityObj);
                    var handler15_2 = new Action<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>(unityObj.Test);
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
                    bus0.SubscribeWeakly(this.unityObj, unityObj.Test);
                    bus0.Broadcast();
                    break;
                case 1:
                    var bus1 = new EventBus<ParameterNotification<object>>();
                    bus1.SubscribeWeakly(this.unityObj, unityObj.Test);
                    bus1.Broadcast(default);
                    break;
                case 2:
                    var bus2 = new EventBus<ParameterNotification<object, object>>();
                    bus2.SubscribeWeakly(this.unityObj, unityObj.Test);
                    bus2.Broadcast(default, default);
                    break;
                case 3:
                    var bus3 = new EventBus<ParameterNotification<object, object, object>>();
                    bus3.SubscribeWeakly(this.unityObj, unityObj.Test);
                    bus3.Broadcast(default, default, default);
                    break;
                case 4:
                    var bus4 = new EventBus<ParameterNotification<object, object, object, object>>();
                    bus4.SubscribeWeakly(this.unityObj, unityObj.Test);
                    bus4.Broadcast(default, default, default, default);
                    break;
                case 5:
                    var bus5 = new EventBus<ParameterNotification<object, object, object, object, object>>();
                    bus5.SubscribeWeakly(this.unityObj, unityObj.Test);
                    bus5.Broadcast(default, default, default, default, default);
                    break;
                case 6:
                    var bus6 = new EventBus<ParameterNotification<object, object, object, object, object, object>>();
                    bus6.SubscribeWeakly(this.unityObj, unityObj.Test);
                    bus6.Broadcast(default, default, default, default, default, default);
                    break;
                case 7:
                    var bus7 = new EventBus<ParameterNotification<object, object, object, object, object, object, object>>();
                    bus7.SubscribeWeakly(this.unityObj, unityObj.Test);
                    bus7.Broadcast(default, default, default, default, default, default, default);
                    break;
                case 8:
                    var bus8 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object>>();
                    bus8.SubscribeWeakly(this.unityObj, unityObj.Test);
                    bus8.Broadcast(default, default, default, default, default, default, default, default);
                    break;
                case 9:
                    var bus9 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object>>();
                    bus9.SubscribeWeakly(this.unityObj, unityObj.Test);
                    bus9.Broadcast(default, default, default, default, default, default, default, default, default);
                    break;
                case 10:
                    var bus10 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object>>();
                    bus10.SubscribeWeakly(this.unityObj, unityObj.Test);
                    bus10.Broadcast(default, default, default, default, default, default, default, default, default, default);
                    break;
                case 11:
                    var bus11 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object>>();
                    bus11.SubscribeWeakly(this.unityObj, unityObj.Test);
                    bus11.Broadcast(default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 12:
                    var bus12 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object>>();
                    bus12.SubscribeWeakly(this.unityObj, unityObj.Test);
                    bus12.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 13:
                    var bus13 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                    bus13.SubscribeWeakly(this.unityObj, unityObj.Test);
                    bus13.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 14:
                    var bus14 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                    bus14.SubscribeWeakly(this.unityObj, unityObj.Test);
                    bus14.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 15:
                    var bus15 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                    bus15.SubscribeWeakly(this.unityObj, unityObj.Test);
                    bus15.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
            }
            Assert.IsTrue(m_HandleCount == 1);
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
                        bus0.SubscribeWeakly(this.unityObj, unityObj.Test);
                    }
                    Assert.IsTrue(bus0.Unsubscribe(unityObj.Test));
                    bus0.Broadcast();
                    break;
                case 1:
                    var bus1 = new EventBus<ParameterNotification<object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus1.SubscribeWeakly(this.unityObj, unityObj.Test);
                    }
                    Assert.IsTrue(bus1.Unsubscribe(unityObj.Test));
                    bus1.Broadcast(default);
                    break;
                case 2:
                    var bus2 = new EventBus<ParameterNotification<object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus2.SubscribeWeakly(this.unityObj, unityObj.Test);
                    }
                    Assert.IsTrue(bus2.Unsubscribe(unityObj.Test));
                    bus2.Broadcast(default, default);
                    break;
                case 3:
                    var bus3 = new EventBus<ParameterNotification<object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus3.SubscribeWeakly(this.unityObj, unityObj.Test);
                    }
                    Assert.IsTrue(bus3.Unsubscribe(unityObj.Test));
                    bus3.Broadcast(default, default, default);
                    break;
                case 4:
                    var bus4 = new EventBus<ParameterNotification<object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus4.SubscribeWeakly(this.unityObj, unityObj.Test);
                    }
                    Assert.IsTrue(bus4.Unsubscribe(unityObj.Test));
                    bus4.Broadcast(default, default, default, default);
                    break;
                case 5:
                    var bus5 = new EventBus<ParameterNotification<object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus5.SubscribeWeakly(this.unityObj, unityObj.Test);
                    }
                    Assert.IsTrue(bus5.Unsubscribe(unityObj.Test));
                    bus5.Broadcast(default, default, default, default, default);
                    break;
                case 6:
                    var bus6 = new EventBus<ParameterNotification<object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus6.SubscribeWeakly(this.unityObj, unityObj.Test);
                    }
                    Assert.IsTrue(bus6.Unsubscribe(unityObj.Test));
                    bus6.Broadcast(default, default, default, default, default, default);
                    break;
                case 7:
                    var bus7 = new EventBus<ParameterNotification<object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus7.SubscribeWeakly(this.unityObj, unityObj.Test);
                    }
                    Assert.IsTrue(bus7.Unsubscribe(unityObj.Test));
                    bus7.Broadcast(default, default, default, default, default, default, default);
                    break;
                case 8:
                    var bus8 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus8.SubscribeWeakly(this.unityObj, unityObj.Test);
                    }
                    Assert.IsTrue(bus8.Unsubscribe(unityObj.Test));
                    bus8.Broadcast(default, default, default, default, default, default, default, default);
                    break;
                case 9:
                    var bus9 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus9.SubscribeWeakly(this.unityObj, unityObj.Test);
                    }
                    Assert.IsTrue(bus9.Unsubscribe(unityObj.Test));
                    bus9.Broadcast(default, default, default, default, default, default, default, default, default);
                    break;
                case 10:
                    var bus10 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus10.SubscribeWeakly(this.unityObj, unityObj.Test);
                    }
                    Assert.IsTrue(bus10.Unsubscribe(unityObj.Test));
                    bus10.Broadcast(default, default, default, default, default, default, default, default, default, default);
                    break;
                case 11:
                    var bus11 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus11.SubscribeWeakly(this.unityObj, unityObj.Test);
                    }
                    Assert.IsTrue(bus11.Unsubscribe(unityObj.Test));
                    bus11.Broadcast(default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 12:
                    var bus12 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus12.SubscribeWeakly(this.unityObj, unityObj.Test);
                    }
                    Assert.IsTrue(bus12.Unsubscribe(unityObj.Test));
                    bus12.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 13:
                    var bus13 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus13.SubscribeWeakly(this.unityObj, unityObj.Test);
                    }
                    Assert.IsTrue(bus13.Unsubscribe(unityObj.Test));
                    bus13.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 14:
                    var bus14 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus14.SubscribeWeakly(this.unityObj, unityObj.Test);
                    }
                    Assert.IsTrue(bus14.Unsubscribe(unityObj.Test));
                    bus14.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
                case 15:
                    var bus15 = new EventBus<ParameterNotification<object, object, object, object, object, object, object, object, object, object, object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus15.SubscribeWeakly(this.unityObj, unityObj.Test);
                    }
                    Assert.IsTrue(bus15.Unsubscribe(unityObj.Test));
                    bus15.Broadcast(default, default, default, default, default, default, default, default, default, default, default, default, default, default, default);
                    break;
            }
            Assert.IsTrue(m_HandleCount == handlerCount - 1);
        }
    }
}