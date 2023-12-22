/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/02 16:06:18
 */

using System;

namespace PeroTools2.AccessKing.Samples.Game.Access
{
    public class GameCommands : CommandSchedule<Type>
    {
        private static readonly Lazy<GameCommands> s_Instance = new(()=>new GameCommands());
        public static readonly GameCommands global = s_Instance.Value;

        #region CommandLists

        public class InitStage : ParameterCommandBus { }
        public class StartPlayerStage : ParameterCommandBus { }
        public class StartEnemyStage : ParameterCommandBus { }

        #endregion
    }
}