using UnityEngine;

namespace WitchGate.Mission.Plannings.Data
{
    [CreateAssetMenu(fileName = "PF_FirstXDaysOfYDays_", menuName = "WitchGate/Planning/PlanningFormula/FirstXDaysOfYDays", order = 0)]
    public class PlanningFormulaDataFirstXDaysOfYDays : PlanningFormulaData
    {
        [field: SerializeField]
        public int X { get; private set; }
        [field: SerializeField]
        public int Y { get; private set; }
        
        public override bool IsHereToday(int currentDay, int firstEncounterDay)
        {
            if ((currentDay - firstEncounterDay) % Y < X)
                return true;
            return false;
        }
    }
}