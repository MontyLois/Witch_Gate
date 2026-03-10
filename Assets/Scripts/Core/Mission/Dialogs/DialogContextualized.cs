using cherrydev;
using UnityEngine;
using WitchGate.Controllers;

namespace WitchGate.Mission.Dialogs
{
    public class DialogContextualized
    {
        private DialogContextualizedData dialogContextualizedData;
        private int currentDialogIndex;

        public DialogContextualized(DialogContextualizedData dialogContextualizedData)
        {
            this.dialogContextualizedData = dialogContextualizedData;
            currentDialogIndex = 0;
        }

        public DialogNodeGraph getNextDialog()
        {
            DialogNodeGraph dialogNodeGraph = null;
            if (dialogContextualizedData.DialogBehaviours.Count > 0 
                && dialogContextualizedData.DialogBehaviours.Count > currentDialogIndex)
            {
                dialogNodeGraph = dialogContextualizedData.DialogBehaviours[currentDialogIndex];
                currentDialogIndex++;
            }
            return dialogNodeGraph;
        }

        public bool CheckContext(CharacterData characterData, EncounterContext encounterContext, int investigationStage)
        {
            if (characterData == dialogContextualizedData.CharacterData 
                && encounterContext == dialogContextualizedData.EncounterContext
                && investigationStage == dialogContextualizedData.InvestigationStage)
                return true;
            return false;
        }

        /**
         * Check context base on current Game State, the character being optional
         */
        public bool CheckContext()
        {
            if (GameController.CurrentContext == dialogContextualizedData.EncounterContext
                && GameController.Investigation.CurrentStage == dialogContextualizedData.InvestigationStage)
                return true;
            return false;
        }

        public bool CheckContext(CharacterData characterData)
        {
            if (characterData == dialogContextualizedData.CharacterData
                && CheckContext())
            {
                return true;
            }
            return false;
        }
    }
}