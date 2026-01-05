using UnityEngine;

namespace WitchGate.Gameplay.Entities
{
    [CreateAssetMenu(fileName = "BattleWitchProfile", menuName = "WitchGate/Profiles/BattleWitchProfile", order = 0)]
    public class BattleWitchProfile : BattleProfile
    {
        [field: SerializeField]
        public Witch Witch { get; private set; }
    }
}