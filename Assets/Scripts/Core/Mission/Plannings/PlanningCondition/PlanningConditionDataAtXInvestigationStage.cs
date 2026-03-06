namespace WitchGate.Mission.Plannings.PlanningCondition
{
    public class PlanningConditionDataAtXInvestigationStage : PlanningCondition
    {
        private int X;
        
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