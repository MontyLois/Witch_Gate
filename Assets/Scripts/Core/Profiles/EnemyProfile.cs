using System;
using UnityEngine;

namespace WitchGate.Players
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