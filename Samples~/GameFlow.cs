using PeroTools2.AccessKing.Samples.Game.Access;
using PeroTools2.AccessKing.Samples.Game.Core;
using UnityEngine;
using UnityEngine.UI;

namespace PeroTools2.AccessKing.Game.Core
{
    public class GameFlow : MonoBehaviour
    {
        public GameObject PnlGameOver;
        public Button btnStartTurn;
        public Button btnRestart;
        public Text txtWinner;
        public Text txtTurnCount;
        private const string log_color = "#00CED1";
        private bool m_IsBattle;
        private bool m_IsGameOver;
        private int m_Turn;

        private void Awake()
        {
            btnStartTurn.onClick.AddListener(StartTurnAsync);
            btnRestart.onClick.AddListener(()=> GameEvents.global.Require<GameEvents.GameStart>().Broadcast());
            GameEvents.global.Require<GameEvents.GameOver>().Subscribe(GameOver);
            GameEvents.global.Require<GameEvents.GameStart>().Subscribe(GameStart);
        }

        private void Start() => GameEvents.global.Require<GameEvents.GameStart>().Broadcast();

        public void GameStart()
        {
            m_IsGameOver = false;
            PnlGameOver.SetActive(false);
            m_Turn = 0;
        }

        public void GameOver(Character winner)
        {
            m_IsGameOver = true;
            PnlGameOver.SetActive(true);
            txtWinner.text = winner.ToString();
        }

        private async void StartTurnAsync()
        {
            if (m_IsBattle)
            {
                Debug.Log("Is battling......");
                return;
            }

            m_IsBattle = true;
            Debug.Log($"<color={log_color}><b>[Turn {++m_Turn} started]</b></color>");

            txtTurnCount.text = m_Turn.ToString();

            await GameCommands.global
                .Require<GameCommands.InitStage>()
                .Execute()
                .GetAllAsyncTask()
                .WhenAllDone();

            await GameCommands.global
                .Require<GameCommands.StartPlayerStage>()
                .Execute()
                .GetAllAsyncTask()
                .WhenAllDone();

            if (m_IsGameOver)
                return;
            
            await GameCommands.global
                .Require<GameCommands.StartEnemyStage>()
                .Execute()
                .GetAllAsyncTask()
                .WhenAllDone();
            
            if (m_IsGameOver)
                return;

            Debug.Log($"<color={log_color}><b>[Turn {m_Turn} finished]</b></color>");
            m_IsBattle = false;
        }
    }
}