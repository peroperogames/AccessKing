using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PeroTools2.AccessKing
{
    public sealed class AsyncEventBus : IWeakEventObserverSubscriable<IEventObserver>, IEventBus
    {
        private readonly List<object> m_Observers = new List<object>();
        private readonly object m_Locker = new object();

        void IAccessBus.Dispatch(INotification notification) => ((IEventBus) this).Publish(notification);
        public void Publish<TNotification>(in TNotification notification) where TNotification : INotification => Publish(notification);


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
        private void Publish<TNotification>(TNotification notification) where TNotification : INotification
        {
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
        public void Publish()
        {
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
                            observer = weakHandler.IsAlive ? weakHandler.Target : null;

                        if (observer is IEventHandler eventHandler)
                            eventHandler.Handle();
                        else
                            throw new NotSupportedException($"Unknown event observer type: {observer.GetType()} .");

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