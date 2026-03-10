using Codice.CM.Common.Tree;
using WitchGate.Controllers;

namespace WitchGate.Mission.Plannings.PlanningsCondition
{
    public class PlanningConditionAfterXDay : PlanningCondition
    {
        private int x;

        public PlanningConditionAfterXDay(int x)
        {
            this.x = x;
            if(x<GameController.CurrentDay)
                isConditionValid = true;
        }
        
        private void OnEnable()
        {
            GameController.DayChanged += CheckDay;
        }

        private void OnDisable()
        {
            GameController.DayChanged -= CheckDay;
        }

        private void CheckDay(int currentDay)
        {
            if(x>currentDay)
                return;
            isConditionValid = true;
            GameController.DayChanged -= CheckDay;
        }
    }
}