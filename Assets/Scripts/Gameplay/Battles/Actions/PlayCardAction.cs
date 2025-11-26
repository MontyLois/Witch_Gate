using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using WitchGate.Gameplay.Cards;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class PlayCardAction : ITurnAction
    {
        private readonly BattleWitch battleWitch;


        public PlayCardAction(BattleWitch battleWitch)
        {
            this.battleWitch = battleWitch;
        }

        public async Awaitable Execute()
        {
            using (ListPool<GameCard>.Get(out List<GameCard> cards))
            {
                cards.AddRange(battleWitch.PlayedHand.Cards);
                foreach (var card in cards)
                {
                    await card.Use();
                    battleWitch.Discard.TryAddCard(card);
                }
            }
            
            battleWitch.PlayedHand.Clear();
        }
    }
}