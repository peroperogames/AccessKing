/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/09 14:06:35
 */

using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PeroTools2.AccessKing.Samples.Game.Utils
{
    public class Awaiter : INotifyCompletion
    {
        private readonly YieldInstruction m_Yielder;
        public bool IsCompleted { get; private set; }
        private Action m_OnCompleted;

        public Awaiter(YieldInstruction yielder, MonoBehaviour sender)
        {
            m_Yielder = yielder;
            sender.StartCoroutine(WaitForCompleted());
        }

        private IEnumerator WaitForCompleted()
        {
            yield return m_Yielder;
            IsCompleted = true;
            m_OnCompleted?.Invoke();
        }

        public void GetResult() { }

        public Awaiter GetAwaiter() => this;

        public void OnCompleted(Action continuation) => m_OnCompleted += continuation;
    }

    public static class TimerExtensions
    {
        public static Awaiter ToAwaitable(this YieldInstruction yielder, MonoBehaviour monoBehaviour) => new(yielder, monoBehaviour);
    }
}