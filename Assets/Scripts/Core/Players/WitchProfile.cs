using System;
using System.Collections.Generic;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Gameplay.Entities;

namespace WitchGate.Players
{
    [System.Serializable]
    public struct WitchProfile
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
                Deck.Add(new CardProfile(card));
        }
    }
}