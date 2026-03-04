using System.Collections.Generic;
using System.Threading.Tasks;
using Helteix.Cards;
using UnityEngine;
using WitchGate.Gameplay.Battles.Entities;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class EnemyTurnPhase : TurnPhase
    {
        public bool IsReady { get; private set; }
        public BattleEnemy Enemy => BattlePhase.Enemy;

        private readonly ITurnAction[] possibleActions;
        public EnemyTurnPhase(BattlePhase battlePhase) : base(battlePhase)
        {
            possibleActions = new ITurnAction[Enemy.Hand.MaxSize];
        }
        protected override async Awaitable OnBegin()
        {
        }

        public async Awaitable DrawPossibleCards()
        {
            Enemy.DiscardHand();
            Enemy.DrawMissingCards();
            
            for (int i = 0; i < possibleActions.Length; i++)
            {
                EnemyAction enemyAction = new EnemyAction(Enemy.Hand.GetCard(i), BattlePhase);
                possibleActions[i] = enemyAction;
                BattlePhase.TurnTimeline.AddAction(enemyAction);
            }
            
            await Task.CompletedTask;
        }

        protected override async Awaitable Execute()
        {
            int rnd = Random.Range(0, possibleActions.Length);
            for (int i = 0; i < possibleActions.Length; i++)
            {
                if(i != rnd)
                    BattlePhase.TurnTimeline.RemoveAction(possibleActions[i]);
            }
            
            await Task.CompletedTask;
        }

        protected override async Awaitable OnEnd()
        {
            await Task.CompletedTask;
        }

    }
}