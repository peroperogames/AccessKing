/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2026/10/12 10:10:00
 */

using System.Collections.Generic;

namespace PeroTools2.AccessKing;

/// <summary>
/// Decides whether two subscription owners denote the same owner and whether an owner is still alive.
/// The core assembly carries no engine dependency, so the host installs the comparer that knows its own
/// object lifetime rules. Unity installs a comparer where a destroyed <c>UnityEngine.Object</c> counts as
/// null, which is what makes a destroyed provider release its weak subscription.
/// </summary>
public static class OwnerLifetime
{
    /// <summary>
    /// Comparer used for weak subscription owners.
    /// </summary>
    public static IEqualityComparer<object> comparer { get; set; } = EqualityComparer<object>.Default;
}