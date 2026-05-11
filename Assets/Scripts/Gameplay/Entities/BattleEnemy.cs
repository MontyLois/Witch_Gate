using System;
using System.Collections.Generic;
using Helteix.Cards;
using Helteix.Cards.Collections;
using UnityEngine;
using UnityEngine.Pool;
using WitchGate.Gameplay.Cards;
using WitchGate.Gameplay.Entities.Interface;
using WitchGate.Profiles.Data;
using Random = UnityEngine.Random;

namespace WitchGate.Gameplay.Entities
{
    public class BattleEnemy : BattleEntity, IBattleEnemy
    {
        public override Faction Faction { get; } = Faction.Enemy;
        public event Action<IGameCard> OnCardSelected;
        
        public Hand<IGameCard> Hand { get; private set; }
        public Deck<IGameCard> Deck { get; private set; }
        public Deck<IGameCard> Discard { get; private set; }
        
        public BattleEnemy(BattleProfile enemyProfile) : base(enemyProfile.MaxHealth, enemyProfile.Health)
        {
            Hand = new Hand<IGameCard>(2);
            Deck = new Deck<IGameCard>();
            Discard = new Deck<IGameCard>();
            
            //remplissage du deck
            foreach (var cardProfile in enemyProfile.Deck)
            {
                IGameCard gameCard = new GameCard(cardProfile);
                Deck.TryAddCard(gameCard);
            }
            Deck.Shuffle();
        }

        public IGameCard SelectRandomCardInHand()
        {
            int cardIndex = Random.Range(0, Hand.CurrentSize);
            return Hand.GetCard(cardIndex);
        }

        public void DrawMissingCards()
        {
            int missing = Hand.MaxSize - Hand.CurrentSize;
            for (int i = 0; i < missing; i++)
                DrawCard();
        }
        public void DrawCard()
        {
            if(!Deck.TryGet(out IGameCard card))
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
            using (ListPool<IGameCard>.Get(out List<IGameCard> cards))
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