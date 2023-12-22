/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/01 15:06:34
 */

using System;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Command handler with System.Func.
    /// </summary>
    public sealed class FuncCommandHandler<TResult> : ICommandHandler<Empty, TResult>, IEquatable<FuncCommandHandler<TResult>>
    {
        /// <summary>
        /// Result of command.
        /// </summary>
        private TResult m_Result;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Func<TResult> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Func
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public FuncCommandHandler(Func<TResult> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="IResultAvailable{TResult}.GetResult()"/>
        public TResult GetResult() => m_Result;

        /// <inheritdoc cref="IResultAvailable.GetResult()"/>
        object IResultAvailable.GetResult() => GetResult();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle() => m_Result = m_Invocation.Invoke();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref Empty notification) => Handle();

        /// <inheritdoc cref="PeroTools2.AccessKing.FuncCommandHandler{TResult}"/>
        public static implicit operator FuncCommandHandler<TResult>(Func<TResult> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(FuncCommandHandler<TResult> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(FuncCommandHandler<TResult> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(FuncCommandHandler<TResult> other) => other != null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            FuncCommandHandler<TResult> other => Equals(other),
            Func<TResult> func => func == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Func.
    /// </summary>
    public sealed class FuncCommandHandler<T, TResult> : ICommandHandler<ParameterNotification<T>, TResult>, IEquatable<FuncCommandHandler<T, TResult>>
    {
        /// <summary>
        /// Result of command.
        /// </summary>
        private TResult m_Result;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Func<T, TResult> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Func
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public FuncCommandHandler(Func<T, TResult> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="IResultAvailable{TResult}.GetResult()"/>
        public TResult GetResult() => m_Result;

        /// <inheritdoc cref="IResultAvailable.GetResult()"/>
        object IResultAvailable.GetResult() => GetResult();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T param) => m_Result = m_Invocation.Invoke(param);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T> notification) => Handle(notification.item);

        /// <inheritdoc cref="PeroTools2.AccessKing.FuncCommandHandler{T, TResult}"/>
        public static implicit operator FuncCommandHandler<T, TResult>(Func<T, TResult> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(FuncCommandHandler<T, TResult> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(FuncCommandHandler<T, TResult> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(FuncCommandHandler<T, TResult> other) => other != null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            FuncCommandHandler<T, TResult> other => Equals(other),
            Func<T, TResult> func => func == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Func.
    /// </summary>
    public sealed class FuncCommandHandler<T1, T2, TResult> : ICommandHandler<ParameterNotification<T1, T2>, TResult>, IEquatable<FuncCommandHandler<T1, T2, TResult>>
    {
        /// <summary>
        /// Result of command.
        /// </summary>
        private TResult m_Result;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Func<T1, T2, TResult> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Func
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public FuncCommandHandler(Func<T1, T2, TResult> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="IResultAvailable{TResult}.GetResult()"/>
        public TResult GetResult() => m_Result;

        /// <inheritdoc cref="IResultAvailable.GetResult()"/>
        object IResultAvailable.GetResult() => GetResult();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2) => m_Result = m_Invocation.Invoke(param1, param2);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2> notification) => Handle(notification.item1, notification.item2);

        /// <inheritdoc cref="PeroTools2.AccessKing.FuncCommandHandler{T1, T2, TResult}"/>
        public static implicit operator FuncCommandHandler<T1, T2, TResult>(Func<T1, T2, TResult> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(FuncCommandHandler<T1, T2, TResult> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(FuncCommandHandler<T1, T2, TResult> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(FuncCommandHandler<T1, T2, TResult> other) => other != null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            FuncCommandHandler<T1, T2, TResult> other => Equals(other),
            Func<T1, T2, TResult> func => func == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Func.
    /// </summary>
    public sealed class FuncCommandHandler<T1, T2, T3, TResult> : ICommandHandler<ParameterNotification<T1, T2, T3>, TResult>, IEquatable<FuncCommandHandler<T1, T2, T3, TResult>>
    {
        /// <summary>
        /// Result of command.
        /// </summary>
        private TResult m_Result;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Func<T1, T2, T3, TResult> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Func
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public FuncCommandHandler(Func<T1, T2, T3, TResult> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="IResultAvailable{TResult}.GetResult()"/>
        public TResult GetResult() => m_Result;

        /// <inheritdoc cref="IResultAvailable.GetResult()"/>
        object IResultAvailable.GetResult() => GetResult();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3) => m_Result = m_Invocation.Invoke(param1, param2, param3);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3> notification) => Handle(notification.item1, notification.item2, notification.item3);

        /// <inheritdoc cref="PeroTools2.AccessKing.FuncCommandHandler{T1, T2, T3, TResult}"/>
        public static implicit operator FuncCommandHandler<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(FuncCommandHandler<T1, T2, T3, TResult> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(FuncCommandHandler<T1, T2, T3, TResult> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(FuncCommandHandler<T1, T2, T3, TResult> other) => other != null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            FuncCommandHandler<T1, T2, T3, TResult> other => Equals(other),
            Func<T1, T2, T3, TResult> func => func == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Func.
    /// </summary>
    public sealed class FuncCommandHandler<T1, T2, T3, T4, TResult> : ICommandHandler<ParameterNotification<T1, T2, T3, T4>, TResult>, IEquatable<FuncCommandHandler<T1, T2, T3, T4, TResult>>
    {
        /// <summary>
        /// Result of command.
        /// </summary>
        private TResult m_Result;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Func<T1, T2, T3, T4, TResult> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Func
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public FuncCommandHandler(Func<T1, T2, T3, T4, TResult> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="IResultAvailable{TResult}.GetResult()"/>
        public TResult GetResult() => m_Result;

        /// <inheritdoc cref="IResultAvailable.GetResult()"/>
        object IResultAvailable.GetResult() => GetResult();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4) => m_Result = m_Invocation.Invoke(param1, param2, param3, param4);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4);

        /// <inheritdoc cref="PeroTools2.AccessKing.FuncCommandHandler{T1, T2, T3, T4, TResult}"/>
        public static implicit operator FuncCommandHandler<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(FuncCommandHandler<T1, T2, T3, T4, TResult> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(FuncCommandHandler<T1, T2, T3, T4, TResult> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(FuncCommandHandler<T1, T2, T3, T4, TResult> other) => other != null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            FuncCommandHandler<T1, T2, T3, T4, TResult> other => Equals(other),
            Func<T1, T2, T3, T4, TResult> func => func == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Func.
    /// </summary>
    public sealed class FuncCommandHandler<T1, T2, T3, T4, T5, TResult> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5>, TResult>, IEquatable<FuncCommandHandler<T1, T2, T3, T4, T5, TResult>>
    {
        /// <summary>
        /// Result of command.
        /// </summary>
        private TResult m_Result;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Func<T1, T2, T3, T4, T5, TResult> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Func
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public FuncCommandHandler(Func<T1, T2, T3, T4, T5, TResult> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="IResultAvailable{TResult}.GetResult()"/>
        public TResult GetResult() => m_Result;

        /// <inheritdoc cref="IResultAvailable.GetResult()"/>
        object IResultAvailable.GetResult() => GetResult();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5) => m_Result = m_Invocation.Invoke(param1, param2, param3, param4, param5);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5);

        /// <inheritdoc cref="PeroTools2.AccessKing.FuncCommandHandler{T1, T2, T3, T4, T5, TResult}"/>
        public static implicit operator FuncCommandHandler<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(FuncCommandHandler<T1, T2, T3, T4, T5, TResult> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(FuncCommandHandler<T1, T2, T3, T4, T5, TResult> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(FuncCommandHandler<T1, T2, T3, T4, T5, TResult> other) => other != null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            FuncCommandHandler<T1, T2, T3, T4, T5, TResult> other => Equals(other),
            Func<T1, T2, T3, T4, T5, TResult> func => func == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Func.
    /// </summary>
    public sealed class FuncCommandHandler<T1, T2, T3, T4, T5, T6, TResult> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6>, TResult>, IEquatable<FuncCommandHandler<T1, T2, T3, T4, T5, T6, TResult>>
    {
        /// <summary>
        /// Result of command.
        /// </summary>
        private TResult m_Result;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Func<T1, T2, T3, T4, T5, T6, TResult> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Func
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public FuncCommandHandler(Func<T1, T2, T3, T4, T5, T6, TResult> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="IResultAvailable{TResult}.GetResult()"/>
        public TResult GetResult() => m_Result;

        /// <inheritdoc cref="IResultAvailable.GetResult()"/>
        object IResultAvailable.GetResult() => GetResult();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6) => m_Result = m_Invocation.Invoke(param1, param2, param3, param4, param5, param6);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6);

        /// <inheritdoc cref="PeroTools2.AccessKing.FuncCommandHandler{T1, T2, T3, T4, T5, T6, TResult}"/>
        public static implicit operator FuncCommandHandler<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(FuncCommandHandler<T1, T2, T3, T4, T5, T6, TResult> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(FuncCommandHandler<T1, T2, T3, T4, T5, T6, TResult> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(FuncCommandHandler<T1, T2, T3, T4, T5, T6, TResult> other) => other != null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            FuncCommandHandler<T1, T2, T3, T4, T5, T6, TResult> other => Equals(other),
            Func<T1, T2, T3, T4, T5, T6, TResult> func => func == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Func.
    /// </summary>
    public sealed class FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, TResult> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7>, TResult>, IEquatable<FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, TResult>>
    {
        /// <summary>
        /// Result of command.
        /// </summary>
        private TResult m_Result;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Func<T1, T2, T3, T4, T5, T6, T7, TResult> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Func
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public FuncCommandHandler(Func<T1, T2, T3, T4, T5, T6, T7, TResult> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="IResultAvailable{TResult}.GetResult()"/>
        public TResult GetResult() => m_Result;

        /// <inheritdoc cref="IResultAvailable.GetResult()"/>
        object IResultAvailable.GetResult() => GetResult();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7) => m_Result = m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7);

        /// <inheritdoc cref="PeroTools2.AccessKing.FuncCommandHandler{T1, T2, T3, T4, T5, T6, T7, TResult}"/>
        public static implicit operator FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, TResult> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, TResult> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, TResult> other) => other != null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, TResult> other => Equals(other),
            Func<T1, T2, T3, T4, T5, T6, T7, TResult> func => func == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Func.
    /// </summary>
    public sealed class FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, TResult> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8>, TResult>, IEquatable<FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>
    {
        /// <summary>
        /// Result of command.
        /// </summary>
        private TResult m_Result;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Func
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public FuncCommandHandler(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="IResultAvailable{TResult}.GetResult()"/>
        public TResult GetResult() => m_Result;

        /// <inheritdoc cref="IResultAvailable.GetResult()"/>
        object IResultAvailable.GetResult() => GetResult();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8) => m_Result = m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8);

        /// <inheritdoc cref="PeroTools2.AccessKing.FuncCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8, TResult}"/>
        public static implicit operator FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, TResult> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, TResult> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, TResult> other) => other != null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, TResult> other => Equals(other),
            Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func => func == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Func.
    /// </summary>
    public sealed class FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9>, TResult>, IEquatable<FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>
    {
        /// <summary>
        /// Result of command.
        /// </summary>
        private TResult m_Result;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Func
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public FuncCommandHandler(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="IResultAvailable{TResult}.GetResult()"/>
        public TResult GetResult() => m_Result;

        /// <inheritdoc cref="IResultAvailable.GetResult()"/>
        object IResultAvailable.GetResult() => GetResult();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9) => m_Result = m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9);

        /// <inheritdoc cref="PeroTools2.AccessKing.FuncCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult}"/>
        public static implicit operator FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> other) => other != null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> other => Equals(other),
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func => func == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Func.
    /// </summary>
    public sealed class FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, TResult>, IEquatable<FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>>
    {
        /// <summary>
        /// Result of command.
        /// </summary>
        private TResult m_Result;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Func
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public FuncCommandHandler(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="IResultAvailable{TResult}.GetResult()"/>
        public TResult GetResult() => m_Result;

        /// <inheritdoc cref="IResultAvailable.GetResult()"/>
        object IResultAvailable.GetResult() => GetResult();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10) => m_Result = m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10);

        /// <inheritdoc cref="PeroTools2.AccessKing.FuncCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult}"/>
        public static implicit operator FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> other) => other != null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> other => Equals(other),
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func => func == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Func.
    /// </summary>
    public sealed class FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, TResult>, IEquatable<FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>>
    {
        /// <summary>
        /// Result of command.
        /// </summary>
        private TResult m_Result;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Func
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public FuncCommandHandler(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="IResultAvailable{TResult}.GetResult()"/>
        public TResult GetResult() => m_Result;

        /// <inheritdoc cref="IResultAvailable.GetResult()"/>
        object IResultAvailable.GetResult() => GetResult();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11) => m_Result = m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11);

        /// <inheritdoc cref="PeroTools2.AccessKing.FuncCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult}"/>
        public static implicit operator FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> other) => other != null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> other => Equals(other),
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func => func == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Func.
    /// </summary>
    public sealed class FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, TResult>, IEquatable<FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>>
    {
        /// <summary>
        /// Result of command.
        /// </summary>
        private TResult m_Result;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Func
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public FuncCommandHandler(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="IResultAvailable{TResult}.GetResult()"/>
        public TResult GetResult() => m_Result;

        /// <inheritdoc cref="IResultAvailable.GetResult()"/>
        object IResultAvailable.GetResult() => GetResult();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12) => m_Result = m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12);

        /// <inheritdoc cref="PeroTools2.AccessKing.FuncCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult}"/>
        public static implicit operator FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> other) => other != null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> other => Equals(other),
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func => func == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Func.
    /// </summary>
    public sealed class FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, TResult>, IEquatable<FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>>
    {
        /// <summary>
        /// Result of command.
        /// </summary>
        private TResult m_Result;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Func
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public FuncCommandHandler(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="IResultAvailable{TResult}.GetResult()"/>
        public TResult GetResult() => m_Result;

        /// <inheritdoc cref="IResultAvailable.GetResult()"/>
        object IResultAvailable.GetResult() => GetResult();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13) => m_Result = m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13);

        /// <inheritdoc cref="PeroTools2.AccessKing.FuncCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult}"/>
        public static implicit operator FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> other) => other != null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> other => Equals(other),
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func => func == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Func.
    /// </summary>
    public sealed class FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, TResult>, IEquatable<FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>>
    {
        /// <summary>
        /// Result of command.
        /// </summary>
        private TResult m_Result;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Func
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public FuncCommandHandler(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="IResultAvailable{TResult}.GetResult()"/>
        public TResult GetResult() => m_Result;

        /// <inheritdoc cref="IResultAvailable.GetResult()"/>
        object IResultAvailable.GetResult() => GetResult();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14) => m_Result = m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13, notification.item14);

        /// <inheritdoc cref="PeroTools2.AccessKing.FuncCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult}"/>
        public static implicit operator FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> other) => other != null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> other => Equals(other),
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func => func == m_Invocation,
            _ => false
        };
    }

    /// <summary>
    /// Command handler with System.Func.
    /// </summary>
    public sealed class FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, TResult>, IEquatable<FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>>
    {
        /// <summary>
        /// Result of command.
        /// </summary>
        private TResult m_Result;

        /// <summary>
        /// Delegate with instance method provider.
        /// </summary>
        private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> m_Invocation;

        /// <summary>
        /// Create a command handler from a System.Func
        /// </summary>
        /// <param name="delegation">Delegation for creating CommandHandler.</param>
        public FuncCommandHandler(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> delegation) => m_Invocation = delegation;

        /// <inheritdoc cref="IResultAvailable{TResult}.GetResult()"/>
        public TResult GetResult() => m_Result;

        /// <inheritdoc cref="IResultAvailable.GetResult()"/>
        object IResultAvailable.GetResult() => GetResult();

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, T7 param7, T8 param8, T9 param9, T10 param10, T11 param11, T12 param12, T13 param13, T14 param14, T15 param15) => m_Result = m_Invocation.Invoke(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15);

        /// <inheritdoc cref="PeroTools2.AccessKing.ICommandHandler.Handle"/>
        public void Handle(ref ParameterNotification<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5, notification.item6, notification.item7, notification.item8, notification.item9, notification.item10, notification.item11, notification.item12, notification.item13, notification.item14, notification.item15);

        /// <inheritdoc cref="PeroTools2.AccessKing.FuncCommandHandler{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult}"/>
        public static implicit operator FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> delegation) => new(delegation);

        /// <inheritdoc cref="System.Object.GetHashCode()"/>
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public static bool operator ==(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> left, object right) => !Equals(left, null) && left.Equals(right);

        /// <summary>
        /// Verify if the target not equals to command handler.
        /// </summary>
        public static bool operator !=(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> left, object right) => !(left == right);

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public bool Equals(FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> other) => other != null && m_Invocation == other.m_Invocation;

        /// <summary>
        /// Verify if the target equals to command handler.
        /// </summary>
        public override bool Equals(object obj) => obj switch
        {
            FuncCommandHandler<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> other => Equals(other),
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func => func == m_Invocation,
            _ => false
        };
    }
}