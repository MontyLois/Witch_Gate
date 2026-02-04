
using UnityEngine;
using WitchGate.Visual_Novel.Enums;
using WitchGate.VisualNovel.Visual_Novel.Dialog;

namespace cherrydev
{
    [System.Serializable]
    public struct Sentence
    {
        public string CharacterName;
        public string Text;
        public Sprite CharacterSprite;
        public VNCharacterData CharacterData;
        public Expression expression;

        public Sentence(string characterName, string text)
        {
            CharacterSprite = null;
            CharacterName = characterName;
            Text = text;
            CharacterData = null;
            expression = Expression.Neutral;
        }
    }
}