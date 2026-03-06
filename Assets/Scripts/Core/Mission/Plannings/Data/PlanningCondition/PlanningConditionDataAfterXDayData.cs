using System;
using UnityEngine;

namespace WitchGate.Mission.Plannings.Data
{
    [CreateAssetMenu(fileName = "PC_AfterXDay_", menuName = "WitchGate/Planning/PlanningConditions/AfterXDay", order = 0)]
    public class PlanningConditionAfterXDayData : PlanningCondition
    {
        [field: SerializeField]
        public int X { get; private set; }
        private void OnEnable()
        {
            GameState.Instance.DayChanged += CheckDay;
        }

        private void OnDisable()
        {
            GameState.Instance.DayChanged -= CheckDay;
        }

        private void CheckDay(int currentDay)
        {
            if(X<currentDay)
                return;
            isConditionValid = true;
            GameState.Instance.DayChanged -= CheckDay;
        }
    }
}