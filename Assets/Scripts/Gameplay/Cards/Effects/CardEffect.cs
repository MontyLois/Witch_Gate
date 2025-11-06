using UnityEngine;
using WitchGate.Cards;

namespace WitchGate.Gameplay.Cards.Effects
{
    public abstract class CardEffect : ScriptableObject
    {
        [field: SerializeField]
        public CardData CardData { get; private set; }
        
        
    }
}