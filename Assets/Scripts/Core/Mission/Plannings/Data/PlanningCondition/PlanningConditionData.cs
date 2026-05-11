using UnityEngine;

namespace WitchGate.Mission.Plannings.Data.PlanningCondition
{
    public abstract class PlanningConditionData : ScriptableObject
    {
        protected bool isConditionValid;
        public bool IsConditionValid => isConditionValid;

        public abstract PlanningsCondition.PlanningCondition InitCondition();
    }
}