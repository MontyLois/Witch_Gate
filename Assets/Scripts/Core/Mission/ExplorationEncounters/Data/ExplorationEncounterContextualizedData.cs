using cherrydev;
using UnityEngine;
using WitchGate.ScenesManagement.Scenes;

namespace WitchGate.Mission.ExplorationEncounters.Data
{
    [CreateAssetMenu(fileName = "ExplorationEncounterContextualizedData", menuName = "WitchGate/Characters/ExplorationEncounter", order = 0)]
    public class ExplorationEncounterContextualizedData : ScriptableObject
    {
        [field: SerializeField] public CharacterData CharacterData { get; private set; } //The character linked to the encounter
        [field: SerializeField] public Location Location { get; private set; } //in which city district
        [field: SerializeField] public int InvestigationStage { get; private set; } //at which point of the game
        [field: SerializeField] public SceneData EncounterScene { get; private set; } //the additive scene
    }
}