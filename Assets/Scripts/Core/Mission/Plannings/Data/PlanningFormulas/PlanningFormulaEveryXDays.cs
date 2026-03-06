using UnityEngine;

namespace WitchGate.Mission.Plannings.Data
{
    [CreateAssetMenu(fileName = "PF_EveryXDays_", menuName = "WitchGate/Planning/PlanningFormula/EveryXDays", order = 0)]
    public class PlanningFormulaEveryXDays : PlanningFormula
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