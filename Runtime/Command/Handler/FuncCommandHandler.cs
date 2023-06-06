/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年06月01日
 * Description: CommandHandler wrapping of Func delegates.
 */

using System;

namespace PeroTools2.AccessKing
{
    public class FuncCommandHandler<TResult> : ICommandHandler<Empty, TResult>
    {
        private TResult m_Result;
        private readonly Func<TResult> m_Invocation;
        public FuncCommandHandler(Func<TResult> func) => m_Invocation = func;
        public static implicit operator FuncCommandHandler<TResult>(Func<TResult> delegation) => new FuncCommandHandler<TResult>(delegation);
        public void Handle() => m_Result = m_Invocation.Invoke();
        void ICommandHandler<Empty>.Handle(ref Empty notification) => m_Result = m_Invocation.Invoke();
        public TResult GetResult() => m_Result;
        object IResultAvailable.GetResult() => GetResult();
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;
        public static bool operator ==(FuncCommandHandler<TResult> left, object right) => !Equals(left, null) && left.Equals(right);
        public static bool operator !=(FuncCommandHandler<TResult> left, object right) => !(left == right);
        public bool Equals(FuncCommandHandler<TResult> other) => other != null && m_Invocation == other.m_Invocation;
        public override bool Equals(object obj)
        {
            if (obj is FuncCommandHandler<TResult> other)
                return Equals(other);
            if (obj is Func<TResult> action)
                return action == m_Invocation;
            return false;
        }
    }

    public class FuncCommandHandler<T, TResult> : ICommandHandler<ParameterNotification<T>, TResult>
    {
        private TResult m_Result;
        private readonly Func<T, TResult> m_Invocation;
        public FuncCommandHandler(Func<T, TResult> func) => m_Invocation = func;
        public static implicit operator FuncCommandHandler<T, TResult>(Func<T, TResult> delegation) => new FuncCommandHandler<T, TResult>(delegation);
        public void Handle(T param) => m_Result = m_Invocation.Invoke(param);
        void ICommandHandler<ParameterNotification<T>>.Handle(ref ParameterNotification<T> notification) => m_Result = m_Invocation.Invoke(notification.item);
        public TResult GetResult() => m_Result;
        object IResultAvailable.GetResult() => GetResult();
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;
        public static bool operator ==(FuncCommandHandler<T, TResult> left, object right) => !Equals(left, null) && left.Equals(right);
        public static bool operator !=(FuncCommandHandler<T, TResult> left, object right) => !(left == right);
        public bool Equals(FuncCommandHandler<T, TResult> other) => other != null && m_Invocation == other.m_Invocation;
        public override bool Equals(object obj)
        {
            if (obj is FuncCommandHandler<T, TResult> other)
                return Equals(other);
            if (obj is Func<T, TResult> action)
                return action == m_Invocation;
            return false;
        }
    }

    public class FuncCommandHandler<T1, T2, TResult> : ICommandHandler<ParameterNotification<T1, T2>, TResult>
    {
        private TResult m_Result;
        private readonly Func<T1, T2, TResult> m_Invocation;
        public FuncCommandHandler(Func<T1, T2, TResult> func) => m_Invocation = func;
        public static implicit operator FuncCommandHandler<T1, T2, TResult>(Func<T1, T2, TResult> delegation) => new FuncCommandHandler<T1, T2, TResult>(delegation);
        public void Handle(T1 param1, T2 param2) => m_Result = m_Invocation.Invoke(param1, param2);
        void ICommandHandler<ParameterNotification<T1, T2>>.Handle(ref ParameterNotification<T1, T2> notification) => m_Result = m_Invocation.Invoke(notification.item1, notification.item2);
        public TResult GetResult() => m_Result;
        object IResultAvailable.GetResult() => GetResult();
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;
        public static bool operator ==(FuncCommandHandler<T1, T2, TResult> left, object right) => !Equals(left, null) && left.Equals(right);
        public static bool operator !=(FuncCommandHandler<T1, T2, TResult> left, object right) => !(left == right);
        public bool Equals(FuncCommandHandler<T1, T2, TResult> other) => other != null && m_Invocation == other.m_Invocation;
        public override bool Equals(object obj)
        {
            if (obj is FuncCommandHandler<T1, T2, TResult> other)
                return Equals(other);
            if (obj is Func<T1, T2, TResult> action)
                return action == m_Invocation;
            return false;
        }
    }

    public class FuncCommandHandler<T1, T2, T3, TResult> : ICommandHandler<ParameterNotification<T1, T2, T3>, TResult>
    {
        private TResult m_Result;
        private readonly Func<T1, T2, T3, TResult> m_Invocation;
        public FuncCommandHandler(Func<T1, T2, T3, TResult> func) => m_Invocation = func;
        public static implicit operator FuncCommandHandler<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> delegation) => new FuncCommandHandler<T1, T2, T3, TResult>(delegation);
        public void Handle(T1 param1, T2 param2, T3 param3) => m_Result = m_Invocation.Invoke(param1, param2, param3);
        void ICommandHandler<ParameterNotification<T1, T2, T3>>.Handle(ref ParameterNotification<T1, T2, T3> notification) => m_Result = m_Invocation.Invoke(notification.item1, notification.item2, notification.item3);
        public TResult GetResult() => m_Result;
        object IResultAvailable.GetResult() => GetResult();
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;
        public static bool operator ==(FuncCommandHandler<T1, T2, T3, TResult> left, object right) => !Equals(left, null) && left.Equals(right);
        public static bool operator !=(FuncCommandHandler<T1, T2, T3, TResult> left, object right) => !(left == right);
        public bool Equals(FuncCommandHandler<T1, T2, T3, TResult> other) => other != null && m_Invocation == other.m_Invocation;
        public override bool Equals(object obj)
        {
            if (obj is FuncCommandHandler<T1, T2, T3, TResult> other)
                return Equals(other);
            if (obj is Func<T1, T2, T3, TResult> action)
                return action == m_Invocation;
            return false;
        }
    }

    public class FuncCommandHandler<T1, T2, T3, T4, TResult> : ICommandHandler<ParameterNotification<T1, T2, T3, T4>, TResult>
    {
        private TResult m_Result;
        private readonly Func<T1, T2, T3, T4, TResult> m_Invocation;
        public FuncCommandHandler(Func<T1, T2, T3, T4, TResult> func) => m_Invocation = func;
        public static implicit operator FuncCommandHandler<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> delegation) => new FuncCommandHandler<T1, T2, T3, T4, TResult>(delegation);
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4) => m_Result = m_Invocation.Invoke(param1, param2, param3, param4);
        void ICommandHandler<ParameterNotification<T1, T2, T3, T4>>.Handle(ref ParameterNotification<T1, T2, T3, T4> notification) => m_Result = m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4);
        public TResult GetResult() => m_Result;
        object IResultAvailable.GetResult() => GetResult();
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;
        public static bool operator ==(FuncCommandHandler<T1, T2, T3, T4, TResult> left, object right) => !Equals(left, null) && left.Equals(right);
        public static bool operator !=(FuncCommandHandler<T1, T2, T3, T4, TResult> left, object right) => !(left == right);
        public bool Equals(FuncCommandHandler<T1, T2, T3, T4, TResult> other) => other != null && m_Invocation == other.m_Invocation;
        public override bool Equals(object obj)
        {
            if (obj is FuncCommandHandler<T1, T2, T3, T4, TResult> other)
                return Equals(other);
            if (obj is Func<T1, T2, T3, T4, TResult> action)
                return action == m_Invocation;
            return false;
        }
    }

    public class FuncCommandHandler<T1, T2, T3, T4, T5, TResult> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5>, TResult>
    {
        private TResult m_Result;
        private readonly Func<T1, T2, T3, T4, T5, TResult> m_Invocation;
        public FuncCommandHandler(Func<T1, T2, T3, T4, T5, TResult> func) => m_Invocation = func;
        public static implicit operator FuncCommandHandler<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> delegation) => new FuncCommandHandler<T1, T2, T3, T4, T5, TResult>(delegation);
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5) => m_Result = m_Invocation.Invoke(param1, param2, param3, param4, param5);
        void ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5>>.Handle(ref ParameterNotification<T1, T2, T3, T4, T5> notification) => m_Result = m_Invocation.Invoke(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5);
        public TResult GetResult() => m_Result;
        object IResultAvailable.GetResult() => GetResult();
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;
        public static bool operator ==(FuncCommandHandler<T1, T2, T3, T4, T5, TResult> left, object right) => !Equals(left, null) && left.Equals(right);
        public static bool operator !=(FuncCommandHandler<T1, T2, T3, T4, T5, TResult> left, object right) => !(left == right);
        public bool Equals(FuncCommandHandler<T1, T2, T3, T4, T5, TResult> other) => other != null && m_Invocation == other.m_Invocation;
        public override bool Equals(object obj)
        {
            if (obj is FuncCommandHandler<T1, T2, T3, T4, T5, TResult> other)
                return Equals(other);
            if (obj is Func<T1, T2, T3, T4, T5, TResult> action)
                return action == m_Invocation;
            return false;
        }
    }
}