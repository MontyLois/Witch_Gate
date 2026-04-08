using UnityEngine;

namespace WitchGate.Controllers
{
    [CreateAssetMenu(fileName = "newEncounter", menuName = "WitchGate/SceneManagement/Encounter", order = 0)]
    public class EncounterSceneData : ScriptableObject
    {
        [field: SerializeField] public string MissionName { get; private set; }
        [field: SerializeField] public SceneData MissionScene { get; private set; }
        [field: SerializeField] public Location  SceneLocation { get; private set; }
    }
}