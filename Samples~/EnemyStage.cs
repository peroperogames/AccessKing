using System;
using PeroTools2.AccessKing.Samples.Game.Access;
using System.Threading.Tasks;
using PeroTools2.AccessKing.Samples.Game.Core;
using PeroTools2.AccessKing.Samples.Game.Utils;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace PeroTools2.AccessKing.Samples.Game.Stage.Enemy
{
    public class EnemyStage : MonoBehaviour, ICharacterStage
    {
        private const string log_color = "#FF4500";
        [SerializeField] int m_Hp = 100;
        public Text TxtHP;
        public Character character => Character.Enemy;

        public void Awake()
        {
            GameCommands.global
                .RequireFactory(typeof(GameCommands.StartEnemyStage))
                .RegisterFuncHandler(StartEnemyStageFlow);
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
                GameEvents.global.Require<GameEvents.GameOver>().Broadcast(Character.Player);
            }
            TxtHP.text = m_Hp.ToString();
        }

        private async Task StartEnemyStageFlow()
        {
            //模拟敌人需要一段时间才能完成的操作：
            Debug.Log($"<color={log_color}><b>Enemy action...</b></color>");
            await new WaitForSeconds(3f).ToAwaitable(this);
            Debug.Log($"<color={log_color}><b>Enemy stage finish.</b></color>");
            GameEvents.global.Require<GameEvents.CreateDamage>().Broadcast(Character.Player, new Random(DateTime.Now.Millisecond).Next(15, 40));
        }
    }
}