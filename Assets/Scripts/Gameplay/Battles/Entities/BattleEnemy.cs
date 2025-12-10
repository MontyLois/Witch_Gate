using System.Collections.Generic;
using UnityEngine;
using WitchGate.Gameplay.Cards;
using WitchGate.Players;

namespace WitchGate.Gameplay.Battles.Entities
{
    public class BattleEnemy : BattleEntity, IBattleEnemy
    {
        public override Faction Faction { get; } = Faction.Enemy;
        private List<GameCard> cards;
        
        public BattleEnemy(EnemyProfile enemyProfile) : base(enemyProfile.MaxHealth, enemyProfile.Health)
        {
            cards = new List<GameCard>();
            foreach (var card in enemyProfile.Deck)
            {
                cards.Add(new GameCard(card.CardData));
            }
        }

        public GameCard GetRandomCard()
        {
            int randomIndex = Random.Range(0, cards.Count);
            return cards[randomIndex];
        }
    }
}