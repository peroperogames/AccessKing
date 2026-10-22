/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2026/10/12 10:10:00
 */

using System.Collections.Generic;
using UnityEngine;

namespace PeroTools2.AccessKing
{
    /// <summary>
    /// Installs the <c>UnityEngine.Object</c> aware owner comparer used by the core assembly.
    /// </summary>
    internal static class UnityOwnerLifetime
    {
        /// <summary>
        /// Install before any scene is loaded, so no weak subscription is created with the reference semantics.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Install() => OwnerLifetime.comparer = UnityOwnerComparer.instance;

        /// <summary>
        /// Compares owners the way <c>UnityEngine.Object</c> does: a destroyed object equals null.
        /// </summary>
        private sealed class UnityOwnerComparer : IEqualityComparer<object>
        {
            /// <summary>
            /// Shared instance.
            /// </summary>
            internal static readonly UnityOwnerComparer instance = new();

            bool IEqualityComparer<object>.Equals(object a, object b) => ReferenceEquals(a, b) || (a is not null && a.Equals(b));

            int IEqualityComparer<object>.GetHashCode(object o) => o?.GetHashCode() ?? 0;
        }
    }
}
