using System;
using System.Collections.Generic;

namespace PeroTools2.AccessKing
{
    internal class ObjectPool<T> where T: new()
    {
        private static readonly Lazy<ObjectPool<T>> s_LazyInstance = new Lazy<ObjectPool<T>>(() => new ObjectPool<T>());
        private static ObjectPool<T> s_Instance => s_LazyInstance.Value;
        private readonly Stack<T> m_Stack = new Stack<T>();
        protected virtual T RequireInternal() => m_Stack.Count > 0 ? m_Stack.Pop() : new T();
        protected virtual void RecycleInternal(T obj) => m_Stack.Push(obj);
        
        public static T Require() => s_Instance.RequireInternal();
        public static void Recycle(T obj) => s_Instance.RecycleInternal(obj);
    }
}