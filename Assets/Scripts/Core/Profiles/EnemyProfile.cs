using System;
using UnityEngine;
using WitchGate.Cards;

namespace WitchGate.Profiles
{
    [Serializable]
    public struct EnemyProfile
    {
        [field: SerializeField, Min(0)]
        public int Health { get; private set; }
        [field: SerializeField, Min(0)]
        public int MaxHealth { get; private set; }
        [field: SerializeField]
        public CardProfile[] Deck { get; private set; }
    }
}