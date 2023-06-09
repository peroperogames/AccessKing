using PeroTools2.AccessKing.Samples.Game.Core;
using UnityEngine.UI;

namespace PeroTools2.AccessKing.Samples.Game.Stage
{
    public interface ICharacterStage
    {
        Character character { get; }
        void ResetHp();
        void Hurt(int damage);
    }
}