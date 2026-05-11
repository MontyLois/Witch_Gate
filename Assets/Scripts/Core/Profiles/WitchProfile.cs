using System.Collections.Generic;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Profiles.Data;

namespace WitchGate.Profiles
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

        public WitchProfile(BattleWitchProfileData battleWitchProfileData)
        {
            Witch = battleWitchProfileData.Witch;
            Health = battleWitchProfileData.Health;
            MaxHealth = battleWitchProfileData.MaxHealth;
            
            Deck = new List<CardProfile>(battleWitchProfileData.Deck.Length);
            foreach (var card in battleWitchProfileData.Deck)
            {
                Deck.Add(card);
                card.witch = this.Witch;
            }
        }

        public void AddCard(CardData cardData)
        {
            Deck.Add(new CardProfile(cardData, Witch, 0));
        }
        
        public void AddCard(CardProfile cardProfile)
        {
            Deck.Add(cardProfile);
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