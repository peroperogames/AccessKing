/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/02 17:06:23
 */

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
    public sealed class PlayerStage : MonoBehaviour, ICharacterStage
    {
        private const string log_color = "#7FFF00";

        [SerializeField]
        private int m_Hp = 100;

        [SerializeField]
        private Text m_TxtHp;

        public Character character => Character.Player;
        private FuncCommandHandler<Task> m_StageHandler;
        private RegistryCommandHandlerFactory m_StageFactory;

        public void Awake()
        {
            m_StageHandler = new FuncCommandHandler<Task>(StartPlayerStageFlow);
            m_StageFactory = GameCommands.global
                .Require<GameCommands.StartPlayerStage>()
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
                GameEvents.global.Require<GameEvents.GameOver>().Broadcast(Character.Enemy);
            }
            m_TxtHp.text = m_Hp.ToString();
        }

        private async Task StartPlayerStageFlow()
        {
            // Simulate a long running player action:
            Debug.Log($"<color={log_color}><b>Player action...</b></color>");
            await new WaitForSeconds(3).ToAwaitable(this);
            Debug.Log($"<color={log_color}><b>Player stage finish.</b></color>");
            // Deal damage to the enemy
            GameEvents.global.Require<GameEvents.CreateDamage>().Broadcast(Character.Enemy, new Random(DateTime.Now.Millisecond).Next(15, 40));
        }
    }
}