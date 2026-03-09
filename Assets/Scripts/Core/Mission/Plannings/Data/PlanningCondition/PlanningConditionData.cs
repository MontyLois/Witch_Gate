using UnityEngine;
using WitchGate.Mission.Plannings.PlanningsCondition;

namespace WitchGate.Mission.Plannings.Data
{
    public abstract class PlanningConditionData : ScriptableObject
    {
        protected bool isConditionValid;
        public bool IsConditionValid => isConditionValid;

        public abstract PlanningCondition InitCondition();
    }
}