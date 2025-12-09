using System.Collections.Generic;
using UnityEngine;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class EnemyTurnPhase : TurnPhase
    {
        public bool IsReady { get; private set; }
        public EnemyTurnPhase(BattlePhase battlePhase) : base(battlePhase)
        {
            
        }
        protected override async Awaitable OnBegin()
        {
            
        }

        protected override async Awaitable<List<ITurnAction>> Execute()
        {
            while (!IsReady)
                await Awaitable.NextFrameAsync();
            
            return null;
        }

        protected override async Awaitable OnEnd()
        {
            
        }

    }
}