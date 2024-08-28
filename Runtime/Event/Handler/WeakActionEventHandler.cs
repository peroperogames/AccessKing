/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/12/05 16:12:42
 */

using System;
using System.Reflection;
using UnityEngine.Assertions;

#pragma warning disable CS1712 // Type parameter has no matching typeparam tag in the XML comment (but other type parameters do)

// ReSharper disable InvalidXmlDocComment
namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    /// <typeparam name="TEventSource">Event provider which would be referenced by handler.</typeparam>
    public sealed class WeakActionEventHandler<TEventSource> : IEventHandler, IWeakEventHandler, IEquatable<WeakActionEventHandler<TEventSource>> where TEventSource : class
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<TEventSource> m_Invocation;

        /// <summary>
        /// The event provider.
        /// </summary>
        private readonly WeakReference<TEventSource> m_WeakEventProvider;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.isAlive"/>
        public bool isAlive => m_WeakEventProvider.TryGetReference(out _);

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        public WeakActionEventHandler(Action delegation, TEventSource provider)
        {
            m_WeakEventProvider = new WeakReference<TEventSource>(provider);
            var method = delegation.Method;
            Assert.IsFalse(method.IsStatic, "The weak delegate can't be static.");
            Assert.AreEqual(provider.GetType(), delegation.Target.GetType(), "Invalid provider. The delegate target should have the same type as the provider.");
            m_Invocation = method.CreateDelegate(typeof(Action<TEventSource>)) as Action<TEventSource>;
            m_Method = method;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(in Empty notification)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider);
            return true;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle()
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider);
            return true;
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(in Empty notification)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider);
            }
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle()
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<TEventSource> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<TEventSource> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<TEventSource> other) => m_Method == other?.m_Method;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<TEventSource> other => Equals(other),
            Action action => action.Method == m_Method,
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    /// <typeparam name="TEventSource">Event provider which would be referenced by handler.</typeparam>
    public sealed class WeakActionEventHandler<TEventSource, T> : IEventHandler<ParameterNotification<T>>, IWeakEventHandler<ParameterNotification<T>>, IEquatable<WeakActionEventHandler<TEventSource, T>> where TEventSource : class
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<TEventSource, T> m_Invocation;

        /// <summary>
        /// The event provider.
        /// </summary>
        private readonly WeakReference<TEventSource> m_WeakEventProvider;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.isAlive"/>
        public bool isAlive => m_WeakEventProvider.TryGetReference(out _);

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        public WeakActionEventHandler(Action<T> delegation, TEventSource provider)
        {
            m_WeakEventProvider = new WeakReference<TEventSource>(provider);
            var method = delegation.Method;
            Assert.IsFalse(method.IsStatic, "The weak delegate can't be static.");
            Assert.AreEqual(provider.GetType(), delegation.Target.GetType(), "Invalid provider. The delegate target should have the same type as the provider.");
            m_Invocation = method.CreateDelegate(typeof(Action<TEventSource, T>)) as Action<TEventSource, T>;
            m_Method = method;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(in ParameterNotification<T> notification)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, notification.item);
            return true;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(T param)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, param);
            return true;
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(in ParameterNotification<T> notification)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, notification.item);
            }
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(T param)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, param);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<TEventSource, T> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<TEventSource, T> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<TEventSource, T> other) => m_Method == other?.m_Method;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<TEventSource, T> other => Equals(other),
            Action<T> action => action.Method == m_Method,
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    /// <typeparam name="TEventSource">Event provider which would be referenced by handler.</typeparam>
    public sealed class WeakActionEventHandler<TEventSource, T1, T2> : IEventHandler<ParameterNotification<T1, T2>>, IWeakEventHandler<ParameterNotification<T1, T2>>, IEquatable<WeakActionEventHandler<TEventSource, T1, T2>> where TEventSource : class
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<TEventSource, T1, T2> m_Invocation;

        /// <summary>
        /// The event provider.
        /// </summary>
        private readonly WeakReference<TEventSource> m_WeakEventProvider;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.isAlive"/>
        public bool isAlive => m_WeakEventProvider.TryGetReference(out _);

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        public WeakActionEventHandler(Action<T1, T2> delegation, TEventSource provider)
        {
            m_WeakEventProvider = new WeakReference<TEventSource>(provider);
            var method = delegation.Method;
            Assert.IsFalse(method.IsStatic, "The weak delegate can't be static.");
            Assert.AreEqual(provider.GetType(), delegation.Target.GetType(), "Invalid provider. The delegate target should have the same type as the provider.");
            m_Invocation = method.CreateDelegate(typeof(Action<TEventSource, T1, T2>)) as Action<TEventSource, T1, T2>;
            m_Method = method;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(in ParameterNotification<T1, T2> notification)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, notification.item1, notification.item2);
            return true;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(T1 param1, T2 param2)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, param1, param2);
            return true;
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(in ParameterNotification<T1, T2> notification)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, notification.item1, notification.item2);
            }
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(T1 param1, T2 param2)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, param1, param2);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<TEventSource, T1, T2> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<TEventSource, T1, T2> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<TEventSource, T1, T2> other) => m_Method == other?.m_Method;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<TEventSource, T1, T2> other => Equals(other),
            Action<T1, T2> action => action.Method == m_Method,
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    /// <typeparam name="TEventSource">Event provider which would be referenced by handler.</typeparam>
    public sealed class WeakActionEventHandler<TEventSource, T1, T2, T3> : IEventHandler<ParameterNotification<T1, T2, T3>>, IWeakEventHandler<ParameterNotification<T1, T2, T3>>, IEquatable<WeakActionEventHandler<TEventSource, T1, T2, T3>> where TEventSource : class
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<TEventSource, T1, T2, T3> m_Invocation;

        /// <summary>
        /// The event provider.
        /// </summary>
        private readonly WeakReference<TEventSource> m_WeakEventProvider;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.isAlive"/>
        public bool isAlive => m_WeakEventProvider.TryGetReference(out _);

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        public WeakActionEventHandler(Action<T1, T2, T3> delegation, TEventSource provider)
        {
            m_WeakEventProvider = new WeakReference<TEventSource>(provider);
            var method = delegation.Method;
            Assert.IsFalse(method.IsStatic, "The weak delegate can't be static.");
            Assert.AreEqual(provider.GetType(), delegation.Target.GetType(), "Invalid provider. The delegate target should have the same type as the provider.");
            m_Invocation = method.CreateDelegate(typeof(Action<TEventSource, T1, T2, T3>)) as Action<TEventSource, T1, T2, T3>;
            m_Method = method;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3> notification)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3);
            return true;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(T1 param1, T2 param2, T3 param3)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, param1, param2, param3);
            return true;
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(in ParameterNotification<T1, T2, T3> notification)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3);
            }
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, param1, param2, param3);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<TEventSource, T1, T2, T3> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<TEventSource, T1, T2, T3> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<TEventSource, T1, T2, T3> other) => m_Method == other?.m_Method;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<TEventSource, T1, T2, T3> other => Equals(other),
            Action<T1, T2, T3> action => action.Method == m_Method,
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    /// <typeparam name="TEventSource">Event provider which would be referenced by handler.</typeparam>
    public sealed class WeakActionEventHandler<TEventSource, T1, T2, T3, T4> : IEventHandler<ParameterNotification<T1, T2, T3, T4>>, IWeakEventHandler<ParameterNotification<T1, T2, T3, T4>>, IEquatable<WeakActionEventHandler<TEventSource, T1, T2, T3, T4>> where TEventSource : class
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<TEventSource, T1, T2, T3, T4> m_Invocation;

        /// <summary>
        /// The event provider.
        /// </summary>
        private readonly WeakReference<TEventSource> m_WeakEventProvider;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.isAlive"/>
        public bool isAlive => m_WeakEventProvider.TryGetReference(out _);

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4> delegation, TEventSource provider)
        {
            m_WeakEventProvider = new WeakReference<TEventSource>(provider);
            var method = delegation.Method;
            Assert.IsFalse(method.IsStatic, "The weak delegate can't be static.");
            Assert.AreEqual(provider.GetType(), delegation.Target.GetType(), "Invalid provider. The delegate target should have the same type as the provider.");
            m_Invocation = method.CreateDelegate(typeof(Action<TEventSource, T1, T2, T3, T4>)) as Action<TEventSource, T1, T2, T3, T4>;
            m_Method = method;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4> notification)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4);
            return true;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, param1, param2, param3, param4);
            return true;
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4> notification)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4);
            }
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, param1, param2, param3, param4);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<TEventSource, T1, T2, T3, T4> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<TEventSource, T1, T2, T3, T4> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<TEventSource, T1, T2, T3, T4> other) => m_Method == other?.m_Method;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<TEventSource, T1, T2, T3, T4> other => Equals(other),
            Action<T1, T2, T3, T4> action => action.Method == m_Method,
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    /// <typeparam name="TEventSource">Event provider which would be referenced by handler.</typeparam>
    public sealed class WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5>>, IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5>>, IEquatable<WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5>> where TEventSource : class
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<TEventSource, T1, T2, T3, T4, T5> m_Invocation;

        /// <summary>
        /// The event provider.
        /// </summary>
        private readonly WeakReference<TEventSource> m_WeakEventProvider;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.isAlive"/>
        public bool isAlive => m_WeakEventProvider.TryGetReference(out _);

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5> delegation, TEventSource provider)
        {
            m_WeakEventProvider = new WeakReference<TEventSource>(provider);
            var method = delegation.Method;
            Assert.IsFalse(method.IsStatic, "The weak delegate can't be static.");
            Assert.AreEqual(provider.GetType(), delegation.Target.GetType(), "Invalid provider. The delegate target should have the same type as the provider.");
            m_Invocation = method.CreateDelegate(typeof(Action<TEventSource, T1, T2, T3, T4, T5>)) as Action<TEventSource, T1, T2, T3, T4, T5>;
            m_Method = method;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5> notification)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5);
            return true;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, param1, param2, param3, param4, param5);
            return true;
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5> notification)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5);
            }
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5> other) => m_Method == other?.m_Method;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5> other => Equals(other),
            Action<T1, T2, T3, T4, T5> action => action.Method == m_Method,
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    /// <typeparam name="TEventSource">Event provider which would be referenced by handler.</typeparam>
    public sealed class WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6>>, IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6>>, IEquatable<WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6>> where TEventSource : class
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<TEventSource, T1, T2, T3, T4, T5, T6> m_Invocation;

        /// <summary>
        /// The event provider.
        /// </summary>
        private readonly WeakReference<TEventSource> m_WeakEventProvider;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.isAlive"/>
        public bool isAlive => m_WeakEventProvider.TryGetReference(out _);

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6> delegation, TEventSource provider)
        {
            m_WeakEventProvider = new WeakReference<TEventSource>(provider);
            var method = delegation.Method;
            Assert.IsFalse(method.IsStatic, "The weak delegate can't be static.");
            Assert.AreEqual(provider.GetType(), delegation.Target.GetType(), "Invalid provider. The delegate target should have the same type as the provider.");
            m_Invocation = method.CreateDelegate(typeof(Action<TEventSource, T1, T2, T3, T4, T5, T6>)) as Action<TEventSource, T1, T2, T3, T4, T5, T6>;
            m_Method = method;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6> notification)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6);
            return true;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6);
            return true;
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6> notification)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6);
            }
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6> other) => m_Method == other?.m_Method;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6> action => action.Method == m_Method,
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    /// <typeparam name="TEventSource">Event provider which would be referenced by handler.</typeparam>
    public sealed class WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7>>, IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7>>, IEquatable<WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7>> where TEventSource : class
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<TEventSource, T1, T2, T3, T4, T5, T6, T7> m_Invocation;

        /// <summary>
        /// The event provider.
        /// </summary>
        private readonly WeakReference<TEventSource> m_WeakEventProvider;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.isAlive"/>
        public bool isAlive => m_WeakEventProvider.TryGetReference(out _);

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7> delegation, TEventSource provider)
        {
            m_WeakEventProvider = new WeakReference<TEventSource>(provider);
            var method = delegation.Method;
            Assert.IsFalse(method.IsStatic, "The weak delegate can't be static.");
            Assert.AreEqual(provider.GetType(), delegation.Target.GetType(), "Invalid provider. The delegate target should have the same type as the provider.");
            m_Invocation = method.CreateDelegate(typeof(Action<TEventSource, T1, T2, T3, T4, T5, T6, T7>)) as Action<TEventSource, T1, T2, T3, T4, T5, T6, T7>;
            m_Method = method;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7> notification)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7);
            return true;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7);
            return true;
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7> notification)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7);
            }
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7> other) => m_Method == other?.m_Method;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7> action => action.Method == m_Method,
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    /// <typeparam name="TEventSource">Event provider which would be referenced by handler.</typeparam>
    public sealed class WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>>, IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>>, IEquatable<WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8>> where TEventSource : class
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8> m_Invocation;

        /// <summary>
        /// The event provider.
        /// </summary>
        private readonly WeakReference<TEventSource> m_WeakEventProvider;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.isAlive"/>
        public bool isAlive => m_WeakEventProvider.TryGetReference(out _);

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8> delegation, TEventSource provider)
        {
            m_WeakEventProvider = new WeakReference<TEventSource>(provider);
            var method = delegation.Method;
            Assert.IsFalse(method.IsStatic, "The weak delegate can't be static.");
            Assert.AreEqual(provider.GetType(), delegation.Target.GetType(), "Invalid provider. The delegate target should have the same type as the provider.");
            m_Invocation = method.CreateDelegate(typeof(Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8>)) as Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8>;
            m_Method = method;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8> notification)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8);
            return true;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8);
            return true;
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8> notification)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8);
            }
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8> other) => m_Method == other?.m_Method;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8> action => action.Method == m_Method,
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    /// <typeparam name="TEventSource">Event provider which would be referenced by handler.</typeparam>
    public sealed class WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9>>, IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9>>, IEquatable<WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9>> where TEventSource : class
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9> m_Invocation;

        /// <summary>
        /// The event provider.
        /// </summary>
        private readonly WeakReference<TEventSource> m_WeakEventProvider;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.isAlive"/>
        public bool isAlive => m_WeakEventProvider.TryGetReference(out _);

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> delegation, TEventSource provider)
        {
            m_WeakEventProvider = new WeakReference<TEventSource>(provider);
            var method = delegation.Method;
            Assert.IsFalse(method.IsStatic, "The weak delegate can't be static.");
            Assert.AreEqual(provider.GetType(), delegation.Target.GetType(), "Invalid provider. The delegate target should have the same type as the provider.");
            m_Invocation = method.CreateDelegate(typeof(Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9>)) as Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9>;
            m_Method = method;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9> notification)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9);
            return true;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9);
            return true;
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9> notification)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9);
            }
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9> other) => m_Method == other?.m_Method;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action => action.Method == m_Method,
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    /// <typeparam name="TEventSource">Event provider which would be referenced by handler.</typeparam>
    public sealed class WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>, IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>, IEquatable<WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> where TEventSource : class
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> m_Invocation;

        /// <summary>
        /// The event provider.
        /// </summary>
        private readonly WeakReference<TEventSource> m_WeakEventProvider;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.isAlive"/>
        public bool isAlive => m_WeakEventProvider.TryGetReference(out _);

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> delegation, TEventSource provider)
        {
            m_WeakEventProvider = new WeakReference<TEventSource>(provider);
            var method = delegation.Method;
            Assert.IsFalse(method.IsStatic, "The weak delegate can't be static.");
            Assert.AreEqual(provider.GetType(), delegation.Target.GetType(), "Invalid provider. The delegate target should have the same type as the provider.");
            m_Invocation = method.CreateDelegate(typeof(Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>)) as Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>;
            m_Method = method;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> notification)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10);
            return true;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);
            return true;
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> notification)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10);
            }
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> other) => m_Method == other?.m_Method;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action => action.Method == m_Method,
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    /// <typeparam name="TEventSource">Event provider which would be referenced by handler.</typeparam>
    public sealed class WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>, IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>, IEquatable<WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> where TEventSource : class
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> m_Invocation;

        /// <summary>
        /// The event provider.
        /// </summary>
        private readonly WeakReference<TEventSource> m_WeakEventProvider;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.isAlive"/>
        public bool isAlive => m_WeakEventProvider.TryGetReference(out _);

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> delegation, TEventSource provider)
        {
            m_WeakEventProvider = new WeakReference<TEventSource>(provider);
            var method = delegation.Method;
            Assert.IsFalse(method.IsStatic, "The weak delegate can't be static.");
            Assert.AreEqual(provider.GetType(), delegation.Target.GetType(), "Invalid provider. The delegate target should have the same type as the provider.");
            m_Invocation = method.CreateDelegate(typeof(Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>)) as Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>;
            m_Method = method;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> notification)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11);
            return true;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);
            return true;
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> notification)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11);
            }
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> other) => m_Method == other?.m_Method;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action => action.Method == m_Method,
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    /// <typeparam name="TEventSource">Event provider which would be referenced by handler.</typeparam>
    public sealed class WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>, IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>, IEquatable<WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> where TEventSource : class
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> m_Invocation;

        /// <summary>
        /// The event provider.
        /// </summary>
        private readonly WeakReference<TEventSource> m_WeakEventProvider;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.isAlive"/>
        public bool isAlive => m_WeakEventProvider.TryGetReference(out _);

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> delegation, TEventSource provider)
        {
            m_WeakEventProvider = new WeakReference<TEventSource>(provider);
            var method = delegation.Method;
            Assert.IsFalse(method.IsStatic, "The weak delegate can't be static.");
            Assert.AreEqual(provider.GetType(), delegation.Target.GetType(), "Invalid provider. The delegate target should have the same type as the provider.");
            m_Invocation = method.CreateDelegate(typeof(Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>)) as Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>;
            m_Method = method;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> notification)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12);
            return true;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);
            return true;
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> notification)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12);
            }
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> other) => m_Method == other?.m_Method;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action => action.Method == m_Method,
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    /// <typeparam name="TEventSource">Event provider which would be referenced by handler.</typeparam>
    public sealed class WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>, IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>, IEquatable<WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> where TEventSource : class
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> m_Invocation;

        /// <summary>
        /// The event provider.
        /// </summary>
        private readonly WeakReference<TEventSource> m_WeakEventProvider;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.isAlive"/>
        public bool isAlive => m_WeakEventProvider.TryGetReference(out _);

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> delegation, TEventSource provider)
        {
            m_WeakEventProvider = new WeakReference<TEventSource>(provider);
            var method = delegation.Method;
            Assert.IsFalse(method.IsStatic, "The weak delegate can't be static.");
            Assert.AreEqual(provider.GetType(), delegation.Target.GetType(), "Invalid provider. The delegate target should have the same type as the provider.");
            m_Invocation = method.CreateDelegate(typeof(Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>)) as Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>;
            m_Method = method;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> notification)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13);
            return true;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);
            return true;
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> notification)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13);
            }
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> other) => m_Method == other?.m_Method;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action => action.Method == m_Method,
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    /// <typeparam name="TEventSource">Event provider which would be referenced by handler.</typeparam>
    public sealed class WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>, IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>, IEquatable<WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> where TEventSource : class
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> m_Invocation;

        /// <summary>
        /// The event provider.
        /// </summary>
        private readonly WeakReference<TEventSource> m_WeakEventProvider;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.isAlive"/>
        public bool isAlive => m_WeakEventProvider.TryGetReference(out _);

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> delegation, TEventSource provider)
        {
            m_WeakEventProvider = new WeakReference<TEventSource>(provider);
            var method = delegation.Method;
            Assert.IsFalse(method.IsStatic, "The weak delegate can't be static.");
            Assert.AreEqual(provider.GetType(), delegation.Target.GetType(), "Invalid provider. The delegate target should have the same type as the provider.");
            m_Invocation = method.CreateDelegate(typeof(Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>)) as Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>;
            m_Method = method;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> notification)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13, notification.item14);
            return true;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);
            return true;
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> notification)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13, notification.item14);
            }
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> other) => m_Method == other?.m_Method;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action => action.Method == m_Method,
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action which would reference the event provider by weak.
    /// </summary>
    /// <typeparam name="TEventSource">Event provider which would be referenced by handler.</typeparam>
    public sealed class WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>, IWeakEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>, IEquatable<WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> where TEventSource : class
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> m_Invocation;

        /// <summary>
        /// The event provider.
        /// </summary>
        private readonly WeakReference<TEventSource> m_WeakEventProvider;

        /// <summary>
        /// Raw method of the event provider.
        /// </summary>
        private readonly MethodInfo m_Method;

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.isAlive"/>
        public bool isAlive => m_WeakEventProvider.TryGetReference(out _);

        /// <summary>
        /// Create a weak event handler from a System.Action.
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        /// <param name="provider">The event provider which should contains the delegation that from instance method.</param>
        public WeakActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> delegation, TEventSource provider)
        {
            m_WeakEventProvider = new WeakReference<TEventSource>(provider);
            var method = delegation.Method;
            Assert.IsFalse(method.IsStatic, "The weak delegate can't be static.");
            Assert.AreEqual(provider.GetType(), delegation.Target.GetType(), "Invalid provider. The delegate target should have the same type as the provider.");
            m_Invocation = method.CreateDelegate(typeof(Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>)) as Action<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>;
            m_Method = method;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> notification)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13, notification.item14, notification.item15);
            return true;
        }

        /// <inheritdoc cref="IWeakEventHandler{TNotification}.TryHandle"/>
        public bool TryHandle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14, T15 param15)
        {
            if (!m_WeakEventProvider.TryGetReference(out var provider))
            {
                return false;
            }
            m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15);
            return true;
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> notification)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13, notification.item14, notification.item15);
            }
        }

        /// <inheritdoc cref="IEventHandler{TNotification}.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14, T15 param15)
        {
            if (m_WeakEventProvider.TryGetReference(out var provider))
            {
                m_Invocation.Invoke(provider, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15);
            }
        }

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> other) => m_Method == other?.m_Method;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            WeakActionEventHandler<TEventSource, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action => action.Method == m_Method,
            _ => false
        };
    }
}