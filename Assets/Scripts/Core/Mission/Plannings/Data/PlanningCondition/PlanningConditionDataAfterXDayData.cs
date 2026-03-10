using System;
using UnityEngine;
using WitchGate.Mission.Plannings.PlanningsCondition;

namespace WitchGate.Mission.Plannings.Data
{
    [CreateAssetMenu(fileName = "PC_AfterXDay_", menuName = "WitchGate/Planning/PlanningConditions/AfterXDay", order = 0)]
    public class PlanningConditionDataAfterXDayData : PlanningConditionData
    {
        [field: SerializeField]
        public int X { get; private set; }

        public override PlanningCondition InitCondition()
        {
            return new PlanningConditionAfterXDay(X);
        }
    }
}