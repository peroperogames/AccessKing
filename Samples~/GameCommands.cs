using System;

namespace PeroTools2.AccessKing.Samples.Game.Access
{
    public class GameCommands : CommandSchedule<Type, RegistryCommandHandlerFactory>
    {
        private static readonly Lazy<GameCommands> s_Instance = new Lazy<GameCommands>(()=>new GameCommands());
        public static readonly GameCommands global = s_Instance.Value;
        
        public GameCommands(){ }

        #region CommandLists
        
        public class InitStage : ParameterCommandBus { }
        public class StartPlayerStage : ParameterCommandBus { }
        public class StartEnemyStage : ParameterCommandBus { }
        
        #endregion
    }
}