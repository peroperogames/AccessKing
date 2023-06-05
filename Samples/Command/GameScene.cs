using Game.Access;
using Game.Stage.Enemy;
using Game.Stage.Player;
using PeroTools2.AccessKing;
using UnityEngine;

namespace Game.Stage
{
    public class GameScene : MonoBehaviour
    {
        private const string log_color = "#FFA500";
        private bool hasInit;
        public void Awake()
        {
            GameCommands.global.RequireHandlerFactory(typeof(GameCommands.GameInit)).RegisterActionHandler(GameInit);
        }

        public void GameInit()
        {
            if(!hasInit)
            {
                Debug.Log($"<color={log_color}><b>GameInit!</b></color>");
                new GameObject("EnemyStage").AddComponent<EnemyStage>();
                new GameObject("PlayerStage").AddComponent<PlayerStage>();
                hasInit = true;
            }
        }

    }
}