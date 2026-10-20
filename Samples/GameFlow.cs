/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/03/30 16:03:11
 */

using PeroTools2.AccessKing.Samples.Game.Access;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PeroTools2.AccessKing.Samples.Game.Core
{
    public sealed class GameFlow : MonoBehaviour
    {
        private const string log_color = "#00CED1";
        public GameObject pnlGameOver;
        public Button btnStartTurn;
        public Button btnRestart;
        public Text txtWinner;
        public Text txtTurnCount;
        private bool m_IsBattle;
        private bool m_IsGameOver;
        private int m_Turn;
        private UnityAction m_Restart;

        private void Awake()
        {
            btnStartTurn.onClick.AddListener(StartTurnAsync);
            m_Restart = static () => GameEvents.global.Require<GameEvents.GameStart>().Broadcast();
            btnRestart.onClick.AddListener(m_Restart);
            GameEvents.global.Require<GameEvents.GameOver>().Subscribe(GameOver);
            GameEvents.global.Require<GameEvents.GameStart>().Subscribe(GameStart);
        }

        private void OnDestroy()
        {
            btnStartTurn.onClick.RemoveListener(StartTurnAsync);
            btnRestart.onClick.RemoveListener(m_Restart);
            GameEvents.global.Require<GameEvents.GameOver>().Unsubscribe(GameOver);
            GameEvents.global.Require<GameEvents.GameStart>().Unsubscribe(GameStart);
        }

        private void Start() => GameEvents.global.Require<GameEvents.GameStart>().Broadcast();

        public void GameStart()
        {
            m_IsBattle = false;
            btnStartTurn.interactable = true;
            m_IsGameOver = false;
            pnlGameOver.SetActive(false);
            m_Turn = 0;
            txtTurnCount.text = m_Turn.ToString();
        }

        public void GameOver(Character winner)
        {
            m_IsGameOver = true;
            pnlGameOver.SetActive(true);
            txtWinner.text = winner.ToString();
        }

        private async void StartTurnAsync()
        {
            Assert.IsFalse(m_IsGameOver);
            if (m_IsBattle)
            {
                Debug.Log("Is battling......");
                return;
            }

            m_IsBattle = true;
            btnStartTurn.interactable = false;
            Debug.Log($"<color={log_color}><b>[Turn {++m_Turn} started]</b></color>");

            txtTurnCount.text = m_Turn.ToString();

            // 初始化回合
            await GameCommands.global
                .Require<GameCommands.InitStage>()
                .Execute()
                .WhenAllDone();

            // 玩家回合
            await GameCommands.global
                .Require<GameCommands.StartPlayerStage>()
                .Execute()
                .WhenAllDone();

            if (m_IsGameOver)
            {
                m_IsBattle = false;
                return;
            }

            // 敌方回合
            await GameCommands.global
                .Require<GameCommands.StartEnemyStage>()
                .Execute()
                .WhenAllDone();

            if (m_IsGameOver)
            {
                m_IsBattle = false;
                return;
            }

            Debug.Log($"<color={log_color}><b>[Turn {m_Turn} finished]</b></color>");
            m_IsBattle = false;
            btnStartTurn.interactable = true;
        }
    }
}