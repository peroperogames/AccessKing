using System;
using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    public class WeakDelegate<TDelegate> : IDelegate<TDelegate>, IGCListener where TDelegate : Delegate
    {
        private readonly List<Delegate> m_CombineBuffer = new List<Delegate>();
        private TDelegate m_Delegate;
        public TDelegate delegation
        {
            get
            {
                this.WaitForGCFinishCallbackCheck();
                return m_Delegate;
            }
        }

        public WeakDelegate() => this.RegisterGCFinishListener();  

        public WeakDelegate(TDelegate target) : this() => Add(target);

        public static implicit operator WeakDelegate<TDelegate>(TDelegate target) => new WeakDelegate<TDelegate>(target);

        public static WeakDelegate<TDelegate> operator +(WeakDelegate<TDelegate> left, IDelegate<TDelegate> right)
        {
            left.Add(right.delegation);
            return left;
        }

        public static WeakDelegate<TDelegate> operator -(WeakDelegate<TDelegate> left, IDelegate<TDelegate> right)
        {
            left.Remove(right.delegation);
            return left;
        }

        public static WeakDelegate<TDelegate> operator +(WeakDelegate<TDelegate> left, TDelegate right)
        {
            left.Add(right);
            return left;
        }

        public static WeakDelegate<TDelegate> operator -(WeakDelegate<TDelegate> left, TDelegate right)
        {
            left.Remove(right);
            return left;
        }

        public void Add(TDelegate target)
        {
            if (m_Delegate != null)
            {
                foreach (var invocation in m_Delegate.GetInvocationList())
                {
                    if (invocation.Target == null || invocation.Target is WeakObjectProxy weakProxy && weakProxy.isAlive)
                    {
                        m_CombineBuffer.Add(invocation);
                    }
                }
            }

            foreach (var invocation in target.GetInvocationList())
            {
                var result = invocation.ToWeakTargetDelegate();
                m_CombineBuffer.Add(result);
            }

            m_Delegate = (TDelegate) Delegate.Combine(m_CombineBuffer.ToArray());
            m_CombineBuffer.Clear();
        }

        public bool Remove(TDelegate target)
        {
            if (m_Delegate == null) return false;

            var curInvocations = m_Delegate.GetInvocationList();
            var targetInvocations = target.GetInvocationList();
            var anyRemoved = false;
            for (var i = curInvocations.Length - 1; i >= 0; i--)
            {
                var invocation = curInvocations[i];

                //Remove delegate with not alive target
                if (invocation.Target is WeakObjectProxy weakProxy && !weakProxy.isAlive) continue;

                //Remove the delegate that contains in target invocations
                var hasRemoved = false;
                for (var j = 0; j < targetInvocations.Length; j++)
                {
                    if (invocation != targetInvocations[j]) continue;
                    anyRemoved = true;
                    hasRemoved = true;
                    break;
                }

                if (!hasRemoved)
                    m_CombineBuffer.Add(invocation);
            }
            m_Delegate = (TDelegate) Delegate.Combine(m_CombineBuffer.ToArray());
            m_CombineBuffer.Clear();
            return anyRemoved;
        }

        public void Clear()
        {
            m_Delegate = null;
            m_CombineBuffer.Clear();
        }

        //Remove delegates with not alive target
        void IGCListener.OnGCFinished()
        {
            if (m_Delegate == null) return;
            var invocations = m_Delegate.GetInvocationList();
            foreach (var invocation in invocations)
            {
                if (invocation.Target == null || (invocation.Target is WeakObjectProxy weakProxy && weakProxy.isAlive))
                {
                    m_CombineBuffer.Add(invocation);
                }
            }

            if (m_CombineBuffer.Count != invocations.Length)
                m_Delegate = (TDelegate) Delegate.Combine(m_CombineBuffer.ToArray());
                
            m_CombineBuffer.Clear();
        }
    }
}