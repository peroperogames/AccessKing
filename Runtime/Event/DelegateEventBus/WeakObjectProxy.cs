using System;
using UnityEngine.Assertions;

namespace PeroTools2.AccessKing
{
    internal class WeakObjectProxy : IEquatable<WeakObjectProxy>
    {
        private readonly WeakReference m_Source;
        private readonly int m_HashCode;
        public bool isAlive => m_Source != null && m_Source.IsAlive;
        public object source => m_Source.Target;

        public WeakObjectProxy(object obj)
        {
            Assert.IsNotNull(obj);
            m_Source = new WeakReference(obj);
            m_HashCode = obj.GetHashCode();
        }

        public bool Equals(WeakObjectProxy other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return m_Source.IsAlive && other.isAlive && m_Source.Target == other.m_Source.Target;
        }

        public override bool Equals(object obj)
        {
            if (!m_Source.IsAlive) return false;
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (m_Source.IsAlive && m_Source.Target == obj)
                return true;
            return obj.GetType() == GetType() && Equals((WeakObjectProxy) obj);
        }
        
        public static bool operator ==(WeakObjectProxy weakObjectProxy, object other) 
            => other != null && weakObjectProxy != null && weakObjectProxy.GetHashCode() == other.GetHashCode() && weakObjectProxy.Equals(other);

        public static bool operator !=(WeakObjectProxy weakObjectProxy, object other) 
            => weakObjectProxy == null || other == null || weakObjectProxy.GetHashCode() != other.GetHashCode() || weakObjectProxy.Equals(other);

        public override int GetHashCode() => m_HashCode;
    }
}