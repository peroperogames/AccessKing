using System;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Editor.Tests.EventTests
{
    public class ActionEventHandlerTest
    {
        private bool m_IsInvoke;
        private int m_HandleCount;

        [SetUp]
        public void SetUp()
        {
            m_IsInvoke = false;
            m_HandleCount = 0;
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
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
            }

            Assert.IsTrue(m_IsInvoke);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void EqualsWithActionEventHandlerTest(int argumentCount)
        {
            switch (argumentCount)
            {
                case 0:
                    var handler0_1 = new ActionEventHandler(Test);
                    var handler0_2 = new ActionEventHandler(Test);
                    Assert.IsTrue(handler0_1 == handler0_2);
                    Assert.IsTrue(handler0_1.Equals(handler0_2));
                    break;
                case 1:
                    var handler1_1 = new ActionEventHandler<object>(Test);
                    var handler1_2 = new ActionEventHandler<object>(Test);
                    Assert.IsTrue(handler1_1 == handler1_2);
                    Assert.IsTrue(handler1_1.Equals(handler1_2));
                    break;
                case 2:
                    var handler2_1 = new ActionEventHandler<object, object>(Test);
                    var handler2_2 = new ActionEventHandler<object, object>(Test);
                    Assert.IsTrue(handler2_1 == handler2_2);
                    Assert.IsTrue(handler2_1.Equals(handler2_2));
                    break;
                case 3:
                    var handler3_1 = new ActionEventHandler<object, object, object>(Test);
                    var handler3_2 = new ActionEventHandler<object, object, object>(Test);
                    Assert.IsTrue(handler3_1 == handler3_2);
                    Assert.IsTrue(handler3_1.Equals(handler3_2));
                    break;
                case 4:
                    var handler4_1 = new ActionEventHandler<object, object, object, object>(Test);
                    var handler4_2 = new ActionEventHandler<object, object, object, object>(Test);
                    Assert.IsTrue(handler4_1 == handler4_2);
                    Assert.IsTrue(handler4_1.Equals(handler4_2));
                    break;
                case 5:
                    var handler5_1 = new ActionEventHandler<object, object, object, object, object>(Test);
                    var handler5_2 = new ActionEventHandler<object, object, object, object, object>(Test);
                    Assert.IsTrue(handler5_1 == handler5_2);
                    Assert.IsTrue(handler5_1.Equals(handler5_2));
                    break;
            }
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void EqualsWithActionDelegateTest(int argumentCount)
        {
            switch (argumentCount)
            {
                case 0:
                    var handler0_1 = new ActionEventHandler(Test);
                    var handler0_2 = new Action(Test);
                    Assert.IsTrue(handler0_1 == handler0_2);
                    Assert.IsTrue(handler0_1.Equals(handler0_2));
                    break;
                case 1:
                    var handler1_1 = new ActionEventHandler<object>(Test);
                    var handler1_2 = new Action<object>(Test);
                    Assert.IsTrue(handler1_1 == handler1_2);
                    Assert.IsTrue(handler1_1.Equals(handler1_2));
                    break;
                case 2:
                    var handler2_1 = new ActionEventHandler<object, object>(Test);
                    var handler2_2 = new Action<object, object>(Test);
                    Assert.IsTrue(handler2_1 == handler2_2);
                    Assert.IsTrue(handler2_1.Equals(handler2_2));
                    break;
                case 3:
                    var handler3_1 = new ActionEventHandler<object, object, object>(Test);
                    var handler3_2 = new Action<object, object, object>(Test);
                    Assert.IsTrue(handler3_1 == handler3_2);
                    Assert.IsTrue(handler3_1.Equals(handler3_2));
                    break;
                case 4:
                    var handler4_1 = new ActionEventHandler<object, object, object, object>(Test);
                    var handler4_2 = new Action<object, object, object, object>(Test);
                    Assert.IsTrue(handler4_1 == handler4_2);
                    Assert.IsTrue(handler4_1.Equals(handler4_2));
                    break;
                case 5:
                    var handler5_1 = new ActionEventHandler<object, object, object, object, object>(Test);
                    var handler5_2 = new Action<object, object, object, object, object>(Test);
                    Assert.IsTrue(handler5_1 == handler5_2);
                    Assert.IsTrue(handler5_1.Equals(handler5_2));
                    break;
            }
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void EventBusInvokeWithActionHandlerTest(int argumentCount)
        {
            object defaultParameter = null;
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
                    bus1.Broadcast(defaultParameter);
                    break;
                case 2:
                    var bus2 = new EventBus<ParameterNotification<object, object>>();
                    bus2.Subscribe(Test);
                    bus2.Broadcast(defaultParameter, defaultParameter);
                    break;
                case 3:
                    var bus3 = new EventBus<ParameterNotification<object, object, object>>();
                    bus3.Subscribe(Test);
                    bus3.Broadcast(defaultParameter, defaultParameter, defaultParameter);
                    break;
                case 4:
                    var bus4 = new EventBus<ParameterNotification<object, object, object, object>>();
                    bus4.Subscribe(Test);
                    bus4.Broadcast(defaultParameter, defaultParameter, defaultParameter, defaultParameter);
                    break;
                case 5:
                    var bus5 = new EventBus<ParameterNotification<object, object, object, object, object>>();
                    bus5.Subscribe(Test);
                    bus5.Broadcast(defaultParameter, defaultParameter, defaultParameter, defaultParameter, defaultParameter);
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
        public void EventBusUnsubscribeWithActionHandlerTest(int argumentCount)
        {
            const int handlerCount = 5;
            object defaultParameter = null;
            switch (argumentCount)
            {
                case 0:
                    var bus0 = new EventBus<Empty>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus0.Subscribe(Test);
                    }
                    Assert.IsTrue(bus0.Unsubscribe(Test));
                    bus0.Broadcast(ParameterNotification.Empty);
                    break;
                case 1:
                    var bus1 = new EventBus<ParameterNotification<object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus1.Subscribe(Test);
                    }
                    Assert.IsTrue(bus1.Unsubscribe(Test));
                    bus1.Broadcast(defaultParameter);
                    break;
                case 2:
                    var bus2 = new EventBus<ParameterNotification<object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus2.Subscribe(Test);
                    }
                    Assert.IsTrue(bus2.Unsubscribe(Test));
                    bus2.Broadcast(defaultParameter, defaultParameter);
                    break;
                case 3:
                    var bus3 = new EventBus<ParameterNotification<object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus3.Subscribe(Test);
                    }
                    Assert.IsTrue(bus3.Unsubscribe(Test));
                    bus3.Broadcast(defaultParameter, defaultParameter, defaultParameter);
                    break;
                case 4:
                    var bus4 = new EventBus<ParameterNotification<object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus4.Subscribe(Test);
                    }
                    Assert.IsTrue(bus4.Unsubscribe(Test));
                    bus4.Broadcast(defaultParameter, defaultParameter, defaultParameter, defaultParameter);
                    break;
                case 5:
                    var bus5 = new EventBus<ParameterNotification<object, object, object, object, object>>();
                    for (var i = 0; i < handlerCount; i++)
                    {
                        bus5.Subscribe(Test);
                    }
                    Assert.IsTrue(bus5.Unsubscribe(Test));
                    bus5.Broadcast(defaultParameter, defaultParameter, defaultParameter, defaultParameter, defaultParameter);
                    break;
            }

            Assert.IsTrue(m_HandleCount == handlerCount - 1);
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
    }
}