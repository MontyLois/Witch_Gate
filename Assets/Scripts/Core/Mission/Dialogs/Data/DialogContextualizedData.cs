using System.Collections.Generic;
using cherrydev;
using UnityEngine;

namespace WitchGate.Mission
{
    [CreateAssetMenu(fileName = "DialogContextualized", menuName = "WitchGate/Mission/DialogContextualized", order = 0)]
    public class DialogContextualizedData : ScriptableObject
    {
        [field: SerializeField] public CharacterData CharacterData { get; private set; }
        [field: SerializeField] public EncounterContext EncounterContext { get; private set; }
        [field: SerializeField] public int InvestigationStage { get; private set; }
        [field: SerializeField] public List<DialogNodeGraph> DialogBehaviours { get; private set; }
    }
}