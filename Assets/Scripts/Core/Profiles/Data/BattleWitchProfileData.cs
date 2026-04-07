using UnityEngine;

namespace WitchGate.Gameplay.Entities
{
    [CreateAssetMenu(fileName = "BattleWitchProfile", menuName = "WitchGate/Decks/Profiles/BattleWitchProfile", order = 0)]
    public class BattleWitchProfileData : BattleProfile
    {
        [field: SerializeField]
        public Witch Witch { get; private set; }
    }
}