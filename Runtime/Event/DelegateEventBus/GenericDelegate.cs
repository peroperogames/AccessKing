using System;
using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public class GenericDelegate<TDelegate> : IDelegate<TDelegate> where TDelegate : Delegate
    {
        private readonly List<Delegate> m_CombineBuffer = new List<Delegate>();

        public TDelegate delegation { get; private set; }

        public GenericDelegate() { }

        public GenericDelegate(TDelegate target) => Add(target);

        public static implicit operator GenericDelegate<TDelegate>(TDelegate target) => new GenericDelegate<TDelegate>(target);

        public static GenericDelegate<TDelegate> operator +(GenericDelegate<TDelegate> left, IDelegate<TDelegate> right)
        {
            left.Add(right.delegation);
            return left;
        }

        public static GenericDelegate<TDelegate> operator -(GenericDelegate<TDelegate> left, IDelegate<TDelegate> right)
        {
            left.Remove(right.delegation);
            return left;
        }

        public static GenericDelegate<TDelegate> operator +(GenericDelegate<TDelegate> left, TDelegate right)
        {
            left.Add(right);
            return left;
        }

        public static GenericDelegate<TDelegate> operator -(GenericDelegate<TDelegate> left, TDelegate right)
        {
            left.Remove(right);
            return left;
        }

        public void Add(TDelegate target)
        {
            if (delegation != null)
            {
                foreach (var invocation in delegation.GetInvocationList())
                {
                    m_CombineBuffer.Add(invocation);
                }
            }

            foreach (var invocation in target.GetInvocationList())
            {
                m_CombineBuffer.Add(invocation);
            }

            delegation = (TDelegate) Delegate.Combine(m_CombineBuffer.ToArray());
            m_CombineBuffer.Clear();
        }

        public bool Remove(TDelegate target)
        {
            var curInvocations = delegation.GetInvocationList();
            var targetInvocations = target.GetInvocationList();
            for (var i = curInvocations.Length - 1; i >= 0; i--)
            {
                var hasRemoved = false;
                for (var j = 0; j < targetInvocations.Length; j++)
                {
                    if (curInvocations[i] == targetInvocations[j])
                    {
                        hasRemoved = true;
                        break;
                    }
                }

                if (!hasRemoved)
                {
                    m_CombineBuffer.Add(curInvocations[i]);
                }
            }

            var anyRemoved = m_CombineBuffer.Count < curInvocations.Length;
            delegation = (TDelegate) Delegate.Combine(m_CombineBuffer.ToArray());
            m_CombineBuffer.Clear();
            return anyRemoved;
        }

        public void Clear()
        {
            delegation = null;
            m_CombineBuffer.Clear();
        }
    }
}