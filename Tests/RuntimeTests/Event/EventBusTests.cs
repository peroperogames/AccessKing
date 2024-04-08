/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: shuaishuai
 * Created On: 2024/04/08
 * Description:
 */

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace PeroTools2.AccessKing.Tests
{
    [TestFixture(typeof(TestMonoHandler))]
    [TestFixture(typeof(TestSoHandler))]
    internal sealed class EventBusTests<TObject> where TObject : Object, IEventHandler<TestNotification>
    {
        [UnityTest]
        public IEnumerator EventBusSubscribeWeaklyTest()
        {
            var handler = CreateHandler();
            var eventBus = new EventBus<TestNotification>();
            eventBus.SubscribeWeakly(handler);
            DestroyHandler(handler);
            yield return null;
            Assert.IsTrue(handler == null);
            var notification = new TestNotification();
            eventBus.Broadcast(notification);
            Assert.IsTrue(notification.isSucceed == false);
        }

        private static TObject CreateHandler()
        {
            if (typeof(TObject).IsSubclassOf(typeof(MonoBehaviour)))
            {
                return new GameObject().AddComponent(typeof(TObject)) as TObject;
            }
            if (typeof(TObject).IsSubclassOf(typeof(ScriptableObject)))
            {
                return ScriptableObject.CreateInstance(typeof(TObject)) as TObject;
            }
            return default;
        }

        private static void DestroyHandler(TObject eventHandler) => Object.Destroy(eventHandler);
    }

    internal sealed class TestMonoHandler : MonoBehaviour, IEventHandler<TestNotification>
    {
        void IEventHandler<TestNotification>.Handle(in TestNotification notification)
        {
            notification.isSucceed = true;
        }
    }

    internal sealed class TestSoHandler : ScriptableObject, IEventHandler<TestNotification>
    {
        public void Handle(in TestNotification notification)
        {
            notification.isSucceed = true;
        }
    }

    internal sealed class TestNotification : INotification
    {
        public bool isSucceed { get; set; }
    }
}