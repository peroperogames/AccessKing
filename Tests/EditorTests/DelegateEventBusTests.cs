using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;
using UnityEngine;

namespace PeroTools2.AccessKing.Editor.Tests
{
    public class DelegateEventBusTests
    {
        private static bool s_HasInvokeDelegate;
        private static DelegateListener s_DelegateListener;

        [SetUp]
        public void SetUp()
        {
            s_HasInvokeDelegate = false;
            s_DelegateListener = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }


        [TestCase(false, true, ExpectedResult = false)]
        [TestCase(true, true, ExpectedResult = true)]
        [TestCase(true, false, ExpectedResult = true)]
        [TestCase(false, false, ExpectedResult = true)]
        public bool WeakReferenceTest(bool keepInstance, bool invokeGC)
        {
            s_HasInvokeDelegate = false;
            var eventBus = new DelegateEventBus(new ActionHandler(new WeakDelegate<Action>()));
            if (keepInstance)
            {
                s_DelegateListener = new DelegateListener(eventBus);
                Debug.Log(s_DelegateListener.GetHashCode());
            }
            else
            {
                _ = new DelegateListener(eventBus);
            }

            if (invokeGC)
            {
                CreateBigMemory();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            eventBus.Publish();
            return s_HasInvokeDelegate;
        }

        private static void CreateBigMemory()
        {
            var programs = new List<BigObject>();
            for (var i = 0; i < 1000; i++)
            {
                programs.Add(new BigObject());
            }

            programs.Clear();
            programs = null;
        }

        public class DelegateListener
        {
            public DelegateListener(DelegateEventBus eventBus)
            {
                eventBus.Subscribe(Test);
            }

            private void Test()
            {
                Assert.IsTrue(ReferenceEquals(this, s_DelegateListener));
                s_HasInvokeDelegate = true;
            }
        }
    }
}

[StructLayout(LayoutKind.Explicit)]
internal class BigObject
{
    [FieldOffset(0)] public long num1 = 0;
    [FieldOffset(1007789)] long num2 = 0;
}