using System;
using System.Collections.Generic;
using Helteix.Cards;
using Helteix.Cards.Collections;
using UnityEngine;
using UnityEngine.Pool;
using WitchGate.Gameplay.Cards;
using WitchGate.Gameplay.Entities;
using WitchGate.Players;
using Random = UnityEngine.Random;

namespace WitchGate.Gameplay.Battles.Entities
{
    public class BattleEnemy : BattleEntity, IBattleEnemy
    {
        public override Faction Faction { get; } = Faction.Enemy;
        public event Action<GameCard> OnCardSelected;
        
        public Hand<GameCard> Hand { get; private set; }
        public Deck<GameCard> Deck { get; private set; }
        public Deck<GameCard> Discard { get; private set; }
        
        public BattleEnemy(BattleProfile enemyProfile) : base(enemyProfile.MaxHealth, enemyProfile.Health)
        {
            Hand = new Hand<GameCard>(2);
            Deck = new Deck<GameCard>();
            Discard = new Deck<GameCard>();
            
            //remplissage du deck
            foreach (var cardProfile in enemyProfile.Deck)
            {
                var data = cardProfile.CardData;
                GameCard gameCard = new GameCard(data, cardProfile.Level);
                Deck.TryAddCard(gameCard);
            }
            Deck.Shuffle();
        }

        public GameCard SelectRandomCardInHand()
        {
            int cardIndex = Random.Range(0, Hand.CurrentSize);
            return Hand.GetCard(cardIndex);
        }

        public void DrawMissingCards()
        {
            int missing = Hand.MaxSize - Hand.CurrentSize;
            for (int i = 0; i < missing; i++)
            {
                DrawCard();
            }
        }
        public void DrawCard()
        {
            if(!Deck.TryGet(out GameCard card))
            {
                while (Discard.TryGet(out var discardCard))
                    Deck.TryAddCard(discardCard);
                Deck.Shuffle();

                if (!Deck.TryGet(out card))
                {
                    Debug.LogError("??");
                    return;
                }
            }
            Hand.TryAddCard(card);
        }

        public void DiscardHand()
        {
            using (ListPool<GameCard>.Get(out List<GameCard> cards))
            {
                cards.AddRange(Hand.Cards);
                foreach (var card in cards)
                {
                    Discard.TryAddCard(card);
                }
            }
        }
        
        public override void OnEndTurn()
        {
            base.OnEndTurn();
            if (CurrentHealth == 0)
            {
                DamageModifiers.Clear();
                DiscardHand();
                
                TargetRegistry.Unregister(this);
            }
        }
    }
}