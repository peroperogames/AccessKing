using System;

namespace PeroTools2.AccessKing
{
    public abstract class ParameterEventBus<TEventHandler> : IEventBus, IParameterEventBus<TEventHandler> where TEventHandler : IEventHandler<ParameterNotification>
    {
        public abstract void Publish();
        public abstract void Clear();
        protected abstract bool Unsubscribe(TEventHandler eventHandler);
        protected abstract void Subscribe(TEventHandler eventHandler);
        void IAccessBus.Dispatch(INotification notification) => ((IEventBus) this).Publish(in notification);
        bool IEventBus<TEventHandler, ParameterNotification>.Unsubscribe(TEventHandler eventHandler) => Unsubscribe(eventHandler);
        void IEventBus<TEventHandler, ParameterNotification>.Subscribe(TEventHandler eventHandler) => Unsubscribe(eventHandler);
        void IEventBus<TEventHandler, ParameterNotification>.Publish(in ParameterNotification notification) => Publish();
        void IEventBus.Publish<TNotification>(in TNotification notification) => Publish();

        bool IEventBus.Unsubscribe<TEventObserver>(TEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                return Unsubscribe(eventHandler);
            }

            return false;
        }

        void IEventBus.Subscribe<TEventObserver>(TEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                Subscribe(eventHandler);
                return;
            }

            throw new InvalidCastException($"Type {eventObserver.GetType()} is not {typeof(TEventHandler)}");
        }
    }

    public abstract class ParameterEventBus<TEventHandler, T> : IEventBus, IParameterEventBus<TEventHandler, T> where TEventHandler : IEventHandler<ParameterNotification<T>>
    {
        public abstract void Publish(T param);
        public abstract void Clear();
        protected abstract bool Unsubscribe(TEventHandler eventHandler);
        protected abstract void Subscribe(TEventHandler eventHandler);
        void IAccessBus.Dispatch(INotification notification) => ((IEventBus) this).Publish(in notification);
        bool IEventBus<TEventHandler, ParameterNotification<T>>.Unsubscribe(TEventHandler eventHandler) => Unsubscribe(eventHandler);
        void IEventBus<TEventHandler, ParameterNotification<T>>.Subscribe(TEventHandler eventHandler) => Unsubscribe(eventHandler);
        void IEventBus<TEventHandler, ParameterNotification<T>>.Publish(in ParameterNotification<T> notification) => Publish(notification.item);

        bool IEventBus.Unsubscribe<TEventObserver>(TEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                return Unsubscribe(eventHandler);
            }

            return false;
        }

        void IEventBus.Subscribe<TEventObserver>(TEventObserver eventObserver)
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

    public abstract class ParameterEventBus<TEventHandler, T1, T2> : IEventBus, IParameterEventBus<TEventHandler, T1, T2> where TEventHandler : IEventHandler<ParameterNotification<T1, T2>>
    {
        public abstract void Publish(T1 param1, T2 param2);
        public abstract void Clear();
        protected abstract bool Unsubscribe(TEventHandler eventHandler);
        protected abstract void Subscribe(TEventHandler eventHandler);
        void IAccessBus.Dispatch(INotification notification) => ((IEventBus) this).Publish(in notification);
        bool IEventBus<TEventHandler, ParameterNotification<T1, T2>>.Unsubscribe(TEventHandler eventHandler) => Unsubscribe(eventHandler);
        void IEventBus<TEventHandler, ParameterNotification<T1, T2>>.Subscribe(TEventHandler eventHandler) => Unsubscribe(eventHandler);
        void IEventBus<TEventHandler, ParameterNotification<T1, T2>>.Publish(in ParameterNotification<T1, T2> notification) => Publish(notification.item1, notification.item2);

        bool IEventBus.Unsubscribe<TEventObserver>(TEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                return Unsubscribe(eventHandler);
            }

            return false;
        }

        void IEventBus.Subscribe<TEventObserver>(TEventObserver eventObserver)
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

    public abstract class ParameterEventBus<TEventHandler, T1, T2, T3> : IEventBus, IParameterEventBus<TEventHandler, T1, T2, T3> where TEventHandler : IEventHandler<ParameterNotification<T1, T2, T3>>
    {
        public abstract void Publish(T1 param1, T2 param2, T3 param3);
        public abstract void Clear();
        protected abstract bool Unsubscribe(TEventHandler eventHandler);
        protected abstract void Subscribe(TEventHandler eventHandler);
        void IAccessBus.Dispatch(INotification notification) => ((IEventBus) this).Publish(in notification);
        bool IEventBus<TEventHandler, ParameterNotification<T1, T2, T3>>.Unsubscribe(TEventHandler eventHandler) => Unsubscribe(eventHandler);
        void IEventBus<TEventHandler, ParameterNotification<T1, T2, T3>>.Subscribe(TEventHandler eventHandler) => Unsubscribe(eventHandler);
        void IEventBus<TEventHandler, ParameterNotification<T1, T2, T3>>.Publish(in ParameterNotification<T1, T2, T3> notification) => Publish(notification.item1, notification.item2, notification.item3);

        bool IEventBus.Unsubscribe<TEventObserver>(TEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                return Unsubscribe(eventHandler);
            }

            return false;
        }

        void IEventBus.Subscribe<TEventObserver>(TEventObserver eventObserver)
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

    public abstract class ParameterEventBus<TEventHandler, T1, T2, T3, T4> : IEventBus, IParameterEventBus<TEventHandler, T1, T2, T3, T4> where TEventHandler : IEventHandler<ParameterNotification<T1, T2, T3, T4>>
    {
        public abstract void Publish(T1 param1, T2 param2, T3 param3, T4 param4);
        public abstract void Clear();
        protected abstract bool Unsubscribe(TEventHandler eventHandler);
        protected abstract void Subscribe(TEventHandler eventHandler);
        void IAccessBus.Dispatch(INotification notification) => ((IEventBus) this).Publish(in notification);
        bool IEventBus<TEventHandler, ParameterNotification<T1, T2, T3, T4>>.Unsubscribe(TEventHandler eventHandler) => Unsubscribe(eventHandler);
        void IEventBus<TEventHandler, ParameterNotification<T1, T2, T3, T4>>.Subscribe(TEventHandler eventHandler) => Unsubscribe(eventHandler);
        void IEventBus<TEventHandler, ParameterNotification<T1, T2, T3, T4>>.Publish(in ParameterNotification<T1, T2, T3, T4> notification) => Publish(notification.item1, notification.item2, notification.item3, notification.item4);

        bool IEventBus.Unsubscribe<TEventObserver>(TEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                return Unsubscribe(eventHandler);
            }

            return false;
        }

        void IEventBus.Subscribe<TEventObserver>(TEventObserver eventObserver)
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

    public abstract class ParameterEventBus<TEventHandler, T1, T2, T3, T4, T5> : IEventBus, IParameterEventBus<TEventHandler, T1, T2, T3, T4, T5> where TEventHandler : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5>>
    {
        public abstract void Publish(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5);
        public abstract void Clear();
        protected abstract bool Unsubscribe(TEventHandler eventHandler);
        protected abstract void Subscribe(TEventHandler eventHandler);
        void IAccessBus.Dispatch(INotification notification) => ((IEventBus) this).Publish(in notification);
        bool IEventBus<TEventHandler, ParameterNotification<T1, T2, T3, T4, T5>>.Unsubscribe(TEventHandler eventHandler) => Unsubscribe(eventHandler);
        void IEventBus<TEventHandler, ParameterNotification<T1, T2, T3, T4, T5>>.Subscribe(TEventHandler eventHandler) => Unsubscribe(eventHandler);
        void IEventBus<TEventHandler, ParameterNotification<T1, T2, T3, T4, T5>>.Publish(in ParameterNotification<T1, T2, T3, T4, T5> notification) => Publish(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5);

        bool IEventBus.Unsubscribe<TEventObserver>(TEventObserver eventObserver)
        {
            if (eventObserver is TEventHandler eventHandler)
            {
                return Unsubscribe(eventHandler);
            }

            return false;
        }

        void IEventBus.Subscribe<TEventObserver>(TEventObserver eventObserver)
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