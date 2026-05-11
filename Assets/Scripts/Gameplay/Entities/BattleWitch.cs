using System.Collections.Generic;
using Helteix.Cards;
using Helteix.Cards.Collections;
using UnityEngine;
using UnityEngine.Pool;
using WitchGate.Controllers;
using WitchGate.Gameplay.Cards;
using WitchGate.Profiles;

namespace WitchGate.Gameplay.Entities
{
    public class BattleWitch : BattleEntity
    {
        public Witch WitchName { get; private set; }
        public override Faction Faction { get; } = Faction.Witch;
        public Hand<IGameCard> Hand { get; private set; }
        public Deck<IGameCard> Deck { get; private set; }
        public Deck<IGameCard> Discard { get; private set; }
        
        public BattleWitch(WitchProfile profile) : base(profile.MaxHealth, profile.Health)
        {
            Hand = new Hand<IGameCard>(GameController.Metrics.MaxBattleHandSize);
            Deck = new Deck<IGameCard>();
            Discard = new Deck<IGameCard>();
            WitchName = profile.Witch;
            
            //remplissage du deck
            foreach (var cardProfile in profile.Deck)
            {
                IGameCard gameCard = new GameCard(cardProfile);
                Deck.TryAddCard(gameCard);
            }
            Deck.Shuffle();
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
                Debug.Log(cards.Count);
                foreach (var card in cards)
                {
                    Debug.Log(card.ToString());
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