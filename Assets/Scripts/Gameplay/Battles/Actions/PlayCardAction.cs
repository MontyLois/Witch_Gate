using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using WitchGate.Gameplay.Cards;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class PlayCardAction : ITurnAction
    {
        private readonly BattlePhase battlePhase;


        public PlayCardAction(BattlePhase battlePhase)
        {
            this.battlePhase = battlePhase;
        }

        public async Awaitable Execute()
        {
            /*
            using (ListPool<GameCard>.Get(out List<GameCard> cards))
            {
                cards.AddRange(battlePhase.PlayedHand.Cards);
                foreach (var card in cards)
                {
                    await card.Use();
                    battlePhase.Discard.TryAddCard(card);
                }
            }
            
            battleWitch.PlayedHand.Clear();*/
        }
    }
}