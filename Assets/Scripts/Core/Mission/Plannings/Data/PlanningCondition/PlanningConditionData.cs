using UnityEngine;

namespace WitchGate.Mission.Plannings.Data
{
    public abstract class PlanningConditionData : ScriptableObject
    {
        protected bool isConditionValid;
        public bool IsConditionValid => isConditionValid;
    }
}