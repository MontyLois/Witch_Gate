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

        public PlayCardAction(GameCard gameCard)
        {
            this.gameCard = gameCard;
        }

        // For player : need to use card, discard it and then draw a new one.
        // For monster : in monster turn we already decide wich will be played hehe,
        // so only need to remove first "card" and use the other one. And ! uh yes make it null;
        public async Awaitable Execute()
        {
            using (ListPool<GameCard>.Get(out List<GameCard> cards))
            {
                var discard = gameCard.Data.WitchDeck switch
                {
                    Witch.Elaris => battlePhase.Elaris.Discard,
                    Witch.Velmora => battlePhase.Velmora.Discard,
                    Witch.All => battlePhase.Elaris.Discard,
                    _ => null,
                };
                
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
}