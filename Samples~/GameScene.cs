using System.Collections.Generic;
using System.Linq;
using PeroTools2.AccessKing.Samples.Game.Access;
using PeroTools2.AccessKing.Samples.Game.Core;
using UnityEngine;

namespace PeroTools2.AccessKing.Samples.Game.Stage
{
    public class GameScene : MonoBehaviour
    {
        private const string log_color = "#FFA500";
        private bool hasInit;
        private Dictionary<Character, ICharacterStage> m_StageMaps = new Dictionary<Character, ICharacterStage>();

        public void Awake()
        {
            GameCommands.global.RequireFactory(typeof(GameCommands.InitStage)).RegisterActionHandler(InitStage);
            GameEvents.global.Require<GameEvents.GameStart>().Subscribe(ResetStage);
            GameEvents.global.Require<GameEvents.CreateDamage>().Subscribe(CalculateDamage);
        }

        private void ResetStage() => hasInit = false;

        private void CalculateDamage(Character target, int damage) => m_StageMaps[target].Hurt(damage);


        public void InitStage()
        {
            if (!hasInit)
            {
                Debug.Log($"<color={log_color}><b>GameInit!</b></color>");
                hasInit = true;
                m_StageMaps = GetComponents<ICharacterStage>().ToDictionary(stage => stage.character);
            }
        }
    }
}