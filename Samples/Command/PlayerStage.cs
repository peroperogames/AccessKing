using System.Threading.Tasks;
using Game.Access;
using PeroTools2.AccessKing;
using UnityEngine;

namespace Game.Stage.Player
{
    public class PlayerStage : MonoBehaviour
    {
        private const string log_color = "#7FFF00";

        public void Awake()
        {
            GameCommands.Global
                .RequireHandlerFactory(typeof(GameCommands.StartPlayerStage))
                .RegisterFuncHandler(StartPlayerStageFlow);
        }

        public async Task StartPlayerStageFlow()
        {
            //模拟玩家需要一段时间才能完成的操作：
            Debug.Log($"<color={log_color}><b>Player action...</b></color>");
            await Task.Delay(3000).ConfigureAwait(false);
            Debug.Log($"<color={log_color}><b>Player stage finish.</b></color>");
        }
    }
}