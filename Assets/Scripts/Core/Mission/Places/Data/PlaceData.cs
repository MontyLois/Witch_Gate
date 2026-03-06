using UnityEngine;

namespace WitchGate.Mission.Data
{
    [CreateAssetMenu(fileName = "Place", menuName = "WitchGate/Mission/PlacesData", order = 0)]
    public class PlaceData : ScriptableObject
    {
        [field: SerializeField]
        public string id { get; private set; }
        [field: SerializeField]
        public string displayName { get; private set; }
    }
}