using UnityEngine;

namespace WitchGate.Cards
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