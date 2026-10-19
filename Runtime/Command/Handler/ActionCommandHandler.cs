/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/01 15:06:16
 */

using System;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler : ICommandHandler, IEquatable<ActionCommandHandler>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle() => m_Invocation?.Invoke();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref Empty notification) => Handle();

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler"/>
        public static implicit operator ActionCommandHandler(Action delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler other => Equals(other),
            Action action => action == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler<T> : ICommandHandler<ParameterNotification<T>>, IEquatable<ActionCommandHandler<T>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action<T> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T param) => m_Invocation?.Invoke(param);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T> notification) => Handle(notification.item);

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler{T}"/>
        public static implicit operator ActionCommandHandler<T>(Action<T> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler<T> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler<T> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler<T> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler<T> other => Equals(other),
            Action<T> action => action == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler<T1, T2> : ICommandHandler<ParameterNotification<T1, T2>>, IEquatable<ActionCommandHandler<T1, T2>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action<T1, T2> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2) => m_Invocation?.Invoke(param1, param2);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2> notification) => Handle(notification.item1, notification.item2);

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler{T1, T2}"/>
        public static implicit operator ActionCommandHandler<T1, T2>(Action<T1, T2> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler<T1, T2> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler<T1, T2> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler<T1, T2> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler<T1, T2> other => Equals(other),
            Action<T1, T2> action => action == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler<T1, T2, T3> : ICommandHandler<ParameterNotification<T1, T2, T3>>, IEquatable<ActionCommandHandler<T1, T2, T3>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action<T1, T2, T3> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3) => m_Invocation?.Invoke(param1, param2, param3);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3> notification) => Handle(notification.item1, notification.item2, notification.item3);

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler{T1, T2, T3}"/>
        public static implicit operator ActionCommandHandler<T1, T2, T3>(Action<T1, T2, T3> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler<T1, T2, T3> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler<T1, T2, T3> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler<T1, T2, T3> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler<T1, T2, T3> other => Equals(other),
            Action<T1, T2, T3> action => action == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler<T1, T2, T3, T4> : ICommandHandler<ParameterNotification<T1, T2, T3, T4>>, IEquatable<ActionCommandHandler<T1, T2, T3, T4>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action<T1, T2, T3, T4> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4) => m_Invocation?.Invoke(param1, param2, param3, param4);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4);

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler{T1, T2, T3, T4}"/>
        public static implicit operator ActionCommandHandler<T1, T2, T3, T4>(Action<T1, T2, T3, T4> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler<T1, T2, T3, T4> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler<T1, T2, T3, T4> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler<T1, T2, T3, T4> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler<T1, T2, T3, T4> other => Equals(other),
            Action<T1, T2, T3, T4> action => action == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler<T1, T2, T3, T4, T5> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5>>, IEquatable<ActionCommandHandler<T1, T2, T3, T4, T5>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action<T1, T2, T3, T4, T5> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5) => m_Invocation?.Invoke(param1, param2, param3, param4, param5);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5);

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler{T1, T2, T3, T4, T5}"/>
        public static implicit operator ActionCommandHandler<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler<T1, T2, T3, T4, T5> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler<T1, T2, T3, T4, T5> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler<T1, T2, T3, T4, T5> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler<T1, T2, T3, T4, T5> other => Equals(other),
            Action<T1, T2, T3, T4, T5> action => action == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler<T1, T2, T3, T4, T5, T6> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6>>, IEquatable<ActionCommandHandler<T1, T2, T3, T4, T5, T6>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action<T1, T2, T3, T4, T5, T6> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6);

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler{T1, T2, T3, T4, T5, T6}"/>
        public static implicit operator ActionCommandHandler<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler<T1, T2, T3, T4, T5, T6> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler<T1, T2, T3, T4, T5, T6> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler<T1, T2, T3, T4, T5, T6> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler<T1, T2, T3, T4, T5, T6> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6> action => action == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7>>, IEquatable<ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action<T1, T2, T3, T4, T5, T6, T7> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7);

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler{T1, T2, T3, T4, T5, T6, T7}"/>
        public static implicit operator ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7> action => action == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>>, IEquatable<ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8);

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8}"/>
        public static implicit operator ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8> action => action == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9>>, IEquatable<ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9);

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/>
        public static implicit operator ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action => action == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>, IEquatable<ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10);

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/>
        public static implicit operator ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action => action == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>, IEquatable<ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11);

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/>
        public static implicit operator ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action => action == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>, IEquatable<ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12);

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/>
        public static implicit operator ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action => action == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>, IEquatable<ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13);

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/>
        public static implicit operator ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action => action == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>, IEquatable<ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13, notification.item14);

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/>
        public static implicit operator ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action => action == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>, IEquatable<ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14, T15 param15) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13, notification.item14, notification.item15);

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/>
        public static implicit operator ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action => action == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Action.
    /// </summary>
    public sealed class ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>, IEquatable<ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>
    {
        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Action
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public ActionCommandHandler(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14, T15 param15, T16 param16) => m_Invocation?.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13, notification.item14, notification.item15, notification.item16);

        /// <inheritdoc cref="PeroTools2.AccessKing.ActionCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/>
        public static implicit operator ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> other) => other is not null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            ActionCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> other => Equals(other),
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action => action == m_Invocation,
            _ => false
        };
    }
}