using System;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Controllers;

namespace WitchGate.Players
{
    [Serializable]
    public struct CardProfile
    {
        [field: SerializeField]
        public int Level { get; private set; }
        [field: SerializeField]
        public string CardID { get; private set; }

        public CardData CardData => GameController.GameDatabase.TryGetCard(CardID, out CardData data) ? 
            data : 
            null;
    }
}