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

        public CardData CardData
        {
            get
            {
                if (GameController.GameDatabase.TryGetCard(CardID, out CardData data))
                    return data;
                
                return null;
            }
        }
        
        public CardProfile(CardData other)
        {
            Level = 0;
            CardID = other.ID;
        }

        public void LevelUp()
        {
            Level++;
        }
    }
}