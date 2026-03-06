using UnityEngine;

namespace WitchGate.Mission.Plannings.Data
{
    [CreateAssetMenu(fileName = "PC_AtXInvestigationStage_", menuName = "WitchGate/Planning/PlanningConditions/AtXInvestigationStage", order = 0)]
    public class PlanningConditionAtXInvestigationStageData : PlanningCondition
    {
        [field: SerializeField]
        public int X { get; private set; }
        
        private void OnEnable()
        {
            GameState.Instance.InvestigationChanged += CheckInvestigationStage;
        }

        private void OnDisable()
        {
            GameState.Instance.InvestigationChanged -= CheckInvestigationStage;
        }

        private void CheckInvestigationStage(int currentInvestigationStage)
        {
            if(X<currentInvestigationStage)
                return;
            isConditionValid = true;
            GameState.Instance.InvestigationChanged -= CheckInvestigationStage;
        }
    }
}