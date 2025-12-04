using System;
using UnityEngine;

namespace WitchGate.Cards
{
    [CreateAssetMenu(fileName = "NewCard", menuName = "WitchGate/Cards/Card", order = 0)]
    public class CardData : ScriptableObject
    {
        [field: SerializeField]
        public Witch WitchDeck { get; private set; }
        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public string Description { get; private set; }
        [field: SerializeField]
        public CardRarity CardRarity { get; private set; }
        [field: SerializeField]
        public Sprite Icon { get; private set; }
        
        [field: SerializeField]
        public int Priority { get; private set; }
        
        [field: SerializeField, HideInInspector]
        public string ID { get; private set; }

        public void OnValidate()
        {
            if (string.IsNullOrEmpty(ID))
                ID = Guid.NewGuid().ToString();
        }
    }
}