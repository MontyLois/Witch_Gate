using System;
using System.Collections.Generic;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Gameplay.Entities;
using Random = System.Random;

namespace WitchGate.Players
{
    public class WitchProfile
    {
        [field: SerializeField]
        public Witch Witch { get; private set; }
        
        [field: SerializeField, Min(0)]
        public int Health { get; private set; }
        [field: SerializeField, Min(0)]
        public int MaxHealth { get; private set; }
        [field: SerializeField]
        public List<CardProfile> Deck { get; private set; }

        public WitchProfile(BattleWitchProfile battleWitchProfile)
        {
            Witch = battleWitchProfile.Witch;
            Health = battleWitchProfile.Health;
            MaxHealth = battleWitchProfile.MaxHealth;
            
            Deck = new List<CardProfile>(battleWitchProfile.Deck.Length);
            foreach (var card in battleWitchProfile.Deck)
                Deck.Add(card);
        }

        public void AddCard(CardData cardData)
        {
            Deck.Add(new CardProfile(cardData));
        }

        public void RemoveCard(CardProfile cardProfile)
        {
            Deck.Remove(cardProfile);
        }
        
        public void LevelUpCard(CardProfile cardProfile)
        {
            cardProfile.LevelUp();
        }

        public CardProfile GetRandomCardFromDeck()
        {
            return Deck[UnityEngine.Random.Range(0, Deck.Count)];
        }
    }
}