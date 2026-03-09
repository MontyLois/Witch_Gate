using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace cherrydev
{
    [CreateAssetMenu(fileName = "VNCharacterData", menuName = "WitchGate/Characters/VNCharacter", order = 0)]
    public class VNCharacterData : ScriptableObject
    {
        [field: SerializeField]
        public List<ExpressionSprite> expressions;
        private Dictionary<Expression, Sprite> _lookup;
        [field: SerializeField] public CharacterData CharacterData { get; private set; } 
        public String Name => CharacterData.displayName;

        public Sprite GetSprite(Expression expression)
        {
            if (_lookup == null)
            {
                _lookup = new Dictionary<Expression, Sprite>();
                foreach (var e in expressions)
                    _lookup[e.expression] = e.sprite;
            }

            return _lookup.TryGetValue(expression, out var sprite) ? sprite : null;
        }
    }
}