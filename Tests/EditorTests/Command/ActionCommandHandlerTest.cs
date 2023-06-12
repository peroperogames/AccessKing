using System;
using NUnit.Framework;

namespace PeroTools2.AccessKing.Editor.Tests.CommandTests
{
    public class ActionCommandHandlerTest
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
            }

            Assert.IsTrue(m_IsInvoke);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
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
            }
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void CommandBusExecuteWithActionHandlerTest(int argumentCount)
        {
            var factory = new RegistryCommandHandlerFactory();
            object defaultParameter = null;
            switch (argumentCount)
            {
                case 0:
                    var bus0 = new CommandBus<Empty>(factory);
                    factory.RegisterActionHandler(Test);
                    bus0.Execute();
                    break;
                case 1:
                    var bus1 = new CommandBus<ParameterNotification<object>>(factory);
                    factory.RegisterActionHandler<object>(Test);
                    bus1.Execute(defaultParameter);
                    break;
                case 2:
                    var bus2 = new CommandBus<ParameterNotification<object, object>>(factory);
                    factory.RegisterActionHandler<object,object>(Test);
                    bus2.Execute(defaultParameter, defaultParameter);
                    break;
                case 3:
                    var bus3 = new CommandBus<ParameterNotification<object, object, object>>(factory);
                    factory.RegisterActionHandler<object,object,object>(Test);
                    bus3.Execute(defaultParameter, defaultParameter, defaultParameter);
                    break;
                case 4:
                    var bus4 = new CommandBus<ParameterNotification<object, object, object, object>>(factory);
                    factory.RegisterActionHandler<object,object,object,object>(Test);
                    bus4.Execute(defaultParameter, defaultParameter, defaultParameter, defaultParameter);
                    break;
                case 5:
                    var bus5 = new CommandBus<ParameterNotification<object, object, object, object, object>>(factory);
                    factory.RegisterActionHandler<object,object,object,object,object>(Test);
                    bus5.Execute(defaultParameter, defaultParameter, defaultParameter, defaultParameter, defaultParameter);
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
        public void HandlerFactoryUnregisterWithActionHandlerTest(int argumentCount)
        {
            const int handlerCount = 5;
            object defaultParameter = null;
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
                    bus1.Execute(defaultParameter);
                    break;
                case 2:
                    var bus2 = new CommandBus<ParameterNotification<object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object>(Test);
                    }

                    Assert.IsTrue(factory.UnregisterActionHandler<object, object>(Test));
                    bus2.Execute(defaultParameter, defaultParameter);
                    break;
                case 3:
                    var bus3 = new CommandBus<ParameterNotification<object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object>(Test);
                    }

                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object>(Test));
                    bus3.Execute(defaultParameter, defaultParameter, defaultParameter);
                    break;
                case 4:
                    var bus4 = new CommandBus<ParameterNotification<object, object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object, object>(Test);
                    }

                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object, object>(Test));
                    bus4.Execute(defaultParameter, defaultParameter, defaultParameter, defaultParameter);
                    break;
                case 5:
                    var bus5 = new CommandBus<ParameterNotification<object, object, object, object, object>>(factory);
                    for (var i = 0; i < handlerCount; i++)
                    {
                        factory.RegisterActionHandler<object, object, object, object, object>(Test);
                    }

                    Assert.IsTrue(factory.UnregisterActionHandler<object, object, object, object, object>(Test));
                    bus5.Execute(defaultParameter, defaultParameter, defaultParameter, defaultParameter, defaultParameter);
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