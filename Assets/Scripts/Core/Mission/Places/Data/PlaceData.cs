using UnityEngine;
using WitchGate.Controllers;

namespace WitchGate.Mission.Data
{
    [CreateAssetMenu(fileName = "Place", menuName = "WitchGate/Mission/PlacesData", order = 0)]
    public class PlaceData : ScriptableObject
    {
        [field: SerializeField]
        public Location Location { get; private set; }
        [field: SerializeField]
        public string displayName { get; private set; }
    }
}