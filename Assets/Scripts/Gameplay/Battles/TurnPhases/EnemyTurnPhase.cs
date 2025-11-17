using UnityEngine;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class EnemyTurnPhase : TurnPhase
    {
        public EnemyTurnPhase(BattlePhase battlePhase) : base(battlePhase)
        {
            
        }
        protected override async Awaitable OnBegin()
        {
            throw new System.NotImplementedException();
        }

        protected override async Awaitable<ITurnAction[]> Execute()
        {
            throw new System.NotImplementedException();
        }

        protected override async Awaitable OnEnd()
        {
            throw new System.NotImplementedException();
        }

    }
}