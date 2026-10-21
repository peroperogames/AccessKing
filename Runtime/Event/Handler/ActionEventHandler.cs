/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/05/26 15:05:25
 */

using System;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler : IEventHandler, IEventInvocation, IEquatable<ActionEventHandler>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle() => m_Invocation?.Invoke();

        /// <inheritdoc/>
        public void Handle(in Empty notification) => Handle();

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler(Action delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler other => Equals(other),
            Action action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler<T> : IEventHandler<ParameterNotification<T>>, IEventInvocation, IEquatable<ActionEventHandler<T>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T> m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action<T> delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle(T param) => m_Invocation?.Invoke(param);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T> notification) => Handle(notification.item);

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler<T>(Action<T> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler<T> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler<T> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler<T> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler<T> other => Equals(other),
            Action<T> action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler<T1, T2> : IEventHandler<ParameterNotification<T1, T2>>, IEventInvocation, IEquatable<ActionEventHandler<T1, T2>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2> m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action<T1, T2> delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle(T1 param1, T2 param2) => m_Invocation?.Invoke(param1, param2);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2> notification) => Handle(notification.item1, notification.item2);

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler<T1, T2>(Action<T1, T2> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler<T1, T2> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler<T1, T2> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler<T1, T2> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler<T1, T2> other => Equals(other),
            Action<T1, T2> action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler<T1, T2, T3> : IEventHandler<ParameterNotification<T1, T2, T3>>, IEventInvocation, IEquatable<ActionEventHandler<T1, T2, T3>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3> m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action<T1, T2, T3> delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3) => m_Invocation?.Invoke(param1, param2, param3);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3> notification) => Handle(notification.item1, notification.item2, notification.item3);

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler<T1, T2, T3>(Action<T1, T2, T3> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler<T1, T2, T3> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler<T1, T2, T3> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler<T1, T2, T3> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler<T1, T2, T3> other => Equals(other),
            Action<T1, T2, T3> action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler<T1, T2, T3, T4> : IEventHandler<ParameterNotification<T1, T2, T3, T4>>, IEventInvocation, IEquatable<ActionEventHandler<T1, T2, T3, T4>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4> m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action<T1, T2, T3, T4> delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4) => m_Invocation?.Invoke(param1, param2, param3, param4);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4);

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler<T1, T2, T3, T4>(Action<T1, T2, T3, T4> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler<T1, T2, T3, T4> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler<T1, T2, T3, T4> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler<T1, T2, T3, T4> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler<T1, T2, T3, T4> other => Equals(other),
            Action<T1, T2, T3, T4> action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler<T1, T2, T3, T4, T5> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5>>, IEventInvocation, IEquatable<ActionEventHandler<T1, T2, T3, T4, T5>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5> m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action<T1, T2, T3, T4, T5> delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5) => m_Invocation?.Invoke(param1, param2, param3, param4, param5);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5);

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler<T1, T2, T3, T4, T5> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler<T1, T2, T3, T4, T5> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler<T1, T2, T3, T4, T5> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler<T1, T2, T3, T4, T5> other => Equals(other),
            Action<T1, T2, T3, T4, T5> action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler<T1, T2, T3, T4, T5, T6> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6>>, IEventInvocation, IEquatable<ActionEventHandler<T1, T2, T3, T4, T5, T6>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6> m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action<T1, T2, T3, T4, T5, T6> delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6);

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler<T1, T2, T3, T4, T5, T6> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler<T1, T2, T3, T4, T5, T6> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler<T1, T2, T3, T4, T5, T6> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler<T1, T2, T3, T4, T5, T6> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6> action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler<T1, T2, T3, T4, T5, T6, T7> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7>>, IEventInvocation, IEquatable<ActionEventHandler<T1, T2, T3, T4, T5, T6, T7>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7> m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7> delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7);

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler<T1, T2, T3, T4, T5, T6, T7> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7> action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>>, IEventInvocation, IEquatable<ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8> m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8> delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8);

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8> action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9>>, IEventInvocation, IEquatable<ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9);

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>, IEventInvocation, IEquatable<ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10);

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>, IEventInvocation, IEquatable<ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11);

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>, IEventInvocation, IEquatable<ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12);

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>, IEventInvocation, IEquatable<ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13);

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>, IEventInvocation, IEquatable<ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13, notification.item14);

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>, IEventInvocation, IEquatable<ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14, T15 param15) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13, notification.item14, notification.item15);

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }

    /// <summary>
    /// Event handler with System.Action.
    /// </summary>
    public sealed class ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : IEventHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>, IEventInvocation, IEquatable<ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> m_Invocation;

        /// <summary>
        /// Create a event handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating EventHandler.</param>
        public ActionEventHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> delegation) => m_Invocation = delegation;

        /// <summary>
        /// Exposes the invocation method, so that the event bus can locate this handler from the weak subscription that wraps the same delegate.
        /// </summary>
        System.Reflection.MethodInfo IEventInvocation.invocationMethod => m_Invocation?.Method;

        object IEventInvocation.invocationOwner => m_Invocation?.Target;

        /// <summary>Handle the notification.</summary>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14, T15 param15, T16 param16) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16);

        /// <inheritdoc/>
        public void Handle(in ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13, notification.item14, notification.item15, notification.item16);

        /// <summary>
        /// Convert a delegate to the handler.
        /// </summary>
        public static implicit operator ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => unchecked((m_Invocation != null ? m_Invocation.Method.GetHashCode() : 0) * 397 ^ (m_Invocation != null && m_Invocation.Target != null ? m_Invocation.Target.GetHashCode() : 0));

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public static bool operator ==(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to event handler.
        /// </summary>
        public static bool operator !=(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public bool Equals(ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to event handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionEventHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action => action == m_Invocation,
            IWeakEventInvocation weak => weak.invocationMethod == m_Invocation?.Method && Equals(weak.invocationOwner, m_Invocation?.Target),
            _ => false
        };
    }
}
