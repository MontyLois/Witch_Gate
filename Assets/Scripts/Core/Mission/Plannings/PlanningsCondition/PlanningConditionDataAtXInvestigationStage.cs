using WitchGate.Controllers;

namespace WitchGate.Mission.Plannings.PlanningsCondition
{
    public class PlanningConditionDataAtXInvestigationStage : PlanningCondition
    {
        private int x;

        public PlanningConditionDataAtXInvestigationStage(int x)
        {
            this.x = x;
            if(x<GameController.Investigation.CurrentStage)
                isConditionValid = true;
        }
        private void OnEnable()
        {
            GameController.InvestigationChanged += CheckInvestigationStage;
        }

        private void OnDisable()
        {
            GameController.InvestigationChanged -= CheckInvestigationStage;
        }

        private void CheckInvestigationStage(int currentInvestigationStage)
        {
            if(x>currentInvestigationStage)
                return;
            isConditionValid = true;
            GameController.InvestigationChanged -= CheckInvestigationStage;
        }
    }
}