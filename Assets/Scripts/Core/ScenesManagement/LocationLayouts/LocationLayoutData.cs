using UnityEngine;

namespace WitchGate.Controllers.LocationLayouts
{
    [CreateAssetMenu(fileName = "newLocationLayoutData", menuName = "WitchGate/LocationLayoutDatas/LocationLayout", order = 0)]
    public class LocationLayoutData : ScriptableObject
    {
        [field: SerializeField] public Location Location { get; private set; }
        
        [Header("The main environment scene for this mode")]
        [field: SerializeField] public SceneData LocationScene { get; private set; }
    }
}