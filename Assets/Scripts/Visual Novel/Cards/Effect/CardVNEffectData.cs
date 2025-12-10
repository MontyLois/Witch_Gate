using System.Collections.Generic;
using UnityEngine;
using WitchGate.Cards;

namespace WitchGate.Gameplay.Cards.Effects
{
    [CreateAssetMenu(fileName = "newCardVNEffect", menuName = "WitchGate/Cards/VNEffects", order = 0)]
    public abstract class CardVNEffectData : ScriptableObject
    {
        [field: SerializeField]
        public CardData CardData { get; private set; }

        protected abstract void ApplyEffect();
    }
}