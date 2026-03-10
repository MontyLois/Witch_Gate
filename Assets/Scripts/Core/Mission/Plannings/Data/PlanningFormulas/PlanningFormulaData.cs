using System;
using UnityEngine;

namespace WitchGate.Mission.Plannings.Data
{
    public abstract class PlanningFormulaData : ScriptableObject
    {
        public abstract bool IsHereToday(int currentDay, int firstEncounterDay);
    }
}