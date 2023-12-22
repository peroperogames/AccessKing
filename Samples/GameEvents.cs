/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/07 20:06:29
 */

using System;
using PeroTools2.AccessKing.Samples.Game.Core;

namespace PeroTools2.AccessKing.Samples.Game.Access
{
    public class GameEvents : EventSchedule<Type>
    {
        private static readonly Lazy<GameEvents> s_Instance = new(() => new GameEvents());
        public static readonly GameEvents global = s_Instance.Value;

        //Params: Character = Winner
        public class GameOver : ParameterEventBus<Character> { }
        //Params: None
        public class GameStart : ParameterEventBus { }
        //Params: Character = CurrentStage | int = Damage
        public class CreateDamage : ParameterEventBus<Character,int> { }
    }


}