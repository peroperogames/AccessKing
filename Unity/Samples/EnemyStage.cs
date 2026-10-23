/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/02 17:06:07
 */

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
    public sealed class EnemyStage : MonoBehaviour, ICharacterStage
    {
        private const string log_color = "#FF4500";

        [SerializeField]
        private int m_Hp = 100;

        [SerializeField]
        private Text m_TxtHp;

        public Character character => Character.Enemy;
        private FuncCommandHandler<Task> m_StageHandler;
        private RegistryCommandHandlerFactory m_StageFactory;

        public void Awake()
        {
            m_StageHandler = new FuncCommandHandler<Task>(StartEnemyStageFlow);
            m_StageFactory = GameCommands.global
                .Require<GameCommands.StartEnemyStage>()
                .RequireFactory<RegistryCommandHandlerFactory>();
            m_StageFactory.RegisterHandler(m_StageHandler);
        }

        private void OnDestroy()
        {
            m_StageFactory.UnregisterHandler(m_StageHandler);
        }

        public void ResetHp()
        {
            m_Hp = 100;
            m_TxtHp.text = m_Hp.ToString();
        }

        public void Hurt(int damage)
        {
            m_Hp -= damage;
            if (m_Hp <= 0)
            {
                m_Hp = 0;
                GameEvents.global.Require<GameEvents.GameOver>().Broadcast(Character.Player);
            }
            m_TxtHp.text = m_Hp.ToString();
        }

        private async Task StartEnemyStageFlow()
        {
            // Simulate a long running enemy action:
            Debug.Log($"<color={log_color}><b>Enemy action...</b></color>");
            await new WaitForSeconds(3).ToAwaitable(this);
            Debug.Log($"<color={log_color}><b>Enemy stage finish.</b></color>");
            // Deal damage to the player
            GameEvents.global.Require<GameEvents.CreateDamage>().Broadcast(Character.Player, new Random(DateTime.Now.Millisecond).Next(15, 40));
        }
    }
}