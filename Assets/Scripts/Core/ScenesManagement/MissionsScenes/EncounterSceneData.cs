using cherrydev;
using UnityEngine;

namespace WitchGate.Controllers
{
    [CreateAssetMenu(fileName = "newEncounter", menuName = "WitchGate/SceneManagement/Encounter", order = 0)]
    public class EncounterSceneData : ScriptableObject
    {
        [field: SerializeField] public CharacterData CharacterData { get; private set; } //The character linked to the encounter
        [field: SerializeField] public SceneData MissionScene { get; private set; }
        [field: SerializeField] public Location  SceneLocation { get; private set; }
        [field: SerializeField] public int InvestigationStage { get; private set; } //at which point of the game
    }
}