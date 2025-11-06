using System;
using System.Collections.Generic;
using Helteix.Cards;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Gameplay.Cards.Effects;

namespace WitchGate.Gameplay.Cards
{
    [Serializable]
    public class GameCard : Card, IGameCard
    {
        [field: SerializeField]
        public CardData Data { get; private set; }

        public GameCard(CardData data)
        {
            Data = data;
        }

        public IEnumerable<CardEffect> Effects => CardManager.GetEffectsFor(Data);


        public void Use()
        {
            //TODO
        }
    }
}