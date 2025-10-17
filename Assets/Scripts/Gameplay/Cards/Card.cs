using System;
using System.Collections.Generic;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Gameplay.Cards.Effects;

namespace WitchGate.Gameplay.Cards
{
    [Serializable]
    public class Card : ICard
    {
        [field: SerializeField]
        public CardData Data { get; private set; }

        public Card(CardData data)
        {
            Data = data;
        }

        public IEnumerable<CardEffect> Effects => CardManager.GetEffectsFor(Data);
        
        
    }
}