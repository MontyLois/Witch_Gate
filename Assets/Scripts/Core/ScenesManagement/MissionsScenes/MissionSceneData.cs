using UnityEngine;

namespace WitchGate.Controllers
{
    [CreateAssetMenu(fileName = "newMission", menuName = "WitchGate/Missions/Mission", order = 0)]
    public class MissionSceneData : ScriptableObject
    {
        [field: SerializeField] public string MissionName { get; private set; }
        [field: SerializeField] public SceneData MissionScene { get; private set; }
        [field: SerializeField] public Location  SceneLocation { get; private set; }
    }
}