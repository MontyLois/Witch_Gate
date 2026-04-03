using UnityEngine;

namespace WitchGate.Cards
{
    [CreateAssetMenu(fileName = "NewCard", menuName = "WitchGate/Decks/Cards/CardMinorArcane", order = 0)]
    public class CardMinorArcane : CardData
    {
        public CardData lvlUpcard;
        
        public string TransformCard()
        {
            if (lvlUpcard is not null)
            {
                return lvlUpcard.ID;
            }
            return ID;
        }
    }
}