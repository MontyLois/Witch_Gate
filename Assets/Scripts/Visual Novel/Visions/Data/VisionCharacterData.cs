using System.Collections.Generic;
using cherrydev;
using UnityEngine;
using WitchGate.Cards.Collections;

namespace WitchGate.VisualNovel.Visual_Novel.Visions.Data
{
    [CreateAssetMenu(fileName = "Visions", menuName = "WitchGate/VN/Vision", order = 0)]
    public class VisionCharacterData : ScriptableObject
    {
        [field: SerializeField]
        public List<VisionSprite> visions;
        private Dictionary<CardType, Sprite> _lookup;
        [field: SerializeField] public CharacterData CharacterData { get; private set; } 

        public Sprite GetSprite(CardType cardType)
        {
            if (_lookup == null)
            {
                _lookup = new Dictionary<CardType, Sprite>();
                foreach (var e in visions)
                    _lookup[e.type] = e.sprite;
            }

            return _lookup.TryGetValue(cardType, out var sprite) ? sprite : null;
        }
    }
}