using System.Threading.Tasks;
using Game.Access;
using PeroTools2.AccessKing;
using UnityEngine;

namespace Game.Stage.Enemy
{
    public class EnemyStage : MonoBehaviour
    {
        private const string log_color = "#FF4500";
        public void Awake()
        {
            GameCommands.global
                .RequireFactory(typeof(GameCommands.StartEnemyStage))
                .RegisterFuncHandler(StartEnemyStageFlow);
        }

        public async Task StartEnemyStageFlow()
        {
            //模拟敌人需要一段时间才能完成的操作：
            Debug.Log($"<color={log_color}><b>Enemy action...</b></color>");
            await Task.Delay(3000).ConfigureAwait(false);
            Debug.Log($"<color={log_color}><b>Enemy stage finish.</b></color>");
        }
    }
}