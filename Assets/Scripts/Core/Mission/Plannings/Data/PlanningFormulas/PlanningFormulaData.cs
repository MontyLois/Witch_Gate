using UnityEngine;

namespace WitchGate.Mission.Plannings.Data.PlanningFormulas
{
    public abstract class PlanningFormulaData : ScriptableObject
    {
        public abstract bool IsHereToday(int currentDay, int firstEncounterDay);
    }
}