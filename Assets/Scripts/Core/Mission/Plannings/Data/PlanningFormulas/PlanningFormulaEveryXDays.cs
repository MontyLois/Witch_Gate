using UnityEngine;

namespace WitchGate.Mission.Plannings.Data
{
    [CreateAssetMenu(fileName = "PlanningFormulaEveryXDays", menuName = "WitchGate/Mission/Planning", order = 0)]
    public class PlanningFormulaEveryXDay : PlanningFormula
    {
        [field: SerializeField]
        public int X { get; private set; }
        
        public override bool IsHereToday(int currentDay, int firstEncounterDay)
        {
            if ((currentDay - firstEncounterDay) % X == 0)
                return true;
            return false;
        }
    }
}