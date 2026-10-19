/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2026/10/12 16:10:00
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;

namespace PeroTools2.AccessKing.Editor.Tests
{
    /// <summary>
    /// Regressions for the defects that the original suite could not discriminate.
    /// </summary>
    public sealed class AccessKingRegressionTests
    {
        #region Event bus

        /// <summary>
        /// Unsubscribing a weak handler must remove that handler and must not remove its neighbours.
        /// </summary>
        [Test]
        public void WeakUnsubscribeRemovesOnlyTheTargetHandlerTest()
        {
            var bus = new EventBus<Empty>();
            var owner = ScriptableObject.CreateInstance<TestOwner>();
            var target = new WeakActionEventHandler(owner.Target, owner);
            var bystander = new WeakActionEventHandler(owner.Bystander, owner);
            ((IWeakEventSubscriable<Empty>) bus).SubscribeWeakly(target);
            ((IWeakEventSubscriable<Empty>) bus).SubscribeWeakly(bystander);

            Assert.IsTrue(bus.Unsubscribe(target));

            bus.Broadcast();
            Assert.AreEqual(0, owner.targetCount);
            Assert.AreEqual(1, owner.bystanderCount);

            UnityEngine.Object.DestroyImmediate(owner);
        }

        /// <summary>
        /// The delegate based overload must be able to locate a weak subscription of the same method.
        /// </summary>
        [Test]
        public void WeakUnsubscribeByDelegateRemovesTheHandlerTest()
        {
            var bus = new EventBus<Empty>();
            var owner = ScriptableObject.CreateInstance<TestOwner>();
            bus.SubscribeWeakly(owner, owner.Target);

            Assert.IsTrue(bus.Unsubscribe(owner.Target));

            bus.Broadcast();
            Assert.AreEqual(0, owner.targetCount);

            UnityEngine.Object.DestroyImmediate(owner);
        }

        /// <summary>
        /// The equality of a weak handler identifies the owner as well, so two providers that invoke the
        /// same method are not equal.
        /// </summary>
        [Test]
        public void WeakHandlerEqualityIncludesTheOwnerTest()
        {
            var first = ScriptableObject.CreateInstance<TestOwner>();
            var second = ScriptableObject.CreateInstance<TestOwner>();
            var fromFirst = new WeakActionEventHandler(first.Target, first);
            var sameFirst = new WeakActionEventHandler(first.Target, first);
            var fromSecond = new WeakActionEventHandler(second.Target, second);

            Assert.IsTrue(fromFirst.Equals(sameFirst));
            Assert.IsTrue(fromFirst == sameFirst);
            Assert.IsFalse(fromFirst.Equals(fromSecond));
            Assert.IsFalse(fromFirst == fromSecond);

            // A weakly referenced handler and a strongly typed handler that wraps the same invocation are
            // equal in both directions, so either one can be used to unsubscribe.
            var strongFirst = new ActionEventHandler(first.Target);
            Assert.IsTrue(fromFirst.Equals(strongFirst));
            Assert.IsTrue(strongFirst.Equals(fromFirst));

            UnityEngine.Object.DestroyImmediate(first);
            UnityEngine.Object.DestroyImmediate(second);
        }

        /// <summary>
        /// The hash code must agree with the equality, otherwise sets and dictionaries misbehave.
        /// </summary>
        [Test]
        public void WeakHandlerHashAgreesWithEqualityTest()
        {
            var first = ScriptableObject.CreateInstance<TestOwner>();
            var second = ScriptableObject.CreateInstance<TestOwner>();
            var fromFirst = new WeakActionEventHandler(first.Target, first);
            var sameFirst = new WeakActionEventHandler(first.Target, first);
            var fromSecond = new WeakActionEventHandler(second.Target, second);

            Assert.AreEqual(fromFirst.GetHashCode(), sameFirst.GetHashCode());
            Assert.AreEqual(1, new HashSet<WeakActionEventHandler> { fromFirst, sameFirst }.Count);
            Assert.AreEqual(2, new HashSet<WeakActionEventHandler> { fromFirst, fromSecond }.Count);

            UnityEngine.Object.DestroyImmediate(first);
            UnityEngine.Object.DestroyImmediate(second);
        }

        /// <summary>
        /// Subscribing a null handler is a programming error and has to fail at the call site.
        /// </summary>
        [Test]
        public void SubscribingNullThrowsTest()
        {
            var bus = new EventBus<Empty>();

            Assert.Throws<ArgumentNullException>(() => bus.Subscribe((IEventHandler<Empty>) null));
            Assert.Throws<ArgumentNullException>(() => ((IWeakEventSubscriable<Empty>) bus).SubscribeWeakly(null));
        }

        /// <summary>
        /// A static delegation has no owner to keep alive, so a weak subscription is rejected when it is created.
        /// </summary>
        [Test]
        public void StaticDelegationIsRejectedTest()
        {
            var owner = ScriptableObject.CreateInstance<TestOwner>();

            Assert.Throws<ArgumentException>(() => new WeakActionEventHandler(StaticTarget, owner));

            UnityEngine.Object.DestroyImmediate(owner);
        }

        private static void StaticTarget() { }

        /// <summary>
        /// Two owners that subscribe the same method must be unsubscribed independently.
        /// </summary>
        [Test]
        public void WeakUnsubscribeTargetsTheOwnerTest()
        {
            var bus = new EventBus<Empty>();
            var first = ScriptableObject.CreateInstance<TestOwner>();
            var second = ScriptableObject.CreateInstance<TestOwner>();
            bus.SubscribeWeakly(first, first.Target);
            bus.SubscribeWeakly(second, second.Target);

            Assert.IsTrue(bus.Unsubscribe(first.Target));

            bus.Broadcast();
            Assert.AreEqual(0, first.targetCount);
            Assert.AreEqual(1, second.targetCount);

            UnityEngine.Object.DestroyImmediate(first);
            UnityEngine.Object.DestroyImmediate(second);
        }

        /// <summary>
        /// The handler instance overload must also match the owner, not only the invoked method.
        /// </summary>
        [Test]
        public void WeakUnsubscribeByHandlerTargetsTheOwnerTest()
        {
            var bus = new EventBus<Empty>();
            var first = ScriptableObject.CreateInstance<TestOwner>();
            var second = ScriptableObject.CreateInstance<TestOwner>();
            var firstHandler = new WeakActionEventHandler(first.Target, first);
            var secondHandler = new WeakActionEventHandler(second.Target, second);
            ((IWeakEventSubscriable<Empty>) bus).SubscribeWeakly(firstHandler);
            ((IWeakEventSubscriable<Empty>) bus).SubscribeWeakly(secondHandler);

            Assert.IsTrue(bus.Unsubscribe(firstHandler));

            bus.Broadcast();
            Assert.AreEqual(0, first.targetCount);
            Assert.AreEqual(1, second.targetCount);

            UnityEngine.Object.DestroyImmediate(first);
            UnityEngine.Object.DestroyImmediate(second);
        }

        /// <summary>
        /// Subscribing an equal delegate twice keeps both subscriptions, the same way a C# event does,
        /// and a single unsubscribe only removes one of them.
        /// </summary>
        [Test]
        public void DuplicateSubscriptionsBothFireTest()
        {
            var bus = new EventBus<Empty>();
            var count = 0;
            Action action = () => count++;
            bus.Subscribe(action);
            bus.Subscribe(action);

            bus.Broadcast();
            Assert.AreEqual(2, count);

            Assert.IsTrue(bus.Unsubscribe(action));
            bus.Broadcast();
            Assert.AreEqual(3, count);
        }

        /// <summary>
        /// Comparing a handler with null must not throw, and a live handler must never look equal to null.
        /// The operator intentionally keeps the <c>Equals</c> based null check, so that a destroyed
        /// <see cref="UnityEngine.Object"/> based provider is never treated as an equal handler.
        /// </summary>
        [Test]
        public void HandlerEqualityWithNullTest()
        {
            var owner = ScriptableObject.CreateInstance<TestOwner>();
            var strongHandler = new ActionEventHandler(owner.Target);
            var weakHandler = new WeakActionEventHandler(owner.Target, owner);

            Assert.IsFalse(strongHandler == null);
            Assert.IsTrue(strongHandler != null);
            Assert.IsFalse(strongHandler.Equals((ActionEventHandler) null));

            Assert.IsFalse(weakHandler == null);
            Assert.IsTrue(weakHandler != null);
            Assert.IsFalse(weakHandler.Equals((WeakActionEventHandler) null));

            UnityEngine.Object.DestroyImmediate(owner);
        }

        #endregion

        #region Command bus

        /// <summary>
        /// WhenAnyDone must not fail while renting the task collection.
        /// </summary>
        [Test]
        public async Task WhenAnyDoneWithAsyncHandlerTest()
        {
            var factory = new RegistryCommandHandlerFactory();
            var bus = new CommandBus<Empty>(factory);
            factory.RegisterHandler(new AsyncCommandHandler());

            await bus.Execute().WhenAnyDone();
        }

        /// <summary>
        /// Consuming the result of an operation twice must fail loudly instead of corrupting the shared pool.
        /// </summary>
        [Test]
        public void ConsumingOperationResultsTwiceThrowsTest()
        {
            var factory = new RegistryCommandHandlerFactory();
            var bus = new CommandBus<Empty>(factory);
            factory.RegisterHandler(new ResultCommandHandler());

            var operation = bus.Execute();
            Assert.AreEqual(1, operation.GetResults<string>().Count);
            Assert.Throws<InvalidOperationException>(() => operation.GetResults<string>());
        }

        /// <summary>
        /// A disposed operation releases its collection once and refuses to be read afterwards.
        /// </summary>
        [Test]
        public void DisposedOperationIsNotReadableTest()
        {
            var factory = new RegistryCommandHandlerFactory();
            var bus = new CommandBus<Empty>(factory);
            factory.RegisterHandler<Empty>(new ResultCommandHandler());

            var operation = bus.Execute();
            Assert.AreEqual(1, operation.GetResults<string>(false).Count);

            operation.Dispose();
            operation.Dispose();

            Assert.Throws<InvalidOperationException>(() => operation.GetResults<string>(false));
        }

        /// <summary>
        /// A copy of the operation made before it was consumed must not be able to read or release the
        /// collection again, the collection is pooled and already belongs to someone else.
        /// </summary>
        [Test]
        public void StaleOperationCopyCannotConsumeTest()
        {
            var factory = new RegistryCommandHandlerFactory();
            var bus = new CommandBus<Empty>(factory);
            factory.RegisterHandler<Empty>(new ResultCommandHandler());

            var operation = bus.Execute();
            var stale = operation;

            Assert.AreEqual(1, operation.GetResults<string>().Count);
            Assert.Throws<InvalidOperationException>(() => stale.GetResults<string>());
            stale.Dispose();
        }

        /// <summary>
        /// A handler must be dispatched exactly once even when the command bus holds several factories.
        /// </summary>
        [Test]
        public void EveryHandlerDispatchesOnceWithMultipleFactoriesTest()
        {
            var firstFactory = new RegistryCommandHandlerFactory();
            var secondFactory = new SecondRegistryCommandHandlerFactory();
            firstFactory.RegisterHandler(new CountingCommandHandler());
            secondFactory.RegisterHandler(new CountingCommandHandler());
            var bus = new CommandBus<Empty>(firstFactory, secondFactory);

            bus.Execute();

            Assert.AreEqual(2, CountingCommandHandler.totalCount);
        }

        /// <summary>
        /// Clearing the factory must reset the observable handler count as well.
        /// </summary>
        [Test]
        public void ClearHandlersResetsHandlerCountTest()
        {
            var factory = new RegistryCommandHandlerFactory();
            factory.RegisterHandler(new ResultCommandHandler());
            factory.RegisterHandler(new ResultCommandHandler());
            Assert.AreEqual(2, factory.handlerCount);

            factory.ClearHandlers();

            Assert.AreEqual(0, factory.handlerCount);
        }

        #endregion

        #region Schedules

        /// <summary>
        /// Looking up an existing theme with a mismatched notification type must report a miss, not throw.
        /// </summary>
        [Test]
        public void EventScheduleTryGetBusWithWrongNotificationTypeTest()
        {
            var schedule = new EventSchedule<string>();
            schedule.AddBus("theme", new EventBus<RegressionNotification>());

            Assert.IsTrue(schedule.TryGetBus<RegressionNotification>("theme", out _));
            Assert.IsFalse(schedule.TryGetBus<OtherRegressionNotification>("theme", out _));
        }

        /// <summary>
        /// Removing a bus that is not in the schedule must report a miss, not throw.
        /// </summary>
        [Test]
        public void RemoveUnknownBusReturnsFalseTest()
        {
            var eventSchedule = new EventSchedule<string>();
            eventSchedule.AddBus("theme", new EventBus<RegressionNotification>());
            Assert.IsFalse(((IAccessSchedule<string>) eventSchedule).RemoveBus(new EventBus<RegressionNotification>()));
            Assert.IsTrue(eventSchedule.ContainsBus("theme"));

            var commandSchedule = new CommandSchedule<string>();
            commandSchedule.AddBus("theme", new CommandBus<RegressionNotification>());
            Assert.IsFalse(((IAccessSchedule<string>) commandSchedule).RemoveBus(new CommandBus<RegressionNotification>()));
            Assert.IsTrue(commandSchedule.ContainsBus("theme"));
        }

        #endregion

        #region Test doubles

        private sealed class TestOwner : ScriptableObject
        {
            public int targetCount;
            public int bystanderCount;

            public void Target() => targetCount++;

            public void Bystander() => bystanderCount++;
        }

        private struct RegressionNotification : INotification { }

        private struct OtherRegressionNotification : INotification { }

        private sealed class AsyncCommandHandler : IAsyncCommandHandler<Empty>
        {
            public void Handle(ref Empty notification) { }

            public UniTask GetResult() => UniTask.CompletedTask;

            object IResultAvailable.GetResult() => UniTask.CompletedTask;
        }

        private sealed class ResultCommandHandler : ICommandHandler<Empty, string>
        {
            public void Handle(ref Empty notification) { }

            public string GetResult() => nameof(ResultCommandHandler);

            object IResultAvailable.GetResult() => GetResult();
        }

        private sealed class CountingCommandHandler : ICommandHandler<Empty>
        {
            public static int totalCount;

            public void Handle(ref Empty notification) => totalCount++;
        }

        /// <summary>
        /// A second factory type, because a command bus keys its factories by type.
        /// </summary>
        private sealed class SecondRegistryCommandHandlerFactory : ICommandHandlerFactory
        {
            private readonly RegistryCommandHandlerFactory m_Inner = new();

            public void RegisterHandler<TNotification>(ICommandHandler<TNotification> handler) where TNotification : INotification
                => m_Inner.RegisterHandler(handler);

            public IEnumerable<ICommandHandler<TNotification>> GetHandlers<TNotification>() where TNotification : INotification
                => m_Inner.GetHandlers<TNotification>();

            public void GetHandlers<TNotification>(IList<ICommandHandler<TNotification>> collection) where TNotification : INotification
                => m_Inner.GetHandlers(collection);
        }

        #endregion

        [SetUp]
        public void SetUp() => CountingCommandHandler.totalCount = 0;
    }
}
