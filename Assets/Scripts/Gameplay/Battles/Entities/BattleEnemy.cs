using System;
using System.Collections.Generic;
using WitchGate.Gameplay.Cards;
using WitchGate.Players;
using Random = UnityEngine.Random;

namespace WitchGate.Gameplay.Battles.Entities
{
    public class BattleEnemy : BattleEntity, IBattleEnemy
    {
        public override Faction Faction { get; } = Faction.Enemy;
        private List<GameCard> cards;
        public GameCard[] selectedCards;
        
        public event Action<GameCard> OnCardSelected;
        
        public BattleEnemy(EnemyProfile enemyProfile) : base(enemyProfile.MaxHealth, enemyProfile.Health)
        {
            cards = new List<GameCard>();
            selectedCards = new GameCard[2];
            foreach (var card in enemyProfile.Deck)
            {
                cards.Add(new GameCard(card.CardData));
            }
        }

        public void SelectCards()
        {
            
        }

        public GameCard GetRandomCard()
        {
            int randomIndex = Random.Range(0, cards.Count);
            return cards[randomIndex];
        }
    }
}