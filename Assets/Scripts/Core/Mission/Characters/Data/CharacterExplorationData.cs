using UnityEngine;

namespace WitchGate.Mission.Data
{
    [CreateAssetMenu(fileName = "CharacterExplorationData", menuName = "WitchGate/Characters/CharacterExploration", order = 0)]
    public class CharacterExplorationData : ScriptableObject
    {
        [field: SerializeField]
        public CharacterData CharacterData { get; private set; }
        [field: SerializeField]
        public GameObject prefab { get; private set; }
        [field: SerializeField]
        public PlaceData PlaceData { get; private set; }
    }
}