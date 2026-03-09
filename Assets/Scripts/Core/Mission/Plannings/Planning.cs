using cherrydev;
using WitchGate.Controllers;
using WitchGate.Mission.Data;
using WitchGate.Mission.Plannings.Data;
using WitchGate.Mission.Plannings.PlanningsCondition;

namespace WitchGate.Mission.Plannings
{
    public class Planning
    {
        public CharacterData CharacterData { get; private set; }
        
        private PlanningCondition PlanningCondition;
        private EncounterContext encounterContext;
        private PlanningFormulaData planningFormulaData;
        public int FirstEncounterDay { get; private set; }

        public Planning(PlanningData planningData)
        {
            CharacterData = planningData.CharacterData;
            PlanningCondition = planningData.PlanningConditionData.InitCondition();
            encounterContext = planningData.EncounterContext;
            planningFormulaData = planningData.PlanningFormulaData;
        }
        
        public bool CheckAvailability()
        {
            if (GameController.CurrentContext == encounterContext 
                && PlanningCondition.IsConditionValid
                && (planningFormulaData.IsHereToday(GameController.CurrentDay, FirstEncounterDay)
                    ||FirstEncounterDay == 0))
            {
                if (FirstEncounterDay == 0)
                {
                    FirstEncounterDay = GameController.CurrentDay;
                }
                return true;
            }
            return false; 
        }

        public void SetFirstEncounterDay(int firstEncounterDay) => FirstEncounterDay = firstEncounterDay;
    }
}