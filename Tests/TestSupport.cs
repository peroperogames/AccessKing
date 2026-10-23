/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2026/10/20 21:40:00
 */

using System;

namespace PeroTools2.AccessKing.Tests;

internal sealed class Counter : INotification;

internal sealed class NineHandler : ICommandHandler<Counter>, IResultAvailable<int>
{
    public void Handle(ref Counter notification)
    {
    }

    public int GetResult() => 9;

    object IResultAvailable.GetResult() => GetResult();
}

internal sealed class ThrowingCommandHandler : ICommandHandler<Counter>
{
    public void Handle(ref Counter notification) => throw new InvalidOperationException("handler failure");
}