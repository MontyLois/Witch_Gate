using cherrydev;
using UnityEngine;
using WitchGate.Mission.Plannings.Data.PlanningCondition;
using WitchGate.Mission.Plannings.Data.PlanningFormulas;

namespace WitchGate.Mission.Plannings.Data
{
    [CreateAssetMenu(fileName = "P_", menuName = "WitchGate/Planning/PlanningContextualized", order = 0)]
    public class PlanningData : ScriptableObject
    {
        [field: SerializeField]
        public CharacterData CharacterData { get; private set; }
        [field: SerializeField]
        public EncounterContext EncounterContext { get; private set; }
        [field: SerializeField]
        public PlanningConditionData PlanningConditionData { get; private set; } 
        [field: SerializeField]
        public PlanningFormulaData PlanningFormulaData { get; private set; }
    }
}