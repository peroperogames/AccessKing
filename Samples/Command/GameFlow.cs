using System;
using System.Threading.Tasks;
using Game.Access;
using PeroTools2.AccessKing;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Core
{
    public class GameFlow : MonoBehaviour
    {
        public Button btnStartTurn;
        public Text txtTurnCount;
        private const string log_color = "#00CED1";
        private bool m_IsBattle;
        private int m_Turn;

        private void Awake()
        {
            btnStartTurn.onClick.AddListener(StartTurnAsync);
        }

        private async void StartTurnAsync()
        {
            if (m_IsBattle)
            {
                Debug.Log("Is battling");
                return;
            }

            m_IsBattle = true;
            Debug.Log($"<color={log_color}><b>[Turn {++m_Turn} started]</b></color>");

            txtTurnCount.text = m_Turn.ToString();

            await GameCommands.Global
                .Require<GameCommands.GameInit>()
                .Execute()
                .GetAllAsyncTask()
                .WhenAllDone();
            
            await GameCommands.Global
                .Require<GameCommands.StartPlayerStage>()
                .Execute()
                .GetAllAsyncTask()
                .WhenAllDone();

            await GameCommands.Global
                .Require<GameCommands.StartEnemyStage>()
                .Execute()
                .GetAllAsyncTask()
                .WhenAllDone();

            Debug.Log($"<color={log_color}><b>[Turn {m_Turn} finished]</b></color>");
            m_IsBattle = false;
        }
    }
}