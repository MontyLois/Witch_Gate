using UnityEngine;
using WitchGate.Cards;

namespace WitchGate.Gameplay.Cards.DeckImprovement
{
    [System.Serializable]
    public class WitchCardDatas
    {
        [field: SerializeField]
        public Witch WitchName {get; set;}
        [field: SerializeField]
        public CardData[] CardDatas { get; set; }
    }
}