using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
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
        // For monster : in monster turn we already decide wich will be played hehe,

        public async Awaitable Execute()
        {
                var witch = gameCard.Data.WitchDeck switch
                {
                    Witch.Elaris => battlePhase.Elaris,
                    Witch.Velmora => battlePhase.Velmora,
                    Witch.All => battlePhase.Elaris,
                    _ => null,
                };

                await gameCard.Use();

                if (witch is not null)
                {
                    witch.Discard.TryAddCard(gameCard);
                    witch.DrawCard();
                }
        }
    }
}