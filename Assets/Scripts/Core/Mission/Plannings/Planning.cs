using WitchGate.Mission.Plannings.Data;
using WitchGate.Mission.Plannings.PlanningCondition;

namespace WitchGate.Mission.Plannings
{
    public class Planning
    {
        private PlanningCondition.PlanningCondition PlanningCondition;
        private EncounterContext EncounterContext;
        private PlanningFormula PlanningFormula;
        public int FirstEncounterDay;
        
        public bool CheckAvailability()
        {
            if (GameState.Instance.CurrentContext == EncounterContext 
                && PlanningCondition.IsConditionValid
                && (PlanningFormula.IsHereToday(GameState.Instance.CurrentDay, FirstEncounterDay)
                    ||FirstEncounterDay == 0))
            {
                if (FirstEncounterDay == 0)
                {
                    FirstEncounterDay = GameState.Instance.CurrentDay;
                }
                return true;
            }
            return false; 
        }
    }
}