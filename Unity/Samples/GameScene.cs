/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/02 17:06:11
 */

using System.Collections.Generic;
using System.Linq;
using PeroTools2.AccessKing.Samples.Game.Access;
using PeroTools2.AccessKing.Samples.Game.Core;
using UnityEngine;

namespace PeroTools2.AccessKing.Samples.Game.Stage
{
    public sealed class GameScene : MonoBehaviour
    {
        private const string log_color = "#FFA500";
        private bool m_HasInit;
        private Dictionary<Character, ICharacterStage> m_StageMaps = new();
        private ActionCommandHandler m_InitStageHandler;
        private RegistryCommandHandlerFactory m_InitStageFactory;

        public void Awake()
        {
            m_InitStageHandler = new ActionCommandHandler(InitStage);
            m_InitStageFactory = GameCommands.global.Require<GameCommands.InitStage>().RequireFactory<RegistryCommandHandlerFactory>();
            m_InitStageFactory.RegisterHandler(m_InitStageHandler);
            GameEvents.global.Require<GameEvents.GameStart>().Subscribe(ResetStage);
            GameEvents.global.Require<GameEvents.CreateDamage>().Subscribe(CalculateDamage);
        }

        private void OnDestroy()
        {
            m_InitStageFactory.UnregisterHandler(m_InitStageHandler);
            GameEvents.global.Require<GameEvents.GameStart>().Unsubscribe(ResetStage);
            GameEvents.global.Require<GameEvents.CreateDamage>().Unsubscribe(CalculateDamage);
        }

        private void ResetStage()
        {
            m_HasInit = false;
            foreach (var stage in m_StageMaps.Values)
            {
                stage.ResetHp();
            }
        }

        private void CalculateDamage(Character target, int damage) => m_StageMaps[target].Hurt(damage);

        private void InitStage()
        {
            if (!m_HasInit)
            {
                Debug.Log($"<color={log_color}><b>GameInit!</b></color>");
                m_HasInit = true;
                m_StageMaps = GetComponents<ICharacterStage>().ToDictionary(stage => stage.character);
            }
        }
    }
}