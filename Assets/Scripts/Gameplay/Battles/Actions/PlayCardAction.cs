using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Gameplay.Cards;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class PlayCardAction : ITurnAction
    {
        private readonly BattlePhase battlePhase;
        private readonly GameCard gameCard;
        public int Priority { get; set;}

        public PlayCardAction(GameCard gameCard, BattlePhase battlePhase)
        {
            this.gameCard = gameCard;
            this.battlePhase = battlePhase;
            Priority = gameCard.Data.Priority;
        }

        // For player : need to use card, discard it and then draw a new one.
        public async Awaitable Execute()
        {
                var witch = battlePhase.GetBattleWich(gameCard.Data.WitchDeck);
                if (witch is not null)
                {
                    await gameCard.Use(TargetRegistry.Targets, witch);
                    witch.Discard.TryAddCard(gameCard);
                    witch.DrawCard();
                }
        }
    }
}