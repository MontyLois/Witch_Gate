using UnityEngine;

namespace WitchGate.Mission.Plannings.Data
{
    [CreateAssetMenu(fileName = "PC_AtXInvestigationStage_", menuName = "WitchGate/Planning/PlanningConditions/AtXInvestigationStage", order = 0)]
    public class PlanningConditionDataAtXInvestigationStageData : PlanningConditionData
    {
        [field: SerializeField]
        public int X { get; private set; }
    }
}