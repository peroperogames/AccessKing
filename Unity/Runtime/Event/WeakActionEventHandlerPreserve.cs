/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2026/10/22 18:00:00
 */

using UnityEngine.Scripting;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Keeps the generic instantiations that the weak subscriptions create at runtime, so the IL2CPP managed code
    /// stripping does not remove <c>ActionInvoker&lt;TProvider&gt;</c> for each supported notification arity.
    /// </summary>
    internal static class WeakActionEventHandlerPreserve
    {
        [Preserve]
        public static WeakActionEventHandler.ActionInvoker<object> argumentCount0;

        [Preserve]
        public static WeakActionEventHandler<Empty>.ActionInvoker<object> argumentCount1;

        [Preserve]
        public static WeakActionEventHandler<Empty, Empty>.ActionInvoker<object> argumentCount2;

        [Preserve]
        public static WeakActionEventHandler<Empty, Empty, Empty>.ActionInvoker<object> argumentCount3;

        [Preserve]
        public static WeakActionEventHandler<Empty, Empty, Empty, Empty>.ActionInvoker<object> argumentCount4;

        [Preserve]
        public static WeakActionEventHandler<Empty, Empty, Empty, Empty, Empty>.ActionInvoker<object> argumentCount5;

        [Preserve]
        public static WeakActionEventHandler<Empty, Empty, Empty, Empty, Empty, Empty>.ActionInvoker<object> argumentCount6;

        [Preserve]
        public static WeakActionEventHandler<Empty, Empty, Empty, Empty, Empty, Empty, Empty>.ActionInvoker<object> argumentCount7;

        [Preserve]
        public static WeakActionEventHandler<Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty>.ActionInvoker<object> argumentCount8;

        [Preserve]
        public static WeakActionEventHandler<Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty>.ActionInvoker<object> argumentCount9;

        [Preserve]
        public static WeakActionEventHandler<Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty>.ActionInvoker<object> argumentCount10;

        [Preserve]
        public static WeakActionEventHandler<Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty>.ActionInvoker<object> argumentCount11;

        [Preserve]
        public static WeakActionEventHandler<Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty>.ActionInvoker<object> argumentCount12;

        [Preserve]
        public static WeakActionEventHandler<Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty>.ActionInvoker<object> argumentCount13;

        [Preserve]
        public static WeakActionEventHandler<Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty>.ActionInvoker<object> argumentCount14;

        [Preserve]
        public static WeakActionEventHandler<Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty, Empty>.ActionInvoker<object> argumentCount15;
    }
}
