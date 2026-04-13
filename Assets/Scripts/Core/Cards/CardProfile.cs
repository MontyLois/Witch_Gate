using System;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Serialization;
using WitchGate.Cards;
using WitchGate.Controllers;

namespace WitchGate.Players
{
    [Serializable]
    public class CardProfile
    {
        [field: SerializeField]
        public int Level { get; private set; }
        [field: SerializeField]
        public string CardID { get; private set; }

        [FormerlySerializedAs("Witch")] public Witch witch;

        public CardData CardData
        {
            get
            {
                if (GameController.GameDatabase.TryGetCard(CardID, out CardData data))
                    return data;
                
                return null;
            }
        }
        
        public CardProfile(CardData other, Witch witch, int level)
        {
            Level = level;
            CardID = other.ID;
            this.witch = witch;
        }

        public void LevelUp()
        {
            if (CardData is CardMinorArcane)
            {
                CardID = (CardData as CardMinorArcane)?.TransformCard();
            }
            Level++;
        }
    }
}