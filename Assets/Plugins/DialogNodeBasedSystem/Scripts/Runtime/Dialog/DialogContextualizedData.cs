using System.Collections.Generic;
using cherrydev;
using UnityEngine;
using WitchGate.Mission;
using WitchGate.Mission.Data;

namespace WitchGate.Dialog
{
    [CreateAssetMenu(fileName = "DialogContextualized", menuName = "WitchGate/Mission/DialogContextualized", order = 0)]
    public class DialogContextualizedData : ScriptableObject
    {
        [field: SerializeField] public CharacterData CharacterData { get; private set; }
        [field: SerializeField] public EncounterContext EncounterContext { get; private set; }
        [field: SerializeField] public int InvestigationStage { get; private set; }
        [field: SerializeField] public List<DialogNodeGraph> DialogBehaviours { get; private set; }

        private int currentDialogIndex;

        public DialogNodeGraph GetCurrentDialog()
        {
            if(DialogBehaviours.Count > 0)
                return DialogBehaviours[currentDialogIndex];

            return null;
        }

        public void NextDialog()
        {
            currentDialogIndex++;
        }
    }
}