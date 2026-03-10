using UnityEngine;
using WitchGate.Mission.Plannings.PlanningsCondition;

namespace WitchGate.Mission.Plannings.Data
{
    [CreateAssetMenu(fileName = "PC_AtXInvestigationStage_", menuName = "WitchGate/Planning/PlanningConditions/AtXInvestigationStage", order = 0)]
    public class PlanningConditionDataAtXInvestigationStageData : PlanningConditionData
    {
        [field: SerializeField]
        public int X { get; private set; }

        public override PlanningCondition InitCondition()
        {
            return new PlanningConditionDataAtXInvestigationStage(X);
        }
    }
}