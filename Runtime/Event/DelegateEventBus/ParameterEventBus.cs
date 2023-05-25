using System;

namespace PeroTools2.AccessKing
{
    public abstract class ParameterEventBus<TEventHandler> : IEventBus, IEventBus<TEventHandler, INotification> where TEventHandler : IEventHandler
    {
        public abstract void Publish();
        public abstract void Clear();
        protected abstract bool Unsubscribe(TEventHandler observer);
        protected abstract void Subscribe(TEventHandler handler);
        void IAccessBus.Dispatch(INotification notification) => ((IEventBus) this).Publish(in notification);
        bool IEventBus<TEventHandler, INotification>.Unsubscribe(TEventHandler observer) => Unsubscribe(observer);
        void IEventBus<TEventHandler, INotification>.Subscribe(TEventHandler handler) => Unsubscribe(handler);
        void IEventBus<TEventHandler, INotification>.Publish(in INotification notification) => Publish();
        void IEventBus.Publish<TNotification>(in TNotification notification) => Publish();

        bool IEventBus.Unsubscribe(IEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                return Unsubscribe(eventHandler);
            }

            return false;
        }

        void IEventBus.Subscribe(IEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                Subscribe(eventHandler);
                return;
            }

            throw new InvalidCastException($"Type {eventObserver.GetType()} is not {typeof(TEventHandler)}");
        }
    }

    public abstract class ParameterEventBus<TEventHandler, T> : IEventBus, IEventBus<TEventHandler, ParameterNotification<T>> where TEventHandler : IEventHandler<ParameterNotification<T>>
    {
        public abstract void Publish(T param);
        public abstract void Clear();
        protected abstract bool Unsubscribe(TEventHandler observer);
        protected abstract void Subscribe(TEventHandler handler);
        void IAccessBus.Dispatch(INotification notification) => ((IEventBus) this).Publish(in notification);
        bool IEventBus<TEventHandler, ParameterNotification<T>>.Unsubscribe(TEventHandler observer) => Unsubscribe(observer);
        void IEventBus<TEventHandler, ParameterNotification<T>>.Subscribe(TEventHandler handler) => Unsubscribe(handler);
        void IEventBus<TEventHandler, ParameterNotification<T>>.Publish(in ParameterNotification<T> notification) => Publish(notification.item);
        void IEventBus.Publish() => throw new InvalidOperationException();
        bool IEventBus.Unsubscribe(IEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                return Unsubscribe(eventHandler);
            }

            return false;
        }

        void IEventBus.Subscribe(IEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                Subscribe(eventHandler);
                return;
            }

            throw new InvalidCastException($"Type {eventObserver.GetType()} is not {typeof(TEventHandler)}");
        }

        void IEventBus.Publish<TNotification>(in TNotification notification)
        {
            if (notification is ParameterNotification<T> parameters)
            {
                Publish(parameters.item);
                return;
            }

            throw new InvalidCastException($"Type {notification.GetType()} is not {typeof(ParameterNotification<T>)}");
        }
    }

    public abstract class ParameterEventBus<TEventHandler, T1, T2> : IEventBus, IEventBus<TEventHandler, ParameterNotification<T1, T2>> where TEventHandler : IEventHandler<ParameterNotification<T1, T2>>
    {
        public abstract void Publish(T1 param1, T2 param2);
        public abstract void Clear();
        protected abstract bool Unsubscribe(TEventHandler observer);
        protected abstract void Subscribe(TEventHandler handler);
        void IAccessBus.Dispatch(INotification notification) => ((IEventBus) this).Publish(in notification);
        bool IEventBus<TEventHandler, ParameterNotification<T1, T2>>.Unsubscribe(TEventHandler observer) => Unsubscribe(observer);
        void IEventBus<TEventHandler, ParameterNotification<T1, T2>>.Subscribe(TEventHandler handler) => Unsubscribe(handler);
        void IEventBus<TEventHandler, ParameterNotification<T1, T2>>.Publish(in ParameterNotification<T1, T2> notification) => Publish(notification.item1, notification.item2);
        void IEventBus.Publish() => throw new InvalidOperationException();

        bool IEventBus.Unsubscribe(IEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                return Unsubscribe(eventHandler);
            }

            return false;
        }

        void IEventBus.Subscribe(IEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                Subscribe(eventHandler);
                return;
            }

            throw new InvalidCastException($"Type {eventObserver.GetType()} is not {typeof(TEventHandler)}");
        }

        void IEventBus.Publish<TNotification>(in TNotification notification)
        {
            if (notification is ParameterNotification<T1, T2> parameters)
            {
                Publish(parameters.item1, parameters.item2);
                return;
            }

            throw new InvalidCastException($"Type {notification.GetType()} is not {typeof(ParameterNotification<T1, T2>)}");
        }
    }

    public abstract class ParameterEventBus<TEventHandler, T1, T2, T3> : IEventBus, IEventBus<TEventHandler, ParameterNotification<T1, T2, T3>> where TEventHandler : IEventHandler<ParameterNotification<T1, T2, T3>>
    {
        public abstract void Publish(T1 param1, T2 param2, T3 param3);
        public abstract void Clear();
        protected abstract bool Unsubscribe(TEventHandler observer);
        protected abstract void Subscribe(TEventHandler handler);
        void IAccessBus.Dispatch(INotification notification) => ((IEventBus) this).Publish(in notification);
        bool IEventBus<TEventHandler, ParameterNotification<T1, T2, T3>>.Unsubscribe(TEventHandler observer) => Unsubscribe(observer);
        void IEventBus<TEventHandler, ParameterNotification<T1, T2, T3>>.Subscribe(TEventHandler handler) => Unsubscribe(handler);
        void IEventBus<TEventHandler, ParameterNotification<T1, T2, T3>>.Publish(in ParameterNotification<T1, T2, T3> notification) => Publish(notification.item1, notification.item2, notification.item3);
        void IEventBus.Publish() => throw new InvalidOperationException();

        bool IEventBus.Unsubscribe(IEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                return Unsubscribe(eventHandler);
            }

            return false;
        }

        void IEventBus.Subscribe(IEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                Subscribe(eventHandler);
                return;
            }

            throw new InvalidCastException($"Type {eventObserver.GetType()} is not {typeof(TEventHandler)}");
        }

        void IEventBus.Publish<TNotification>(in TNotification notification)
        {
            if (notification is ParameterNotification<T1, T2, T3> parameters)
            {
                Publish(parameters.item1, parameters.item2, parameters.item3);
                return;
            }

            throw new InvalidCastException($"Type {notification.GetType()} is not {typeof(ParameterNotification<T1, T2, T3>)}");
        }
    }

    public abstract class ParameterEventBus<TEventHandler, T1, T2, T3, T4> : IEventBus, IEventBus<TEventHandler, ParameterNotification<T1, T2, T3, T4>> where TEventHandler : IEventHandler<ParameterNotification<T1, T2, T3, T4>>
    {
        public abstract void Publish(T1 param1, T2 param2, T3 param3, T4 param4);
        public abstract void Clear();
        protected abstract bool Unsubscribe(TEventHandler observer);
        protected abstract void Subscribe(TEventHandler handler);
        void IAccessBus.Dispatch(INotification notification) => ((IEventBus) this).Publish(in notification);
        bool IEventBus<TEventHandler, ParameterNotification<T1, T2, T3, T4>>.Unsubscribe(TEventHandler observer) => Unsubscribe(observer);
        void IEventBus<TEventHandler, ParameterNotification<T1, T2, T3, T4>>.Subscribe(TEventHandler handler) => Unsubscribe(handler);
        void IEventBus<TEventHandler, ParameterNotification<T1, T2, T3, T4>>.Publish(in ParameterNotification<T1, T2, T3, T4> notification) => Publish(notification.item1, notification.item2, notification.item3, notification.item4);
        void IEventBus.Publish() => throw new InvalidOperationException();

        bool IEventBus.Unsubscribe(IEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                return Unsubscribe(eventHandler);
            }

            return false;
        }

        void IEventBus.Subscribe(IEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                Subscribe(eventHandler);
                return;
            }

            throw new InvalidCastException($"Type {eventObserver.GetType()} is not {typeof(TEventHandler)}");
        }

        void IEventBus.Publish<TNotification>(in TNotification notification)
        {
            if (notification is ParameterNotification<T1, T2, T3, T4> parameters)
            {
                Publish(parameters.item1, parameters.item2, parameters.item3, parameters.item4);
                return;
            }

            throw new InvalidCastException($"Type {notification.GetType()} is not {typeof(ParameterNotification<T1, T2, T3, T4>)}");
        }
    }

    public abstract class ParameterEventBus<TEventHandler, T1, T2, T3, T4, T5> : IEventBus, IEventBus<TEventHandler, ParameterNotification<T1, T2, T3, T4, T5>> where TEventHandler : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5>>
    {
        public abstract void Publish(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5);
        public abstract void Clear();
        protected abstract bool Unsubscribe(TEventHandler observer);
        protected abstract void Subscribe(TEventHandler handler);
        void IAccessBus.Dispatch(INotification notification) => ((IEventBus) this).Publish(in notification);
        bool IEventBus<TEventHandler, ParameterNotification<T1, T2, T3, T4, T5>>.Unsubscribe(TEventHandler observer) => Unsubscribe(observer);
        void IEventBus<TEventHandler, ParameterNotification<T1, T2, T3, T4, T5>>.Subscribe(TEventHandler handler) => Unsubscribe(handler);
        void IEventBus<TEventHandler, ParameterNotification<T1, T2, T3, T4, T5>>.Publish(in ParameterNotification<T1, T2, T3, T4, T5> notification) => Publish(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5);
        void IEventBus.Publish() => throw new InvalidOperationException();

        bool IEventBus.Unsubscribe(IEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                return Unsubscribe(eventHandler);
            }

            return false;
        }

        void IEventBus.Subscribe(IEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                Subscribe(eventHandler);
                return;
            }

            throw new InvalidCastException($"Type {eventObserver.GetType()} is not {typeof(TEventHandler)}");
        }

        void IEventBus.Publish<TNotification>(in TNotification notification)
        {
            if (notification is ParameterNotification<T1, T2, T3, T4, T5> parameters)
            {
                Publish(parameters.item1, parameters.item2, parameters.item3, parameters.item4, parameters.item5);
                return;
            }

            throw new InvalidCastException($"Type {notification.GetType()} is not {typeof(ParameterNotification<T1, T2, T3, T4, T5>)}");
        }
    }
}