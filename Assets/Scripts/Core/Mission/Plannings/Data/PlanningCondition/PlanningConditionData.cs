using UnityEngine;

namespace WitchGate.Mission.Plannings.Data
{
    public abstract class PlanningCondition : ScriptableObject
    {
        protected bool isConditionValid;
        public bool IsConditionValid => isConditionValid;
    }
}