/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/05 16:12:42
 */

using System;
using System.Reflection;
using UnityEngine.Scripting;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    public sealed class WeakActionEventHandler : IEventHandler, IWeakEventHandler, IWeakEventInvocation, IEquatable<WeakActionEventHandler>
    {
        [Preserve]
        private static ActionInvoker<object> s_Preserve;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly IInvocation m_Invocation;

        /// <summary>
        /// The owner that control this weak event's lifecycle.
        /// </summary>
        private readonly WeakReference<UnityEngine.Object> m_Owner;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <summary>
        /// The method that this weak handler invokes.
        /// </summary>
        MethodInfo IWeakEventInvocation.invocationMethod => m_Method;

        object IWeakEventInvocation.invocationOwner => currentOwner;

        /// <summary>
        /// The owner that controls the lifecycle of this handler, or null when it was already collected.
        /// It takes part in the equality because two providers may invoke the same method.
        /// </summary>
        private object currentOwner => m_Owner.TryGetTarget(out var owner) ? owner : null;

        /// <summary>Whether the provider that owns this handler is still alive.</summary>
        public bool isAlive => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.isAlive;

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="owner">The owner that control this weak event's lifecycle.</param>
        public WeakActionEventHandler(Action delegation, UnityEngine.Object owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (delegation is null)
            {
                throw new ArgumentNullException(nameof(delegation));
            }
            if (delegation.Target is null)
            {
                throw new ArgumentException("A weak subscription requires a delegate that targets an instance, a static method has no owner to keep alive.", nameof(delegation));
            }
            m_Owner = new WeakReference<UnityEngine.Object>(owner);
            m_Method = delegation.Method;
            var invokerType = typeof(ActionInvoker<>).MakeGenericType(delegation.Target.GetType());
            m_Invocation = Activator.CreateInstance(invokerType, delegation.Target, delegation) as IInvocation;
        }

        /// <inheritdoc/>
        public bool TryHandle(in Empty notification) => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.Invoke();

        /// <summary>Try to handle the notification and report whether the provider is still alive.</summary>
        public bool TryHandle() => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.Invoke();

        /// <inheritdoc/>
        public void Handle(in Empty notification)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke();
            }
        }

        /// <summary>Handle the notification when the provider is still alive.</summary>
        public void Handle()
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke();
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Method != null ? m_Method.GetHashCode() : 0) * 397 ^ (currentOwner != null ? currentOwner.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler other) => other is not null && m_Method == other.m_Method && Equals(currentOwner, other.currentOwner);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler other => Equals(other),
            Action action => action.Method == m_Method && Equals(action.Target, currentOwner),
            IEventInvocation invocation => invocation.invocationMethod == m_Method && Equals(invocation.invocationOwner, currentOwner),
            _ => false
        };

        private interface IInvocation
        {
            /// <summary>
            /// Whether the event provider that this invocation targets is still alive.
            /// </summary>
            bool isAlive { get; }

            bool Invoke();
        }

        private sealed class ActionInvoker<TProvider> : IInvocation where TProvider : class
        {
            /// <summary>
            /// The event provider.
            /// </summary>
            private readonly WeakReference<TProvider> m_Provider;

            /// <summary>
            /// Wrapped action.
            /// </summary>
            private readonly Action<TProvider> m_Invocation;

            public ActionInvoker(TProvider provider, Action action)
            {
                m_Provider = new WeakReference<TProvider>(provider);
                m_Invocation = action.Method.CreateDelegate(typeof(Action<TProvider>)) as Action<TProvider>;
            }

            /// <summary>
            /// Whether the wrapped event provider is still alive.
            /// </summary>
            public bool isAlive => m_Provider.TryGetTarget(out _);

            public bool Invoke()
            {
                if (!m_Provider.TryGetTarget(out var provider))
                {
                    return false;
                }
                m_Invocation.Invoke(provider);
                return true;
            }
        }
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    public sealed class WeakActionEventHandler<T> : IEventHandler<ParameterNotification<T>>, IWeakEventHandler<ParameterNotification<T>>, IWeakEventInvocation, IEquatable<WeakActionEventHandler<T>>
    {
        [Preserve]
        private static ActionInvoker<object> s_Preserve;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly IInvocation m_Invocation;

        /// <summary>
        /// The owner that control this weak event's lifecycle.
        /// </summary>
        private readonly WeakReference<UnityEngine.Object> m_Owner;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <summary>
        /// The method that this weak handler invokes.
        /// </summary>
        MethodInfo IWeakEventInvocation.invocationMethod => m_Method;

        object IWeakEventInvocation.invocationOwner => currentOwner;

        /// <summary>
        /// The owner that controls the lifecycle of this handler, or null when it was already collected.
        /// It takes part in the equality because two providers may invoke the same method.
        /// </summary>
        private object currentOwner => m_Owner.TryGetTarget(out var owner) ? owner : null;

        /// <summary>Whether the provider that owns this handler is still alive.</summary>
        public bool isAlive => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.isAlive;

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="owner">The owner that control this weak event's lifecycle.</param>
        public WeakActionEventHandler(Action<T> delegation, UnityEngine.Object owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (delegation is null)
            {
                throw new ArgumentNullException(nameof(delegation));
            }
            if (delegation.Target is null)
            {
                throw new ArgumentException("A weak subscription requires a delegate that targets an instance, a static method has no owner to keep alive.", nameof(delegation));
            }
            m_Owner = new WeakReference<UnityEngine.Object>(owner);
            m_Method = delegation.Method;
            var invokerType = typeof(ActionInvoker<>).MakeGenericType(typeof(T), delegation.Target.GetType());
            m_Invocation = Activator.CreateInstance(invokerType, delegation.Target, delegation) as IInvocation;
        }

        /// <inheritdoc/>
        public bool TryHandle(in ParameterNotification<T> notification) => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.Invoke(notification.item);

        /// <summary>Try to handle the notification and report whether the provider is still alive.</summary>
        public bool TryHandle(T param) => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.Invoke(param);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T> notification)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(notification.item);
            }
        }

        /// <summary>Handle the notification when the provider is still alive.</summary>
        public void Handle(T param)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(param);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Method != null ? m_Method.GetHashCode() : 0) * 397 ^ (currentOwner != null ? currentOwner.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<T> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<T> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<T> other) => other is not null && m_Method == other.m_Method && Equals(currentOwner, other.currentOwner);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<T> other => Equals(other),
            Action<T> action => action.Method == m_Method && Equals(action.Target, currentOwner),
            IEventInvocation invocation => invocation.invocationMethod == m_Method && Equals(invocation.invocationOwner, currentOwner),
            _ => false
        };

        private interface IInvocation
        {
            /// <summary>
            /// Whether the event provider that this invocation targets is still alive.
            /// </summary>
            bool isAlive { get; }

            bool Invoke(T param);
        }

        private sealed class ActionInvoker<TProvider> : IInvocation where TProvider : class
        {
            /// <summary>
            /// The event provider.
            /// </summary>
            private readonly WeakReference<TProvider> m_Provider;

            /// <summary>
            /// Wrapped action.
            /// </summary>
            private readonly Action<TProvider, T> m_Invocation;

            public ActionInvoker(TProvider provider, Action<T> action)
            {
                m_Provider = new WeakReference<TProvider>(provider);
                m_Invocation = action.Method.CreateDelegate(typeof(Action<TProvider, T>)) as Action<TProvider, T>;
            }

            /// <summary>
            /// Whether the wrapped event provider is still alive.
            /// </summary>
            public bool isAlive => m_Provider.TryGetTarget(out _);

            public bool Invoke(T param)
            {
                if (!m_Provider.TryGetTarget(out var provider))
                {
                    return false;
                }
                m_Invocation.Invoke(provider, param);
                return true;
            }
        }
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    public sealed class WeakActionEventHandler<T1, T2> : IEventHandler<ParameterNotification<T1, T2>>, IWeakEventHandler<ParameterNotification<T1, T2>>, IWeakEventInvocation,
        IEquatable<WeakActionEventHandler<T1, T2>>
    {
        [Preserve]
        private static ActionInvoker<object> s_Preserve;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly IInvocation m_Invocation;

        /// <summary>
        /// The owner that control this weak event's lifecycle.
        /// </summary>
        private readonly WeakReference<UnityEngine.Object> m_Owner;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <summary>
        /// The method that this weak handler invokes.
        /// </summary>
        MethodInfo IWeakEventInvocation.invocationMethod => m_Method;

        object IWeakEventInvocation.invocationOwner => currentOwner;

        /// <summary>
        /// The owner that controls the lifecycle of this handler, or null when it was already collected.
        /// It takes part in the equality because two providers may invoke the same method.
        /// </summary>
        private object currentOwner => m_Owner.TryGetTarget(out var owner) ? owner : null;

        /// <summary>Whether the provider that owns this handler is still alive.</summary>
        public bool isAlive => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.isAlive;

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="owner">The owner that control this weak event's lifecycle.</param>
        public WeakActionEventHandler(Action<T1, T2> delegation, UnityEngine.Object owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (delegation is null)
            {
                throw new ArgumentNullException(nameof(delegation));
            }
            if (delegation.Target is null)
            {
                throw new ArgumentException("A weak subscription requires a delegate that targets an instance, a static method has no owner to keep alive.", nameof(delegation));
            }
            m_Owner = new WeakReference<UnityEngine.Object>(owner);
            m_Method = delegation.Method;
            var invokerType = typeof(ActionInvoker<>).MakeGenericType(typeof(T1), typeof(T2), delegation.Target.GetType());
            m_Invocation = Activator.CreateInstance(invokerType, delegation.Target, delegation) as IInvocation;
        }

        /// <inheritdoc/>
        public bool TryHandle(in ParameterNotification<T1, T2> notification) => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.Invoke(notification.item1, notification.item2);

        /// <summary>Try to handle the notification and report whether the provider is still alive.</summary>
        public bool TryHandle(T1 param1, T2 param2) => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.Invoke(param1, param2);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2> notification)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(notification.item1, notification.item2);
            }
        }

        /// <summary>Handle the notification when the provider is still alive.</summary>
        public void Handle(T1 param1, T2 param2)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(param1, param2);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Method != null ? m_Method.GetHashCode() : 0) * 397 ^ (currentOwner != null ? currentOwner.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<T1, T2> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<T1, T2> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<T1, T2> other) => other is not null && m_Method == other.m_Method && Equals(currentOwner, other.currentOwner);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<T1, T2> other => Equals(other),
            Action<T1, T2> action => action.Method == m_Method && Equals(action.Target, currentOwner),
            IEventInvocation invocation => invocation.invocationMethod == m_Method && Equals(invocation.invocationOwner, currentOwner),
            _ => false
        };

        private interface IInvocation
        {
            /// <summary>
            /// Whether the event provider that this invocation targets is still alive.
            /// </summary>
            bool isAlive { get; }

            bool Invoke(T1 param1, T2 param2);
        }

        private sealed class ActionInvoker<TProvider> : IInvocation where TProvider : class
        {
            /// <summary>
            /// The event provider.
            /// </summary>
            private readonly WeakReference<TProvider> m_Provider;

            /// <summary>
            /// Wrapped action.
            /// </summary>
            private readonly Action<TProvider, T1, T2> m_Invocation;

            public ActionInvoker(TProvider provider, Action<T1, T2> action)
            {
                m_Provider = new WeakReference<TProvider>(provider);
                m_Invocation = action.Method.CreateDelegate(typeof(Action<TProvider, T1, T2>)) as Action<TProvider, T1, T2>;
            }

            /// <summary>
            /// Whether the wrapped event provider is still alive.
            /// </summary>
            public bool isAlive => m_Provider.TryGetTarget(out _);

            public bool Invoke(T1 param1, T2 param2)
            {
                if (!m_Provider.TryGetTarget(out var provider))
                {
                    return false;
                }
                m_Invocation.Invoke(provider, param1, param2);
                return true;
            }
        }
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    public sealed class WeakActionEventHandler<T1, T2, T3> : IEventHandler<ParameterNotification<T1, T2, T3>>, IWeakEventHandler<ParameterNotification<T1, T2, T3>>, IWeakEventInvocation,
        IEquatable<WeakActionEventHandler<T1, T2, T3>>
    {
        [Preserve]
        private static ActionInvoker<object> s_Preserve;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly IInvocation m_Invocation;

        /// <summary>
        /// The owner that control this weak event's lifecycle.
        /// </summary>
        private readonly WeakReference<UnityEngine.Object> m_Owner;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <summary>
        /// The method that this weak handler invokes.
        /// </summary>
        MethodInfo IWeakEventInvocation.invocationMethod => m_Method;

        object IWeakEventInvocation.invocationOwner => currentOwner;

        /// <summary>
        /// The owner that controls the lifecycle of this handler, or null when it was already collected.
        /// It takes part in the equality because two providers may invoke the same method.
        /// </summary>
        private object currentOwner => m_Owner.TryGetTarget(out var owner) ? owner : null;

        /// <summary>Whether the provider that owns this handler is still alive.</summary>
        public bool isAlive => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.isAlive;

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="owner">The owner that control this weak event's lifecycle.</param>
        public WeakActionEventHandler(Action<T1, T2, T3> delegation, UnityEngine.Object owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (delegation is null)
            {
                throw new ArgumentNullException(nameof(delegation));
            }
            if (delegation.Target is null)
            {
                throw new ArgumentException("A weak subscription requires a delegate that targets an instance, a static method has no owner to keep alive.", nameof(delegation));
            }
            m_Owner = new WeakReference<UnityEngine.Object>(owner);
            m_Method = delegation.Method;
            var invokerType = typeof(ActionInvoker<>).MakeGenericType(typeof(T1), typeof(T2), typeof(T3), delegation.Target.GetType());
            m_Invocation = Activator.CreateInstance(invokerType, delegation.Target, delegation) as IInvocation;
        }

        /// <inheritdoc/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3> notification) =>
            m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.Invoke(notification.item1, notification.item2, notification.item3);

        /// <summary>Try to handle the notification and report whether the provider is still alive.</summary>
        public bool TryHandle(T1 param1, T2 param2, T3 param3) => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.Invoke(param1, param2, param3);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3> notification)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(notification.item1, notification.item2, notification.item3);
            }
        }

        /// <summary>Handle the notification when the provider is still alive.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(param1, param2, param3);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Method != null ? m_Method.GetHashCode() : 0) * 397 ^ (currentOwner != null ? currentOwner.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<T1, T2, T3> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<T1, T2, T3> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<T1, T2, T3> other) => other is not null && m_Method == other.m_Method && Equals(currentOwner, other.currentOwner);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<T1, T2, T3> other => Equals(other),
            Action<T1, T2, T3> action => action.Method == m_Method && Equals(action.Target, currentOwner),
            IEventInvocation invocation => invocation.invocationMethod == m_Method && Equals(invocation.invocationOwner, currentOwner),
            _ => false
        };

        private interface IInvocation
        {
            /// <summary>
            /// Whether the event provider that this invocation targets is still alive.
            /// </summary>
            bool isAlive { get; }

            bool Invoke(T1 param1, T2 param2, T3 param3);
        }

        private sealed class ActionInvoker<TProvider> : IInvocation where TProvider : class
        {
            /// <summary>
            /// The event provider.
            /// </summary>
            private readonly WeakReference<TProvider> m_Provider;

            /// <summary>
            /// Wrapped action.
            /// </summary>
            private readonly Action<TProvider, T1, T2, T3> m_Invocation;

            public ActionInvoker(TProvider provider, Action<T1, T2, T3> action)
            {
                m_Provider = new WeakReference<TProvider>(provider);
                m_Invocation = action.Method.CreateDelegate(typeof(Action<TProvider, T1, T2, T3>)) as Action<TProvider, T1, T2, T3>;
            }

            /// <summary>
            /// Whether the wrapped event provider is still alive.
            /// </summary>
            public bool isAlive => m_Provider.TryGetTarget(out _);

            public bool Invoke(T1 param1, T2 param2, T3 param3)
            {
                if (!m_Provider.TryGetTarget(out var provider))
                {
                    return false;
                }
                m_Invocation.Invoke(provider, param1, param2, param3);
                return true;
            }
        }
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    public sealed class WeakActionEventHandler<T1, T2, T3, T4> : IEventHandler<ParameterNotification<T1, T2, T3, T4>>, IWeakEventHandler<ParameterNotification<T1, T2, T3, T4>>, IWeakEventInvocation,
        IEquatable<WeakActionEventHandler<T1, T2, T3, T4>>
    {
        [Preserve]
        private static ActionInvoker<object> s_Preserve;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly IInvocation m_Invocation;

        /// <summary>
        /// The owner that control this weak event's lifecycle.
        /// </summary>
        private readonly WeakReference<UnityEngine.Object> m_Owner;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <summary>
        /// The method that this weak handler invokes.
        /// </summary>
        MethodInfo IWeakEventInvocation.invocationMethod => m_Method;

        object IWeakEventInvocation.invocationOwner => currentOwner;

        /// <summary>
        /// The owner that controls the lifecycle of this handler, or null when it was already collected.
        /// It takes part in the equality because two providers may invoke the same method.
        /// </summary>
        private object currentOwner => m_Owner.TryGetTarget(out var owner) ? owner : null;

        /// <summary>Whether the provider that owns this handler is still alive.</summary>
        public bool isAlive => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.isAlive;

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="owner">The owner that control this weak event's lifecycle.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4> delegation, UnityEngine.Object owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (delegation is null)
            {
                throw new ArgumentNullException(nameof(delegation));
            }
            if (delegation.Target is null)
            {
                throw new ArgumentException("A weak subscription requires a delegate that targets an instance, a static method has no owner to keep alive.", nameof(delegation));
            }
            m_Owner = new WeakReference<UnityEngine.Object>(owner);
            m_Method = delegation.Method;
            var invokerType = typeof(ActionInvoker<>).MakeGenericType(typeof(T1), typeof(T2), typeof(T3), typeof(T4), delegation.Target.GetType());
            m_Invocation = Activator.CreateInstance(invokerType, delegation.Target, delegation) as IInvocation;
        }

        /// <inheritdoc/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4> notification) => m_Owner.TryGetTarget(out var owner) && owner != null &&
                                                                                        m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4);

        /// <summary>Try to handle the notification and report whether the provider is still alive.</summary>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4) => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.Invoke(param1, param2, param3, param4);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4> notification)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4);
            }
        }

        /// <summary>Handle the notification when the provider is still alive.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(param1, param2, param3, param4);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Method != null ? m_Method.GetHashCode() : 0) * 397 ^ (currentOwner != null ? currentOwner.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<T1, T2, T3, T4> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<T1, T2, T3, T4> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<T1, T2, T3, T4> other) => other is not null && m_Method == other.m_Method && Equals(currentOwner, other.currentOwner);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<T1, T2, T3, T4> other => Equals(other),
            Action<T1, T2, T3, T4> action => action.Method == m_Method && Equals(action.Target, currentOwner),
            IEventInvocation invocation => invocation.invocationMethod == m_Method && Equals(invocation.invocationOwner, currentOwner),
            _ => false
        };

        private interface IInvocation
        {
            /// <summary>
            /// Whether the event provider that this invocation targets is still alive.
            /// </summary>
            bool isAlive { get; }

            bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4);
        }

        private sealed class ActionInvoker<TProvider> : IInvocation where TProvider : class
        {
            /// <summary>
            /// The event provider.
            /// </summary>
            private readonly WeakReference<TProvider> m_Provider;

            /// <summary>
            /// Wrapped action.
            /// </summary>
            private readonly Action<TProvider, T1, T2, T3, T4> m_Invocation;

            public ActionInvoker(TProvider provider, Action<T1, T2, T3, T4> action)
            {
                m_Provider = new WeakReference<TProvider>(provider);
                m_Invocation = action.Method.CreateDelegate(typeof(Action<TProvider, T1, T2, T3, T4>)) as Action<TProvider, T1, T2, T3, T4>;
            }

            /// <summary>
            /// Whether the wrapped event provider is still alive.
            /// </summary>
            public bool isAlive => m_Provider.TryGetTarget(out _);

            public bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4)
            {
                if (!m_Provider.TryGetTarget(out var provider))
                {
                    return false;
                }
                m_Invocation.Invoke(provider, param1, param2, param3, param4);
                return true;
            }
        }
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    public sealed class WeakActionEventHandler<T1, T2, T3, T4, T5> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5>>, IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5>>,
        IWeakEventInvocation, IEquatable<WeakActionEventHandler<T1, T2, T3, T4, T5>>
    {
        [Preserve]
        private static ActionInvoker<object> s_Preserve;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly IInvocation m_Invocation;

        /// <summary>
        /// The owner that control this weak event's lifecycle.
        /// </summary>
        private readonly WeakReference<UnityEngine.Object> m_Owner;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <summary>
        /// The method that this weak handler invokes.
        /// </summary>
        MethodInfo IWeakEventInvocation.invocationMethod => m_Method;

        object IWeakEventInvocation.invocationOwner => currentOwner;

        /// <summary>
        /// The owner that controls the lifecycle of this handler, or null when it was already collected.
        /// It takes part in the equality because two providers may invoke the same method.
        /// </summary>
        private object currentOwner => m_Owner.TryGetTarget(out var owner) ? owner : null;

        /// <summary>Whether the provider that owns this handler is still alive.</summary>
        public bool isAlive => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.isAlive;

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="owner">The owner that control this weak event's lifecycle.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5> delegation, UnityEngine.Object owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (delegation is null)
            {
                throw new ArgumentNullException(nameof(delegation));
            }
            if (delegation.Target is null)
            {
                throw new ArgumentException("A weak subscription requires a delegate that targets an instance, a static method has no owner to keep alive.", nameof(delegation));
            }
            m_Owner = new WeakReference<UnityEngine.Object>(owner);
            m_Method = delegation.Method;
            var invokerType = typeof(ActionInvoker<>).MakeGenericType(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), delegation.Target.GetType());
            m_Invocation = Activator.CreateInstance(invokerType, delegation.Target, delegation) as IInvocation;
        }

        /// <inheritdoc/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5> notification) => m_Owner.TryGetTarget(out var owner) && owner != null &&
                                                                                            m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4,
                                                                                                notification.item5);

        /// <summary>Try to handle the notification and report whether the provider is still alive.</summary>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5) =>
            m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.Invoke(param1, param2, param3, param4, param5);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5> notification)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5);
            }
        }

        /// <summary>Handle the notification when the provider is still alive.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(param1, param2, param3, param4, param5);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Method != null ? m_Method.GetHashCode() : 0) * 397 ^ (currentOwner != null ? currentOwner.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<T1, T2, T3, T4, T5> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<T1, T2, T3, T4, T5> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<T1, T2, T3, T4, T5> other) => other is not null && m_Method == other.m_Method && Equals(currentOwner, other.currentOwner);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<T1, T2, T3, T4, T5> other => Equals(other),
            Action<T1, T2, T3, T4, T5> action => action.Method == m_Method && Equals(action.Target, currentOwner),
            IEventInvocation invocation => invocation.invocationMethod == m_Method && Equals(invocation.invocationOwner, currentOwner),
            _ => false
        };

        private interface IInvocation
        {
            /// <summary>
            /// Whether the event provider that this invocation targets is still alive.
            /// </summary>
            bool isAlive { get; }

            bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5);
        }

        private sealed class ActionInvoker<TProvider> : IInvocation where TProvider : class
        {
            /// <summary>
            /// The event provider.
            /// </summary>
            private readonly WeakReference<TProvider> m_Provider;

            /// <summary>
            /// Wrapped action.
            /// </summary>
            private readonly Action<TProvider, T1, T2, T3, T4, T5> m_Invocation;

            public ActionInvoker(TProvider provider, Action<T1, T2, T3, T4, T5> action)
            {
                m_Provider = new WeakReference<TProvider>(provider);
                m_Invocation = action.Method.CreateDelegate(typeof(Action<TProvider, T1, T2, T3, T4, T5>)) as Action<TProvider, T1, T2, T3, T4, T5>;
            }

            /// <summary>
            /// Whether the wrapped event provider is still alive.
            /// </summary>
            public bool isAlive => m_Provider.TryGetTarget(out _);

            public bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
            {
                if (!m_Provider.TryGetTarget(out var provider))
                {
                    return false;
                }
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5);
                return true;
            }
        }
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    public sealed class WeakActionEventHandler<T1, T2, T3, T4, T5, T6> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6>>, IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6>>,
        IWeakEventInvocation, IEquatable<WeakActionEventHandler<T1, T2, T3, T4, T5, T6>>
    {
        [Preserve]
        private static ActionInvoker<object> s_Preserve;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly IInvocation m_Invocation;

        /// <summary>
        /// The owner that control this weak event's lifecycle.
        /// </summary>
        private readonly WeakReference<UnityEngine.Object> m_Owner;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <summary>
        /// The method that this weak handler invokes.
        /// </summary>
        MethodInfo IWeakEventInvocation.invocationMethod => m_Method;

        object IWeakEventInvocation.invocationOwner => currentOwner;

        /// <summary>
        /// The owner that controls the lifecycle of this handler, or null when it was already collected.
        /// It takes part in the equality because two providers may invoke the same method.
        /// </summary>
        private object currentOwner => m_Owner.TryGetTarget(out var owner) ? owner : null;

        /// <summary>Whether the provider that owns this handler is still alive.</summary>
        public bool isAlive => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.isAlive;

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="owner">The owner that control this weak event's lifecycle.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6> delegation, UnityEngine.Object owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (delegation is null)
            {
                throw new ArgumentNullException(nameof(delegation));
            }
            if (delegation.Target is null)
            {
                throw new ArgumentException("A weak subscription requires a delegate that targets an instance, a static method has no owner to keep alive.", nameof(delegation));
            }
            m_Owner = new WeakReference<UnityEngine.Object>(owner);
            m_Method = delegation.Method;
            var invokerType = typeof(ActionInvoker<>).MakeGenericType(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), delegation.Target.GetType());
            m_Invocation = Activator.CreateInstance(invokerType, delegation.Target, delegation) as IInvocation;
        }

        /// <inheritdoc/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6> notification) => m_Owner.TryGetTarget(out var owner) && owner != null &&
                                                                                                m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4,
                                                                                                    notification.item5, notification.item6);

        /// <summary>Try to handle the notification and report whether the provider is still alive.</summary>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6) =>
            m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.Invoke(param1, param2, param3, param4, param5, param6);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6> notification)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6);
            }
        }

        /// <summary>Handle the notification when the provider is still alive.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(param1, param2, param3, param4, param5, param6);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Method != null ? m_Method.GetHashCode() : 0) * 397 ^ (currentOwner != null ? currentOwner.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<T1, T2, T3, T4, T5, T6> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<T1, T2, T3, T4, T5, T6> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<T1, T2, T3, T4, T5, T6> other) => other is not null && m_Method == other.m_Method && Equals(currentOwner, other.currentOwner);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<T1, T2, T3, T4, T5, T6> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6> action => action.Method == m_Method && Equals(action.Target, currentOwner),
            IEventInvocation invocation => invocation.invocationMethod == m_Method && Equals(invocation.invocationOwner, currentOwner),
            _ => false
        };

        private interface IInvocation
        {
            /// <summary>
            /// Whether the event provider that this invocation targets is still alive.
            /// </summary>
            bool isAlive { get; }

            bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6);
        }

        private sealed class ActionInvoker<TProvider> : IInvocation where TProvider : class
        {
            /// <summary>
            /// The event provider.
            /// </summary>
            private readonly WeakReference<TProvider> m_Provider;

            /// <summary>
            /// Wrapped action.
            /// </summary>
            private readonly Action<TProvider, T1, T2, T3, T4, T5, T6> m_Invocation;

            public ActionInvoker(TProvider provider, Action<T1, T2, T3, T4, T5, T6> action)
            {
                m_Provider = new WeakReference<TProvider>(provider);
                m_Invocation = action.Method.CreateDelegate(typeof(Action<TProvider, T1, T2, T3, T4, T5, T6>)) as Action<TProvider, T1, T2, T3, T4, T5, T6>;
            }

            /// <summary>
            /// Whether the wrapped event provider is still alive.
            /// </summary>
            public bool isAlive => m_Provider.TryGetTarget(out _);

            public bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6)
            {
                if (!m_Provider.TryGetTarget(out var provider))
                {
                    return false;
                }
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6);
                return true;
            }
        }
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    public sealed class WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7>>,
        IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7>>, IWeakEventInvocation, IEquatable<WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7>>
    {
        [Preserve]
        private static ActionInvoker<object> s_Preserve;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly IInvocation m_Invocation;

        /// <summary>
        /// The owner that control this weak event's lifecycle.
        /// </summary>
        private readonly WeakReference<UnityEngine.Object> m_Owner;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <summary>
        /// The method that this weak handler invokes.
        /// </summary>
        MethodInfo IWeakEventInvocation.invocationMethod => m_Method;

        object IWeakEventInvocation.invocationOwner => currentOwner;

        /// <summary>
        /// The owner that controls the lifecycle of this handler, or null when it was already collected.
        /// It takes part in the equality because two providers may invoke the same method.
        /// </summary>
        private object currentOwner => m_Owner.TryGetTarget(out var owner) ? owner : null;

        /// <summary>Whether the provider that owns this handler is still alive.</summary>
        public bool isAlive => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.isAlive;

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="owner">The owner that control this weak event's lifecycle.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7> delegation, UnityEngine.Object owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (delegation is null)
            {
                throw new ArgumentNullException(nameof(delegation));
            }
            if (delegation.Target is null)
            {
                throw new ArgumentException("A weak subscription requires a delegate that targets an instance, a static method has no owner to keep alive.", nameof(delegation));
            }
            m_Owner = new WeakReference<UnityEngine.Object>(owner);
            m_Method = delegation.Method;
            var invokerType = typeof(ActionInvoker<>).MakeGenericType(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), delegation.Target.GetType());
            m_Invocation = Activator.CreateInstance(invokerType, delegation.Target, delegation) as IInvocation;
        }

        /// <inheritdoc/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7> notification) => m_Owner.TryGetTarget(out var owner) && owner != null &&
                                                                                                    m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4,
                                                                                                        notification.item5, notification.item6, notification.item7);

        /// <summary>Try to handle the notification and report whether the provider is still alive.</summary>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7) =>
            m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7> notification)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7);
            }
        }

        /// <summary>Handle the notification when the provider is still alive.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Method != null ? m_Method.GetHashCode() : 0) * 397 ^ (currentOwner != null ? currentOwner.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7> other) => other is not null && m_Method == other.m_Method && Equals(currentOwner, other.currentOwner);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7> action => action.Method == m_Method && Equals(action.Target, currentOwner),
            IEventInvocation invocation => invocation.invocationMethod == m_Method && Equals(invocation.invocationOwner, currentOwner),
            _ => false
        };

        private interface IInvocation
        {
            /// <summary>
            /// Whether the event provider that this invocation targets is still alive.
            /// </summary>
            bool isAlive { get; }

            bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7);
        }

        private sealed class ActionInvoker<TProvider> : IInvocation where TProvider : class
        {
            /// <summary>
            /// The event provider.
            /// </summary>
            private readonly WeakReference<TProvider> m_Provider;

            /// <summary>
            /// Wrapped action.
            /// </summary>
            private readonly Action<TProvider, T1, T2, T3, T4, T5, T6, T7> m_Invocation;

            public ActionInvoker(TProvider provider, Action<T1, T2, T3, T4, T5, T6, T7> action)
            {
                m_Provider = new WeakReference<TProvider>(provider);
                m_Invocation = action.Method.CreateDelegate(typeof(Action<TProvider, T1, T2, T3, T4, T5, T6, T7>)) as Action<TProvider, T1, T2, T3, T4, T5, T6, T7>;
            }

            /// <summary>
            /// Whether the wrapped event provider is still alive.
            /// </summary>
            public bool isAlive => m_Provider.TryGetTarget(out _);

            public bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7)
            {
                if (!m_Provider.TryGetTarget(out var provider))
                {
                    return false;
                }
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7);
                return true;
            }
        }
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    public sealed class WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>>,
        IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>>, IWeakEventInvocation, IEquatable<WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8>>
    {
        [Preserve]
        private static ActionInvoker<object> s_Preserve;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly IInvocation m_Invocation;

        /// <summary>
        /// The owner that control this weak event's lifecycle.
        /// </summary>
        private readonly WeakReference<UnityEngine.Object> m_Owner;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <summary>
        /// The method that this weak handler invokes.
        /// </summary>
        MethodInfo IWeakEventInvocation.invocationMethod => m_Method;

        object IWeakEventInvocation.invocationOwner => currentOwner;

        /// <summary>
        /// The owner that controls the lifecycle of this handler, or null when it was already collected.
        /// It takes part in the equality because two providers may invoke the same method.
        /// </summary>
        private object currentOwner => m_Owner.TryGetTarget(out var owner) ? owner : null;

        /// <summary>Whether the provider that owns this handler is still alive.</summary>
        public bool isAlive => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.isAlive;

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="owner">The owner that control this weak event's lifecycle.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8> delegation, UnityEngine.Object owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (delegation is null)
            {
                throw new ArgumentNullException(nameof(delegation));
            }
            if (delegation.Target is null)
            {
                throw new ArgumentException("A weak subscription requires a delegate that targets an instance, a static method has no owner to keep alive.", nameof(delegation));
            }
            m_Owner = new WeakReference<UnityEngine.Object>(owner);
            m_Method = delegation.Method;
            var invokerType = typeof(ActionInvoker<>).MakeGenericType(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), delegation.Target.GetType());
            m_Invocation = Activator.CreateInstance(invokerType, delegation.Target, delegation) as IInvocation;
        }

        /// <inheritdoc/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8> notification) => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.Invoke(notification.item1,
            notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8);

        /// <summary>Try to handle the notification and report whether the provider is still alive.</summary>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8) =>
            m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8> notification)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8);
            }
        }

        /// <summary>Handle the notification when the provider is still alive.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Method != null ? m_Method.GetHashCode() : 0) * 397 ^ (currentOwner != null ? currentOwner.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8> other) => other is not null && m_Method == other.m_Method && Equals(currentOwner, other.currentOwner);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8> action => action.Method == m_Method && Equals(action.Target, currentOwner),
            IEventInvocation invocation => invocation.invocationMethod == m_Method && Equals(invocation.invocationOwner, currentOwner),
            _ => false
        };

        private interface IInvocation
        {
            /// <summary>
            /// Whether the event provider that this invocation targets is still alive.
            /// </summary>
            bool isAlive { get; }

            bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8);
        }

        private sealed class ActionInvoker<TProvider> : IInvocation where TProvider : class
        {
            /// <summary>
            /// The event provider.
            /// </summary>
            private readonly WeakReference<TProvider> m_Provider;

            /// <summary>
            /// Wrapped action.
            /// </summary>
            private readonly Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8> m_Invocation;

            public ActionInvoker(TProvider provider, Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
            {
                m_Provider = new WeakReference<TProvider>(provider);
                m_Invocation = action.Method.CreateDelegate(typeof(Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8>)) as Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8>;
            }

            /// <summary>
            /// Whether the wrapped event provider is still alive.
            /// </summary>
            public bool isAlive => m_Provider.TryGetTarget(out _);

            public bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8)
            {
                if (!m_Provider.TryGetTarget(out var provider))
                {
                    return false;
                }
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8);
                return true;
            }
        }
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    public sealed class WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9>>,
        IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9>>, IWeakEventInvocation, IEquatable<WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9>>
    {
        [Preserve]
        private static ActionInvoker<object> s_Preserve;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly IInvocation m_Invocation;

        /// <summary>
        /// The owner that control this weak event's lifecycle.
        /// </summary>
        private readonly WeakReference<UnityEngine.Object> m_Owner;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <summary>
        /// The method that this weak handler invokes.
        /// </summary>
        MethodInfo IWeakEventInvocation.invocationMethod => m_Method;

        object IWeakEventInvocation.invocationOwner => currentOwner;

        /// <summary>
        /// The owner that controls the lifecycle of this handler, or null when it was already collected.
        /// It takes part in the equality because two providers may invoke the same method.
        /// </summary>
        private object currentOwner => m_Owner.TryGetTarget(out var owner) ? owner : null;

        /// <summary>Whether the provider that owns this handler is still alive.</summary>
        public bool isAlive => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.isAlive;

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="owner">The owner that control this weak event's lifecycle.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> delegation, UnityEngine.Object owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (delegation is null)
            {
                throw new ArgumentNullException(nameof(delegation));
            }
            if (delegation.Target is null)
            {
                throw new ArgumentException("A weak subscription requires a delegate that targets an instance, a static method has no owner to keep alive.", nameof(delegation));
            }
            m_Owner = new WeakReference<UnityEngine.Object>(owner);
            m_Method = delegation.Method;
            var invokerType = typeof(ActionInvoker<>).MakeGenericType(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9),
                delegation.Target.GetType());
            m_Invocation = Activator.CreateInstance(invokerType, delegation.Target, delegation) as IInvocation;
        }

        /// <inheritdoc/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9> notification) => m_Owner.TryGetTarget(out var owner) && owner != null &&
                                                                                                            m_Invocation.Invoke(notification.item1, notification.item2, notification.item3,
                                                                                                                notification.item4, notification.item5, notification.item6, notification.item7,
                                                                                                                notification.item8, notification.item9);

        /// <summary>Try to handle the notification and report whether the provider is still alive.</summary>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9) => m_Owner.TryGetTarget(out var owner) && owner != null &&
                                                                                                                                    m_Invocation.Invoke(param1, param2, param3, param4, param5, param6,
                                                                                                                                        param7, param8, param9);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9> notification)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8,
                    notification.item9);
            }
        }

        /// <summary>Handle the notification when the provider is still alive.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Method != null ? m_Method.GetHashCode() : 0) * 397 ^ (currentOwner != null ? currentOwner.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> other) => other is not null && m_Method == other.m_Method && Equals(currentOwner, other.currentOwner);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action => action.Method == m_Method && Equals(action.Target, currentOwner),
            IEventInvocation invocation => invocation.invocationMethod == m_Method && Equals(invocation.invocationOwner, currentOwner),
            _ => false
        };

        private interface IInvocation
        {
            /// <summary>
            /// Whether the event provider that this invocation targets is still alive.
            /// </summary>
            bool isAlive { get; }

            bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9);
        }

        private sealed class ActionInvoker<TProvider> : IInvocation where TProvider : class
        {
            /// <summary>
            /// The event provider.
            /// </summary>
            private readonly WeakReference<TProvider> m_Provider;

            /// <summary>
            /// Wrapped action.
            /// </summary>
            private readonly Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9> m_Invocation;

            public ActionInvoker(TProvider provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
            {
                m_Provider = new WeakReference<TProvider>(provider);
                m_Invocation = action.Method.CreateDelegate(typeof(Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9>)) as Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9>;
            }

            /// <summary>
            /// Whether the wrapped event provider is still alive.
            /// </summary>
            public bool isAlive => m_Provider.TryGetTarget(out _);

            public bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9)
            {
                if (!m_Provider.TryGetTarget(out var provider))
                {
                    return false;
                }
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9);
                return true;
            }
        }
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    public sealed class WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>,
        IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>, IWeakEventInvocation, IEquatable<WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
    {
        [Preserve]
        private static ActionInvoker<object> s_Preserve;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly IInvocation m_Invocation;

        /// <summary>
        /// The owner that control this weak event's lifecycle.
        /// </summary>
        private readonly WeakReference<UnityEngine.Object> m_Owner;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <summary>
        /// The method that this weak handler invokes.
        /// </summary>
        MethodInfo IWeakEventInvocation.invocationMethod => m_Method;

        object IWeakEventInvocation.invocationOwner => currentOwner;

        /// <summary>
        /// The owner that controls the lifecycle of this handler, or null when it was already collected.
        /// It takes part in the equality because two providers may invoke the same method.
        /// </summary>
        private object currentOwner => m_Owner.TryGetTarget(out var owner) ? owner : null;

        /// <summary>Whether the provider that owns this handler is still alive.</summary>
        public bool isAlive => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.isAlive;

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="owner">The owner that control this weak event's lifecycle.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> delegation, UnityEngine.Object owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (delegation is null)
            {
                throw new ArgumentNullException(nameof(delegation));
            }
            if (delegation.Target is null)
            {
                throw new ArgumentException("A weak subscription requires a delegate that targets an instance, a static method has no owner to keep alive.", nameof(delegation));
            }
            m_Owner = new WeakReference<UnityEngine.Object>(owner);
            m_Method = delegation.Method;
            var invokerType = typeof(ActionInvoker<>).MakeGenericType(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10),
                delegation.Target.GetType());
            m_Invocation = Activator.CreateInstance(invokerType, delegation.Target, delegation) as IInvocation;
        }

        /// <inheritdoc/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> notification) => m_Owner.TryGetTarget(out var owner) && owner != null &&
                                                                                                                 m_Invocation.Invoke(notification.item1, notification.item2, notification.item3,
                                                                                                                     notification.item4, notification.item5, notification.item6, notification.item7,
                                                                                                                     notification.item8, notification.item9, notification.item10);

        /// <summary>Try to handle the notification and report whether the provider is still alive.</summary>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10) => m_Owner.TryGetTarget(out var owner) && owner != null &&
            m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> notification)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8,
                    notification.item9, notification.item10);
            }
        }

        /// <summary>Handle the notification when the provider is still alive.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Method != null ? m_Method.GetHashCode() : 0) * 397 ^ (currentOwner != null ? currentOwner.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> other) => other is not null && m_Method == other.m_Method && Equals(currentOwner, other.currentOwner);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action => action.Method == m_Method && Equals(action.Target, currentOwner),
            IEventInvocation invocation => invocation.invocationMethod == m_Method && Equals(invocation.invocationOwner, currentOwner),
            _ => false
        };

        private interface IInvocation
        {
            /// <summary>
            /// Whether the event provider that this invocation targets is still alive.
            /// </summary>
            bool isAlive { get; }

            bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10);
        }

        private sealed class ActionInvoker<TProvider> : IInvocation where TProvider : class
        {
            /// <summary>
            /// The event provider.
            /// </summary>
            private readonly WeakReference<TProvider> m_Provider;

            /// <summary>
            /// Wrapped action.
            /// </summary>
            private readonly Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> m_Invocation;

            public ActionInvoker(TProvider provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
            {
                m_Provider = new WeakReference<TProvider>(provider);
                m_Invocation = action.Method.CreateDelegate(typeof(Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)) as Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>;
            }

            /// <summary>
            /// Whether the wrapped event provider is still alive.
            /// </summary>
            public bool isAlive => m_Provider.TryGetTarget(out _);

            public bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10)
            {
                if (!m_Provider.TryGetTarget(out var provider))
                {
                    return false;
                }
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);
                return true;
            }
        }
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    public sealed class WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>,
        IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>, IWeakEventInvocation, IEquatable<WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>
    {
        [Preserve]
        private static ActionInvoker<object> s_Preserve;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly IInvocation m_Invocation;

        /// <summary>
        /// The owner that control this weak event's lifecycle.
        /// </summary>
        private readonly WeakReference<UnityEngine.Object> m_Owner;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <summary>
        /// The method that this weak handler invokes.
        /// </summary>
        MethodInfo IWeakEventInvocation.invocationMethod => m_Method;

        object IWeakEventInvocation.invocationOwner => currentOwner;

        /// <summary>
        /// The owner that controls the lifecycle of this handler, or null when it was already collected.
        /// It takes part in the equality because two providers may invoke the same method.
        /// </summary>
        private object currentOwner => m_Owner.TryGetTarget(out var owner) ? owner : null;

        /// <summary>Whether the provider that owns this handler is still alive.</summary>
        public bool isAlive => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.isAlive;

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="owner">The owner that control this weak event's lifecycle.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> delegation, UnityEngine.Object owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (delegation is null)
            {
                throw new ArgumentNullException(nameof(delegation));
            }
            if (delegation.Target is null)
            {
                throw new ArgumentException("A weak subscription requires a delegate that targets an instance, a static method has no owner to keep alive.", nameof(delegation));
            }
            m_Owner = new WeakReference<UnityEngine.Object>(owner);
            m_Method = delegation.Method;
            var invokerType = typeof(ActionInvoker<>).MakeGenericType(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10),
                typeof(T11), delegation.Target.GetType());
            m_Invocation = Activator.CreateInstance(invokerType, delegation.Target, delegation) as IInvocation;
        }

        /// <inheritdoc/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> notification) => m_Owner.TryGetTarget(out var owner) && owner != null &&
                                                                                                                      m_Invocation.Invoke(notification.item1, notification.item2, notification.item3,
                                                                                                                          notification.item4, notification.item5, notification.item6,
                                                                                                                          notification.item7, notification.item8, notification.item9,
                                                                                                                          notification.item10, notification.item11);

        /// <summary>Try to handle the notification and report whether the provider is still alive.</summary>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11) => m_Owner.TryGetTarget(out var owner) &&
            owner != null && m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> notification)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8,
                    notification.item9, notification.item10, notification.item11);
            }
        }

        /// <summary>Handle the notification when the provider is still alive.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Method != null ? m_Method.GetHashCode() : 0) * 397 ^ (currentOwner != null ? currentOwner.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> other) => other is not null && m_Method == other.m_Method && Equals(currentOwner, other.currentOwner);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action => action.Method == m_Method && Equals(action.Target, currentOwner),
            IEventInvocation invocation => invocation.invocationMethod == m_Method && Equals(invocation.invocationOwner, currentOwner),
            _ => false
        };

        private interface IInvocation
        {
            /// <summary>
            /// Whether the event provider that this invocation targets is still alive.
            /// </summary>
            bool isAlive { get; }

            bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11);
        }

        private sealed class ActionInvoker<TProvider> : IInvocation where TProvider : class
        {
            /// <summary>
            /// The event provider.
            /// </summary>
            private readonly WeakReference<TProvider> m_Provider;

            /// <summary>
            /// Wrapped action.
            /// </summary>
            private readonly Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> m_Invocation;

            public ActionInvoker(TProvider provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
            {
                m_Provider = new WeakReference<TProvider>(provider);
                m_Invocation = action.Method.CreateDelegate(typeof(Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>)) as Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>;
            }

            /// <summary>
            /// Whether the wrapped event provider is still alive.
            /// </summary>
            public bool isAlive => m_Provider.TryGetTarget(out _);

            public bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11)
            {
                if (!m_Provider.TryGetTarget(out var provider))
                {
                    return false;
                }
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);
                return true;
            }
        }
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    public sealed class WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>,
        IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>, IWeakEventInvocation,
        IEquatable<WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>
    {
        [Preserve]
        private static ActionInvoker<object> s_Preserve;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly IInvocation m_Invocation;

        /// <summary>
        /// The owner that control this weak event's lifecycle.
        /// </summary>
        private readonly WeakReference<UnityEngine.Object> m_Owner;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <summary>
        /// The method that this weak handler invokes.
        /// </summary>
        MethodInfo IWeakEventInvocation.invocationMethod => m_Method;

        object IWeakEventInvocation.invocationOwner => currentOwner;

        /// <summary>
        /// The owner that controls the lifecycle of this handler, or null when it was already collected.
        /// It takes part in the equality because two providers may invoke the same method.
        /// </summary>
        private object currentOwner => m_Owner.TryGetTarget(out var owner) ? owner : null;

        /// <summary>Whether the provider that owns this handler is still alive.</summary>
        public bool isAlive => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.isAlive;

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="owner">The owner that control this weak event's lifecycle.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> delegation, UnityEngine.Object owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (delegation is null)
            {
                throw new ArgumentNullException(nameof(delegation));
            }
            if (delegation.Target is null)
            {
                throw new ArgumentException("A weak subscription requires a delegate that targets an instance, a static method has no owner to keep alive.", nameof(delegation));
            }
            m_Owner = new WeakReference<UnityEngine.Object>(owner);
            m_Method = delegation.Method;
            var invokerType = typeof(ActionInvoker<>).MakeGenericType(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10),
                typeof(T11), typeof(T12), delegation.Target.GetType());
            m_Invocation = Activator.CreateInstance(invokerType, delegation.Target, delegation) as IInvocation;
        }

        /// <inheritdoc/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> notification) => m_Owner.TryGetTarget(out var owner) && owner != null &&
                                                                                                                           m_Invocation.Invoke(notification.item1, notification.item2,
                                                                                                                               notification.item3, notification.item4, notification.item5,
                                                                                                                               notification.item6, notification.item7, notification.item8,
                                                                                                                               notification.item9, notification.item10, notification.item11,
                                                                                                                               notification.item12);

        /// <summary>Try to handle the notification and report whether the provider is still alive.</summary>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12) =>
            m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> notification)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8,
                    notification.item9, notification.item10, notification.item11, notification.item12);
            }
        }

        /// <summary>Handle the notification when the provider is still alive.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Method != null ? m_Method.GetHashCode() : 0) * 397 ^ (currentOwner != null ? currentOwner.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> other) =>
            other is not null && m_Method == other.m_Method && Equals(currentOwner, other.currentOwner);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action => action.Method == m_Method && Equals(action.Target, currentOwner),
            IEventInvocation invocation => invocation.invocationMethod == m_Method && Equals(invocation.invocationOwner, currentOwner),
            _ => false
        };

        private interface IInvocation
        {
            /// <summary>
            /// Whether the event provider that this invocation targets is still alive.
            /// </summary>
            bool isAlive { get; }

            bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12);
        }

        private sealed class ActionInvoker<TProvider> : IInvocation where TProvider : class
        {
            /// <summary>
            /// The event provider.
            /// </summary>
            private readonly WeakReference<TProvider> m_Provider;

            /// <summary>
            /// Wrapped action.
            /// </summary>
            private readonly Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> m_Invocation;

            public ActionInvoker(TProvider provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
            {
                m_Provider = new WeakReference<TProvider>(provider);
                m_Invocation =
                    action.Method.CreateDelegate(typeof(Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>)) as Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>;
            }

            /// <summary>
            /// Whether the wrapped event provider is still alive.
            /// </summary>
            public bool isAlive => m_Provider.TryGetTarget(out _);

            public bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12)
            {
                if (!m_Provider.TryGetTarget(out var provider))
                {
                    return false;
                }
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);
                return true;
            }
        }
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    public sealed class WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>,
        IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>, IWeakEventInvocation,
        IEquatable<WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>
    {
        [Preserve]
        private static ActionInvoker<object> s_Preserve;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly IInvocation m_Invocation;

        /// <summary>
        /// The owner that control this weak event's lifecycle.
        /// </summary>
        private readonly WeakReference<UnityEngine.Object> m_Owner;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <summary>
        /// The method that this weak handler invokes.
        /// </summary>
        MethodInfo IWeakEventInvocation.invocationMethod => m_Method;

        object IWeakEventInvocation.invocationOwner => currentOwner;

        /// <summary>
        /// The owner that controls the lifecycle of this handler, or null when it was already collected.
        /// It takes part in the equality because two providers may invoke the same method.
        /// </summary>
        private object currentOwner => m_Owner.TryGetTarget(out var owner) ? owner : null;

        /// <summary>Whether the provider that owns this handler is still alive.</summary>
        public bool isAlive => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.isAlive;

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="owner">The owner that control this weak event's lifecycle.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> delegation, UnityEngine.Object owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (delegation is null)
            {
                throw new ArgumentNullException(nameof(delegation));
            }
            if (delegation.Target is null)
            {
                throw new ArgumentException("A weak subscription requires a delegate that targets an instance, a static method has no owner to keep alive.", nameof(delegation));
            }
            m_Owner = new WeakReference<UnityEngine.Object>(owner);
            m_Method = delegation.Method;
            var invokerType = typeof(ActionInvoker<>).MakeGenericType(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10),
                typeof(T11), typeof(T12), typeof(T13), delegation.Target.GetType());
            m_Invocation = Activator.CreateInstance(invokerType, delegation.Target, delegation) as IInvocation;
        }

        /// <inheritdoc/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> notification) => m_Owner.TryGetTarget(out var owner) && owner != null &&
                                                                                                                                m_Invocation.Invoke(notification.item1, notification.item2,
                                                                                                                                    notification.item3, notification.item4, notification.item5,
                                                                                                                                    notification.item6, notification.item7, notification.item8,
                                                                                                                                    notification.item9, notification.item10, notification.item11,
                                                                                                                                    notification.item12, notification.item13);

        /// <summary>Try to handle the notification and report whether the provider is still alive.</summary>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13) =>
            m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> notification)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8,
                    notification.item9, notification.item10, notification.item11, notification.item12, notification.item13);
            }
        }

        /// <summary>Handle the notification when the provider is still alive.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Method != null ? m_Method.GetHashCode() : 0) * 397 ^ (currentOwner != null ? currentOwner.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> other) =>
            other is not null && m_Method == other.m_Method && Equals(currentOwner, other.currentOwner);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action => action.Method == m_Method && Equals(action.Target, currentOwner),
            IEventInvocation invocation => invocation.invocationMethod == m_Method && Equals(invocation.invocationOwner, currentOwner),
            _ => false
        };

        private interface IInvocation
        {
            /// <summary>
            /// Whether the event provider that this invocation targets is still alive.
            /// </summary>
            bool isAlive { get; }

            bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13);
        }

        private sealed class ActionInvoker<TProvider> : IInvocation where TProvider : class
        {
            /// <summary>
            /// The event provider.
            /// </summary>
            private readonly WeakReference<TProvider> m_Provider;

            /// <summary>
            /// Wrapped action.
            /// </summary>
            private readonly Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> m_Invocation;

            public ActionInvoker(TProvider provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
            {
                m_Provider = new WeakReference<TProvider>(provider);
                m_Invocation =
                    action.Method.CreateDelegate(typeof(Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>)) as
                        Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>;
            }

            /// <summary>
            /// Whether the wrapped event provider is still alive.
            /// </summary>
            public bool isAlive => m_Provider.TryGetTarget(out _);

            public bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13)
            {
                if (!m_Provider.TryGetTarget(out var provider))
                {
                    return false;
                }
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);
                return true;
            }
        }
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    public sealed class WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> :
        IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>,
        IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>, IWeakEventInvocation,
        IEquatable<WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>
    {
        [Preserve]
        private static ActionInvoker<object> s_Preserve;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly IInvocation m_Invocation;

        /// <summary>
        /// The owner that control this weak event's lifecycle.
        /// </summary>
        private readonly WeakReference<UnityEngine.Object> m_Owner;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <summary>
        /// The method that this weak handler invokes.
        /// </summary>
        MethodInfo IWeakEventInvocation.invocationMethod => m_Method;

        object IWeakEventInvocation.invocationOwner => currentOwner;

        /// <summary>
        /// The owner that controls the lifecycle of this handler, or null when it was already collected.
        /// It takes part in the equality because two providers may invoke the same method.
        /// </summary>
        private object currentOwner => m_Owner.TryGetTarget(out var owner) ? owner : null;

        /// <summary>Whether the provider that owns this handler is still alive.</summary>
        public bool isAlive => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.isAlive;

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="owner">The owner that control this weak event's lifecycle.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> delegation, UnityEngine.Object owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (delegation is null)
            {
                throw new ArgumentNullException(nameof(delegation));
            }
            if (delegation.Target is null)
            {
                throw new ArgumentException("A weak subscription requires a delegate that targets an instance, a static method has no owner to keep alive.", nameof(delegation));
            }
            m_Owner = new WeakReference<UnityEngine.Object>(owner);
            m_Method = delegation.Method;
            var invokerType = typeof(ActionInvoker<>).MakeGenericType(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10),
                typeof(T11), typeof(T12), typeof(T13), typeof(T14), delegation.Target.GetType());
            m_Invocation = Activator.CreateInstance(invokerType, delegation.Target, delegation) as IInvocation;
        }

        /// <inheritdoc/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> notification) => m_Owner.TryGetTarget(out var owner) && owner != null &&
            m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8,
                notification.item9, notification.item10, notification.item11, notification.item12, notification.item13, notification.item14);

        /// <summary>Try to handle the notification and report whether the provider is still alive.</summary>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14) =>
            m_Owner.TryGetTarget(out var owner) && owner != null &&
            m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> notification)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8,
                    notification.item9, notification.item10, notification.item11, notification.item12, notification.item13, notification.item14);
            }
        }

        /// <summary>Handle the notification when the provider is still alive.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Method != null ? m_Method.GetHashCode() : 0) * 397 ^ (currentOwner != null ? currentOwner.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> other) =>
            other is not null && m_Method == other.m_Method && Equals(currentOwner, other.currentOwner);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action => action.Method == m_Method && Equals(action.Target, currentOwner),
            IEventInvocation invocation => invocation.invocationMethod == m_Method && Equals(invocation.invocationOwner, currentOwner),
            _ => false
        };

        private interface IInvocation
        {
            /// <summary>
            /// Whether the event provider that this invocation targets is still alive.
            /// </summary>
            bool isAlive { get; }

            bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14);
        }

        private sealed class ActionInvoker<TProvider> : IInvocation where TProvider : class
        {
            /// <summary>
            /// The event provider.
            /// </summary>
            private readonly WeakReference<TProvider> m_Provider;

            /// <summary>
            /// Wrapped action.
            /// </summary>
            private readonly Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> m_Invocation;

            public ActionInvoker(TProvider provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
            {
                m_Provider = new WeakReference<TProvider>(provider);
                m_Invocation =
                    action.Method.CreateDelegate(typeof(Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>)) as
                        Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>;
            }

            /// <summary>
            /// Whether the wrapped event provider is still alive.
            /// </summary>
            public bool isAlive => m_Provider.TryGetTarget(out _);

            public bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14)
            {
                if (!m_Provider.TryGetTarget(out var provider))
                {
                    return false;
                }
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);
                return true;
            }
        }
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    public sealed class WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> :
        IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>,
        IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>, IWeakEventInvocation,
        IEquatable<WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>
    {
        [Preserve]
        private static ActionInvoker<object> s_Preserve;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly IInvocation m_Invocation;

        /// <summary>
        /// The owner that control this weak event's lifecycle.
        /// </summary>
        private readonly WeakReference<UnityEngine.Object> m_Owner;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <summary>
        /// The method that this weak handler invokes.
        /// </summary>
        MethodInfo IWeakEventInvocation.invocationMethod => m_Method;

        object IWeakEventInvocation.invocationOwner => currentOwner;

        /// <summary>
        /// The owner that controls the lifecycle of this handler, or null when it was already collected.
        /// It takes part in the equality because two providers may invoke the same method.
        /// </summary>
        private object currentOwner => m_Owner.TryGetTarget(out var owner) ? owner : null;

        /// <summary>Whether the provider that owns this handler is still alive.</summary>
        public bool isAlive => m_Owner.TryGetTarget(out var owner) && owner != null && m_Invocation.isAlive;

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="owner">The owner that control this weak event's lifecycle.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> delegation, UnityEngine.Object owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (delegation is null)
            {
                throw new ArgumentNullException(nameof(delegation));
            }
            if (delegation.Target is null)
            {
                throw new ArgumentException("A weak subscription requires a delegate that targets an instance, a static method has no owner to keep alive.", nameof(delegation));
            }
            m_Owner = new WeakReference<UnityEngine.Object>(owner);
            m_Method = delegation.Method;
            var invokerType = typeof(ActionInvoker<>).MakeGenericType(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10),
                typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), delegation.Target.GetType());
            m_Invocation = Activator.CreateInstance(invokerType, delegation.Target, delegation) as IInvocation;
        }

        /// <inheritdoc/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> notification) => m_Owner.TryGetTarget(out var owner) && owner != null &&
            m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8,
                notification.item9, notification.item10, notification.item11, notification.item12, notification.item13, notification.item14, notification.item15);

        /// <summary>Try to handle the notification and report whether the provider is still alive.</summary>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14,
            T15 param15) => m_Owner.TryGetTarget(out var owner) && owner != null &&
                            m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> notification)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8,
                    notification.item9, notification.item10, notification.item11, notification.item12, notification.item13, notification.item14, notification.item15);
            }
        }

        /// <summary>Handle the notification when the provider is still alive.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14,
            T15 param15)
        {
            if (m_Owner.TryGetTarget(out var owner) && owner != null)
            {
                m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Method != null ? m_Method.GetHashCode() : 0) * 397 ^ (currentOwner != null ? currentOwner.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> other) =>
            other is not null && m_Method == other.m_Method && Equals(currentOwner, other.currentOwner);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action => action.Method == m_Method && Equals(action.Target, currentOwner),
            IEventInvocation invocation => invocation.invocationMethod == m_Method && Equals(invocation.invocationOwner, currentOwner),
            _ => false
        };

        private interface IInvocation
        {
            /// <summary>
            /// Whether the event provider that this invocation targets is still alive.
            /// </summary>
            bool isAlive { get; }

            bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14,
                T15 param15);
        }

        private sealed class ActionInvoker<TProvider> : IInvocation where TProvider : class
        {
            /// <summary>
            /// The event provider.
            /// </summary>
            private readonly WeakReference<TProvider> m_Provider;

            /// <summary>
            /// Wrapped action.
            /// </summary>
            private readonly Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> m_Invocation;

            public ActionInvoker(TProvider provider, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
            {
                m_Provider = new WeakReference<TProvider>(provider);
                m_Invocation =
                    action.Method.CreateDelegate(typeof(Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>)) as
                        Action<TProvider, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>;
            }

            /// <summary>
            /// Whether the wrapped event provider is still alive.
            /// </summary>
            public bool isAlive => m_Provider.TryGetTarget(out _);

            public bool Invoke(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14,
                T15 param15)
            {
                if (!m_Provider.TryGetTarget(out var provider))
                {
                    return false;
                }
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15);
                return true;
            }
        }
    }
}