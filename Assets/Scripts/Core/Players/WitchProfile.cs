using System;
using System.Collections.Generic;
using UnityEngine;
using WitchGate.Cards;

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
        public CardProfile[] Deck { get; private set; }
    }
}