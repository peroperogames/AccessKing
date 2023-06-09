using System;
using System.Threading.Tasks;
using PeroTools2.AccessKing.Samples.Game.Access;
using PeroTools2.AccessKing.Samples.Game.Core;
using PeroTools2.AccessKing.Samples.Game.Utils;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace PeroTools2.AccessKing.Samples.Game.Stage.Player
{
    public class PlayerStage : MonoBehaviour, ICharacterStage
    {
        private const string log_color = "#7FFF00";
        [SerializeField] private int m_Hp = 100;
        public Text TxtHP;
        public Character character => Character.Player;

        public void Awake()
        {
            GameCommands.global
                .RequireFactory(typeof(GameCommands.StartPlayerStage))
                .RegisterFuncHandler(StartPlayerStageFlow);
        }

        public void ResetHp()
        {
            m_Hp = 100;
            TxtHP.text = m_Hp.ToString();
        }
        public void Hurt(int damage)
        {
            m_Hp -= damage;
            if (m_Hp <= 0)
            {
                m_Hp = 0;
                GameEvents.global.Require<GameEvents.GameOver>().Broadcast(Character.Enemy);
            }
            TxtHP.text = m_Hp.ToString();
        }

        public async Task StartPlayerStageFlow()
        {
            //模拟玩家需要一段时间才能完成的操作：
            Debug.Log($"<color={log_color}><b>Player action...</b></color>");
            await new WaitForSeconds(3f).ToAwaitable(this);
            Debug.Log($"<color={log_color}><b>Player stage finish.</b></color>");

            GameEvents.global.Require<GameEvents.CreateDamage>().Broadcast(Character.Enemy, new Random(DateTime.Now.Millisecond).Next(15, 40));
        }
    }
}