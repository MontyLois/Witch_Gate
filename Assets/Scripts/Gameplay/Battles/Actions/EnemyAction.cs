using System.Collections.Generic;
using UnityEngine;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Gameplay.Battles.Entities.Interface;
using WitchGate.Gameplay.Cards;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class EnemyAction : ITurnAction
    {
        public int Priority { get; set; }
        private readonly GameCard gameCard;
        private readonly BattlePhase battlePhase;
        
        public EnemyAction(GameCard gameCard, BattlePhase battlePhase)
        {
            this.gameCard = gameCard;
            this.battlePhase = battlePhase;
            Priority = gameCard.Data.Priority;
        }
        public async Awaitable Execute()
        {
            await gameCard.Use(GetTargetedWitch(), battlePhase.Enemy);
        }

        private List<ICanFight> GetTargetedWitch()
        {
            List<ICanFight> target = new List<ICanFight>();
            switch (gameCard.Data.WitchDeck)
            {
                case Witch.Elaris:
                    target.Add(battlePhase.Elaris);
                    break;

                case Witch.Velmora:
                    target.Add(battlePhase.Velmora);
                    break;

                case Witch.All:
                    target.Add(battlePhase.Elaris);
                    target.Add(battlePhase.Velmora);
                    break;
            }
            target.Add(battlePhase.Enemy);
            return target;
        }
    }
}