/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/07 20:06:29
 */

using System;
using PeroTools2.AccessKing.Samples.Game.Core;

namespace PeroTools2.AccessKing.Samples.Game.Access
{
    public sealed class GameEvents : EventSchedule<Type>
    {
        private static readonly Lazy<GameEvents> s_Instance = new(() => new GameEvents());
        internal static readonly GameEvents global = s_Instance.Value;

        //Params: Character = Winner
        internal sealed class GameOver : ParameterEventBus<Character> { }

        //Params: None
        internal sealed class GameStart : ParameterEventBus { }

        //Params: Character = CurrentStage | int = Damage
        internal sealed class CreateDamage : ParameterEventBus<Character, int> { }
    }
}