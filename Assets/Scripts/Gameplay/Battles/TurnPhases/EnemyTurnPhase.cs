using System.Collections.Generic;
using UnityEngine;
using WitchGate.Gameplay.Battles.Entities;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class EnemyTurnPhase : TurnPhase
    {
        public bool IsReady { get; private set; }
        public BattleEnemy Enemy => BattlePhase.Enemy;
        
        public EnemyTurnPhase(BattlePhase battlePhase) : base(battlePhase)
        {
            
        }
        protected override async Awaitable OnBegin()
        {
            Enemy.DiscardHand();
        }

        protected override async Awaitable<List<ITurnAction>> Execute()
        {
            Enemy.DrawMissingCards();
            await Awaitable.NextFrameAsync();
            List<ITurnAction> turnActions = new List<ITurnAction>();
            Debug.Log("nb of monster action before choosing : "+turnActions.Count);
            turnActions.Add(new EnemyAction(Enemy.SelectRandomCardInHand(),BattlePhase));
            Debug.Log("nb of monster action after choosing : "+turnActions.Count);
            return turnActions;
        }

        protected override async Awaitable OnEnd()
        {
            
        }

    }
}