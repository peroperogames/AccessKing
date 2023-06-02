using System;
using PeroTools2.AccessKing;

namespace Game.Access
{
    public class GameCommands : CommandSchedule<Type, RegistryCommandHandlerFactory>
    {
        private static readonly Lazy<GameCommands> s_Instance = new Lazy<GameCommands>(()=>new GameCommands());
        public static GameCommands Global = s_Instance.Value;

        #region CommandLists
        
        public class GameInit : ParameterCommandBus { }
        public class StartPlayerStage : ParameterCommandBus { }
        public class StartEnemyStage : ParameterCommandBus { }
        
        #endregion
    }
}