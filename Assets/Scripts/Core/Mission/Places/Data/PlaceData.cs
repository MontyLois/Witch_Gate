using UnityEngine;

namespace WitchGate.Mission.Data
{
    [CreateAssetMenu(fileName = "Location", menuName = "WitchGate/Mission/Locations", order = 0)]
    public class LocationData : ScriptableObject
    {
        [field: SerializeField]
        public string id { get; private set; }
        [field: SerializeField]
        public string displayName { get; private set; }
    }
}