using System;
using PeroTools2.AccessKing.Samples.Game.Core;

namespace PeroTools2.AccessKing.Samples.Game.Access
{
    public class GameEvents : EventSchedule<Type>
    {
        private static readonly Lazy<GameEvents> s_Instance = new Lazy<GameEvents>(() => new GameEvents());
        public static readonly GameEvents global = s_Instance.Value;
        
        //Params: Character = Winner
        public class GameOver : ParameterEventBus<Character> { }
        //Params: None
        public class GameStart : ParameterEventBus { }
        //Params: Character = CurrentStage | int = Damage
        public class CreateDamage : ParameterEventBus<Character,int> { }
    }


}