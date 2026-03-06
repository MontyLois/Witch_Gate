using System;
using UnityEngine;

namespace WitchGate.Mission.Plannings.Data
{
    [CreateAssetMenu(fileName = "PC_AfterXDay_", menuName = "WitchGate/Planning/PlanningConditions/AfterXDay", order = 0)]
    public class PlanningConditionDataAfterXDayData : PlanningConditionData
    {
        [field: SerializeField]
        public int X { get; private set; }
    }
}