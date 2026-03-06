using UnityEngine;
using WitchGate.Mission.Data;

namespace WitchGate.Mission.Plannings.Data
{
    public class PlanningData
    {
        [field: SerializeField]
        public CharacterData CharacterData { get; private set; }
        [field: SerializeField]
        public EncounterContext EncounterContext { get; private set; }
        [field: SerializeField]
        public PlanningCondition PlanningCondition { get; private set; }

        public bool CheckAvailability()
        {
            if (GameState.Instance.CurrentContext == EncounterContext && PlanningCondition.IsConditionValid)
            {
                return true;
            }
            return false; 
        }
    }
}