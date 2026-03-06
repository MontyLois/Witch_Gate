using UnityEngine;

namespace WitchGate.Mission.Plannings.Data
{
    public abstract class PlanningCondition : ScriptableObject
    {
        private bool isConditionValid;
        public bool IsConditionValid => isConditionValid;
    }
}