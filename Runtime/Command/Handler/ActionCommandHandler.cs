/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: 关东关
 * Created On: 2023年06月01日
 * Description: CommandHandler wrapping of Action delegates.
 */

using System;

namespace PeroTools2.AccessKing
{
    public sealed class ActionCommandHandler : ICommandHandler<Empty>
    {
        private readonly Action m_Invocation;
        public ActionCommandHandler(Action delegation) => m_Invocation = delegation;
        public static implicit operator ActionCommandHandler(Action delegation) => new ActionCommandHandler(delegation);
        public void Handle() => m_Invocation?.Invoke();
        void ICommandHandler<Empty>.Handle(ref Empty notification) => Handle();
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;
        public static bool operator ==(ActionCommandHandler left, object right) => !Equals(left, null) && left.Equals(right);
        public static bool operator !=(ActionCommandHandler left, object right) => !(left == right);
        public bool Equals(ActionCommandHandler other) => other != null && m_Invocation == other.m_Invocation;
        public override bool Equals(object obj)
        {
            if (obj is ActionCommandHandler other)
                return Equals(other);
            if (obj is Action action)
                return action == m_Invocation;
            return false;
        }
    }

    public sealed class ActionCommandHandler<T> : ICommandHandler<ParameterNotification<T>>
    {
        private readonly Action<T> m_Invocation;
        public ActionCommandHandler(Action<T> delegation) => m_Invocation = delegation;
        public static implicit operator ActionCommandHandler<T>(Action<T> delegation) => new ActionCommandHandler<T>(delegation);
        public void Handle(T param) => m_Invocation?.Invoke(param);
        void ICommandHandler<ParameterNotification<T>>.Handle(ref ParameterNotification<T> notification) => Handle(notification.item);
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;
        public static bool operator ==(ActionCommandHandler<T> left, object right) => !Equals(left, null) && left.Equals(right);
        public static bool operator !=(ActionCommandHandler<T> left, object right) => !(left == right);
        public bool Equals(ActionCommandHandler<T> other) => other != null && m_Invocation == other.m_Invocation;
        public override bool Equals(object obj)
        {
            if (obj is ActionCommandHandler<T> other)
                return Equals(other);
            if (obj is Action<T> action)
                return action == m_Invocation;
            return false;
        }
    }

    public sealed class ActionCommandHandler<T1, T2> : ICommandHandler<ParameterNotification<T1, T2>>
    {
        private readonly Action<T1, T2> m_Invocation;
        public ActionCommandHandler(Action<T1, T2> delegation) => m_Invocation = delegation;
        public static implicit operator ActionCommandHandler<T1, T2>(Action<T1, T2> delegation) => new ActionCommandHandler<T1, T2>(delegation);
        public void Handle(T1 param1, T2 param2) => m_Invocation?.Invoke(param1, param2);
        void ICommandHandler<ParameterNotification<T1, T2>>.Handle(ref ParameterNotification<T1, T2> notification) => Handle(notification.item1, notification.item2);
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;
        public static bool operator ==(ActionCommandHandler<T1, T2> left, object right) => !Equals(left, null) && left.Equals(right);
        public static bool operator !=(ActionCommandHandler<T1, T2> left, object right) => !(left == right);
        public bool Equals(ActionCommandHandler<T1, T2> other) => other != null && m_Invocation == other.m_Invocation;
        public override bool Equals(object obj)
        {
            if (obj is ActionCommandHandler<T1, T2> other)
                return Equals(other);
            if (obj is Action<T1, T2> action)
                return action == m_Invocation;
            return false;
        }
    }

    public sealed class ActionCommandHandler<T1, T2, T3> : ICommandHandler<ParameterNotification<T1, T2, T3>>
    {
        private readonly Action<T1, T2, T3> m_Invocation;
        public ActionCommandHandler(Action<T1, T2, T3> delegation) => m_Invocation = delegation;
        public static implicit operator ActionCommandHandler<T1, T2, T3>(Action<T1, T2, T3> delegation) => new ActionCommandHandler<T1, T2, T3>(delegation);
        public void Handle(T1 param1, T2 param2, T3 param3) => m_Invocation?.Invoke(param1, param2, param3);
        void ICommandHandler<ParameterNotification<T1, T2, T3>>.Handle(ref ParameterNotification<T1, T2, T3> notification) => Handle(notification.item1, notification.item2, notification.item3);
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;
        public static bool operator ==(ActionCommandHandler<T1, T2, T3> left, object right) => !Equals(left, null) && left.Equals(right);
        public static bool operator !=(ActionCommandHandler<T1, T2, T3> left, object right) => !(left == right);
        public bool Equals(ActionCommandHandler<T1, T2, T3> other) => other != null && m_Invocation == other.m_Invocation;
        public override bool Equals(object obj)
        {
            if (obj is ActionCommandHandler<T1, T2, T3> other)
                return Equals(other);
            if (obj is Action<T1, T2, T3> action)
                return action == m_Invocation;
            return false;
        }
    }

    public sealed class ActionCommandHandler<T1, T2, T3, T4> : ICommandHandler<ParameterNotification<T1, T2, T3, T4>>
    {
        private readonly Action<T1, T2, T3, T4> m_Invocation;
        public ActionCommandHandler(Action<T1, T2, T3, T4> delegation) => m_Invocation = delegation;
        public static implicit operator ActionCommandHandler<T1, T2, T3, T4>(Action<T1, T2, T3, T4> delegation) => new ActionCommandHandler<T1, T2, T3, T4>(delegation);
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4) => m_Invocation?.Invoke(param1, param2, param3, param4);
        void ICommandHandler<ParameterNotification<T1, T2, T3, T4>>.Handle(ref ParameterNotification<T1, T2, T3, T4> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4);
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;
        public static bool operator ==(ActionCommandHandler<T1, T2, T3, T4> left, object right) => !Equals(left, null) && left.Equals(right);
        public static bool operator !=(ActionCommandHandler<T1, T2, T3, T4> left, object right) => !(left == right);
        public bool Equals(ActionCommandHandler<T1, T2, T3, T4> other) => other != null && m_Invocation == other.m_Invocation;
        public override bool Equals(object obj)
        {
            if (obj is ActionCommandHandler<T1, T2, T3, T4> other)
                return Equals(other);
            if (obj is Action<T1, T2, T3, T4> action)
                return action == m_Invocation;
            return false;
        }
    }

    public sealed class ActionCommandHandler<T1, T2, T3, T4, T5> : ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5>>
    {
        private readonly Action<T1, T2, T3, T4, T5> m_Invocation;
        public ActionCommandHandler(Action<T1, T2, T3, T4, T5> delegation) => m_Invocation = delegation;
        public static implicit operator ActionCommandHandler<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> delegation) => new ActionCommandHandler<T1, T2, T3, T4, T5>(delegation);
        public void Handle(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5) => m_Invocation?.Invoke(param1, param2, param3, param4, param5);
        void ICommandHandler<ParameterNotification<T1, T2, T3, T4, T5>>.Handle(ref ParameterNotification<T1, T2, T3, T4, T5> notification) => Handle(notification.item1, notification.item2, notification.item3, notification.item4, notification.item5);
        public override int GetHashCode() => m_Invocation != null ? m_Invocation.GetHashCode() : 0;
        public static bool operator ==(ActionCommandHandler<T1, T2, T3, T4, T5> left, object right) => !Equals(left, null) && left.Equals(right);
        public static bool operator !=(ActionCommandHandler<T1, T2, T3, T4, T5> left, object right) => !(left == right);
        public bool Equals(ActionCommandHandler<T1, T2, T3, T4, T5> other) => other != null && m_Invocation == other.m_Invocation;
        public override bool Equals(object obj)
        {
            if (obj is ActionCommandHandler<T1, T2, T3, T4, T5> other)
                return Equals(other);
            if (obj is Action<T1, T2, T3, T4, T5> action)
                return action == m_Invocation;
            return false;
        }
    }
}