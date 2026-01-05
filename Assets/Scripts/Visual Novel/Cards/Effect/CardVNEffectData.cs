using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WitchGate.Cards;

namespace WitchGate.Gameplay.Cards.Effects
{
    public abstract class CardVNEffectData : ScriptableObject
    {
        [field: SerializeField]
        public CardData CardData { get; private set; }

        [field: SerializeField]
        public String vision { get; private set; }

        public void AffectTarget(TMP_Text text)
        {
            ApplyEffect(text);
        }
        
        protected abstract void ApplyEffect(TMP_Text text);
    }
}