/*
 * Copyright (c) PeroPeroGames Co., Ltd.
 * Author: Gatongone
 * Created On: 2023/06/08 11:06:59
 */

using PeroTools2.AccessKing.Samples.Game.Core;

namespace PeroTools2.AccessKing.Samples.Game.Stage
{
    internal interface ICharacterStage
    {
        Character character { get; }
        void ResetHp();
        void Hurt(int damage);
    }
}