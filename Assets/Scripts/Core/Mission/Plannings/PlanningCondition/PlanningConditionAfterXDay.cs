using Codice.CM.Common.Tree;

namespace WitchGate.Mission.Plannings.PlanningCondition
{
    public class PlanningConditionAfterXDay : PlanningCondition
    {
        private int X;
        
        
        private void OnEnable()
        {
            GameState.Instance.DayChanged += CheckDay;
        }

        private void OnDisable()
        {
            GameState.Instance.DayChanged -= CheckDay;
        }

        private void CheckDay(int currentDay)
        {
            if(X<currentDay)
                return;
            isConditionValid = true;
            GameState.Instance.DayChanged -= CheckDay;
        }
    }
}