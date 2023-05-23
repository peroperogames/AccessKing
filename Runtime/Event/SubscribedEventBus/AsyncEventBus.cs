using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using PeroTools2.Asynchronization;

namespace PeroTools2.AccessKing
{
    public sealed class AsyncEventBus : IEventBus, IWeakEventObserverSubscriable<IEventObserver>, IAsyncNonNotificationEventBus, IAsyncNotificationEventBus
    {
        private readonly List<object> m_Observers = new List<object>();
        private readonly object m_Locker = new object();

        bool IAsyncNotificationEventBus.Unsubscribe<TNotification>(IAsyncEventHandler<TNotification> eventHandler) => Unsubscribe(eventHandler);
        void IAsyncNotificationEventBus.Subscribe<TNotification>(IAsyncEventHandler<TNotification> eventHandler) => Subscribe(eventHandler);
        bool IAsyncNonNotificationEventBus.Unsubscribe(IAsyncEventHandler eventHandler) => Unsubscribe(eventHandler);
        void IAsyncNonNotificationEventBus.Subscribe(IAsyncEventHandler eventHandler) => Subscribe(eventHandler);
        void IAccessBus.Dispatch(INotification notification) => ((IEventBus) this).Publish(in notification);
        bool IEventBus.Unsubscribe<TEventObserver>(TEventObserver eventObserver) => Unsubscribe(eventObserver);
        void IEventBus.Subscribe<TEventObserver>(TEventObserver eventObserver) => Subscribe(eventObserver);
        void IEventBus.Publish<TNotification>(in TNotification notification)
        {
            if (notification == null || notification is ParameterNotification)
            {
                PublishAsync().Wait();
            }
            else
            {
                lock (m_Locker)
                {
                    var parameters = new object[1];
                    for (var index = m_Observers.Count - 1; index >= 0; index--)
                    {
                        var observer = m_Observers[index];
                        if (observer is WeakReference weakHandler)
                        {
                            if (weakHandler.IsAlive)
                                observer = weakHandler.Target;
                            else
                            {
                                m_Observers.RemoveAt(index);
                                continue;
                            }
                        }

                        foreach (var iEventHandler in observer.GetType().GetInterfaces())
                        {
                            var interfaceName = Regex.Replace(iEventHandler.Name, @"/[.*/]", "TNotification");
                            var notificationType = iEventHandler.GenericTypeArguments[0];
                            parameters[0] = notification;
                            if (interfaceName.Equals(typeof(IEventHandler<>).Name))
                            {
                                EventHelper.RequireEventHandlerHandleMethod(iEventHandler, notificationType).Invoke(observer, parameters);
                                break;
                            }

                            if (interfaceName.Equals(typeof(IAsyncEventHandler<>).Name))
                            {
                                EventHelper.RequireAsyncEventHandlerHandleMethod(iEventHandler, notificationType).Invoke(observer, parameters);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void Clear()
        {
            lock (m_Locker)
            {
                m_Observers.Clear();
            }
        }

        public bool Unsubscribe(IEventObserver observer)
        {
            var isRemoved = false;
            lock (m_Locker)
            {
                for (var index = m_Observers.Count - 1; index >= 0; index--)
                {
                    var target = m_Observers[index];
                    if (target is WeakReference weakHandler && !weakHandler.IsAlive)
                    {
                        if (!weakHandler.IsAlive)
                            m_Observers.RemoveAt(index);
                        else
                            target = weakHandler.Target;
                    }

                    if (target == observer)
                    {
                        m_Observers.RemoveAt(index);
                        isRemoved = true;
                    }
                }
            }

            return isRemoved;
        }

        public void Subscribe(IEventObserver eventObserver)
        {
            lock (m_Locker)
            {
                m_Observers.Add(eventObserver);
            }
        }

        public void SubscribeWeakly(IEventObserver observer)
        {
            lock (m_Locker)
            {
                m_Observers.Add(new WeakReference(observer));
            }
        }

        /// <summary>
        /// Publish event with notifications asynchronously.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// Thrown when the event observer does not belong to the following type:
        /// <list type="IEventHandler">
        /// <item>IEventHandler&lt;TNotification&gt;</item>
        /// </list>
        /// </exception>
        public async Task PublishAsync<TNotification>(TNotification notification) where TNotification : INotification
        {
            await ThreadSwitcher.SwitchToRandomThread();
            long finishedCount = 0;
            Exception exception = null;
            var lockSlim = new ReaderWriterLockSlim();
            var removeList = ObjectPool<List<int>>.Require();
            lock (m_Locker)
            {
                var count = m_Observers.Count;

                //Process all observers
                Parallel.For(0, count, async (index, _) =>
                {
                    try
                    {
                        var observer = m_Observers[index];
                        if (observer is WeakReference weakHandler)
                        {
                            observer = weakHandler.IsAlive ? weakHandler.Target : null;
                        }

                        if (observer != null)
                        {
                            switch (observer)
                            {
                                case IAsyncEventHandler<TNotification> eventHandler:
                                    await eventHandler.HandleAsync(notification);
                                    break;
                                case IEventHandler<TNotification> eventHandler:
                                    eventHandler.Handle(notification);
                                    break;
                                default:
                                    throw new NotSupportedException($"Unknown event observer type: {observer.GetType()} .");
                            }
                        }

                        lockSlim.EnterWriteLock();
                        if (observer == null)
                            removeList.Add(index);
                        finishedCount++;
                        lockSlim.ExitWriteLock();
                    }
                    catch (Exception e)
                    {
                        lockSlim.EnterWriteLock();
                        exception = e;
                        lockSlim.ExitWriteLock();
                    }
                });
                //Spin for all handler finish
                WaitUntilFinished(ref finishedCount, count, ref exception, lockSlim, removeList);
            }

            lockSlim.Dispose();
            removeList.Clear();
            ObjectPool<List<int>>.Recycle(removeList);
            if (exception != null) throw exception;
        }

        /// <summary>
        /// Publish event with notifications asynchronously.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// Thrown when the event observer does not belong to the following type:
        /// <list type="IEventHandler">
        /// <item>IEventHandler&lt;TNotification&gt;</item>
        /// </list>
        /// </exception>
        public async Task PublishAsync()
        {
            await ThreadSwitcher.SwitchToRandomThread();
            long finishedCount = 0;
            Exception exception = null;
            var lockSlim = new ReaderWriterLockSlim();
            var removeList = ObjectPool<List<int>>.Require();

            lock (m_Locker)
            {
                var count = m_Observers.Count;

                //Process all observers
                Parallel.For(0, count, async (index, _) =>
                {
                    try
                    {
                        var observer = m_Observers[index];
                        if (observer is WeakReference weakHandler)
                        {
                            observer = weakHandler.IsAlive ? weakHandler.Target : null;
                        }

                        switch (observer)
                        {
                            case IAsyncEventHandler<ParameterNotification> eventHandler:
                                await eventHandler.HandleAsync(ParameterNotification.Empty);
                                break;
                            case IAsyncEventHandler eventHandler:
                                await eventHandler.HandleAsync();
                                break;
                            case IEventHandler<ParameterNotification> eventHandler:
                                eventHandler.Handle(ParameterNotification.Empty);
                                break;
                            case IEventHandler eventHandler:
                                eventHandler.Handle();
                                break;
                            default:
                                throw new NotSupportedException($"Unknown event observer type: {observer.GetType()} .");
                        }

                        lockSlim.EnterWriteLock();
                        if (observer == null)
                            removeList.Add(index);
                        finishedCount++;
                        lockSlim.ExitWriteLock();
                    }
                    catch (Exception e)
                    {
                        lockSlim.EnterWriteLock();
                        exception = e;
                        lockSlim.ExitWriteLock();
                    }
                });

                //Spin for all handler finish
                WaitUntilFinished(ref finishedCount, count, ref exception, lockSlim, removeList);
            }

            lockSlim.Dispose();
            removeList.Clear();
            ObjectPool<List<int>>.Recycle(removeList);
            if (exception != null) throw exception;
        }

        private void WaitUntilFinished(ref long finishedCount, long totalCount, ref Exception exception, ReaderWriterLockSlim lockSlim, IReadOnlyList<int> removeList)
        {
            while (true)
            {
                lockSlim.EnterReadLock();
                if (finishedCount >= totalCount || exception != null)
                {
                    lockSlim.ExitReadLock();
                    break;
                }

                lockSlim.ExitReadLock();
            }

            for (var i = 0; i < removeList.Count; i++)
            {
                m_Observers.RemoveAt(removeList[i]);
            }
        }
    }
}