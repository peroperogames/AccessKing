using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PeroTools2.AccessKing.Samples.Game.Utils
{
    public class Timer : INotifyCompletion
    {
        private readonly YieldInstruction m_Yielder;
        private static GameObject m_Timer = new GameObject();
        public bool IsCompleted { get; private set; }
        private Action m_OnCompleted;

        public Timer(YieldInstruction yielder, MonoBehaviour sender)
        {
            m_Yielder = yielder;
            sender.StartCoroutine(WaitForCompleted());
        }

        private IEnumerator WaitForCompleted()
        {
            yield return m_Yielder;
            m_OnCompleted?.Invoke();
        }

        public void GetResult() { }

        public Timer GetAwaiter() => this;

        public void OnCompleted(Action continuation) => m_OnCompleted += continuation;
    }

    public static class TimerExtensions
    {
        public static Timer ToAwaitable(this YieldInstruction yielder, MonoBehaviour monoBehaviour)
        {
            return new Timer(yielder, monoBehaviour);
        }
    }
}