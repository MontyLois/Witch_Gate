using UnityEngine;


namespace WitchGate.Mission.Data
{
    [CreateAssetMenu(fileName = "CharacterID", menuName = "WitchGate/Mission/CharactersID", order = 0)]
    public class CharacterData : ScriptableObject
    {
        [field: SerializeField]
        public string id { get; private set; }
        [field: SerializeField]
        public string displayName { get; private set; }
    }
}