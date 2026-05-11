using UnityEngine;
using WitchGate.Cards;

namespace WitchGate.Profiles.Data
{
    [CreateAssetMenu(fileName = "BattleProfile", menuName = "WitchGate/Decks/Profiles/BattleProfile", order = 0)]
    public class BattleProfile : ScriptableObject
    {
        [field: SerializeField, Min(0)]
        public int Health { get; private set; }
        [field: SerializeField, Min(0)]
        public int MaxHealth { get; private set; }
        [field: SerializeField]
        public CardProfile[] Deck { get; private set; }
    }
}