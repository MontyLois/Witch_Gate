using UnityEngine;

namespace WitchGate.Mission.Plannings.Data
{
    public abstract class PlanningFormula : ScriptableObject
    {
        public abstract bool IsHereToday(int currentDay, int firstEncounterDay);
    }
}