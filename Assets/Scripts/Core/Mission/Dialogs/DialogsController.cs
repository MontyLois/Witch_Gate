using System.Collections.Generic;
using cherrydev;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Mission.Plannings;

namespace WitchGate.Mission.Dialogs
{
    public static class DialogsController
    {
        private static List<DialogContextualized> dialogContextualizedList = new List<DialogContextualized>();
        
        public static void Load()
        {
            DialogContextualizedData[] dialogContextualizedDatas = GameController.GameDatabase.DialogContextualizedDatas;
            foreach (var dialogContextualizedData in dialogContextualizedDatas)
            {
                dialogContextualizedList.Add(new DialogContextualized(dialogContextualizedData));
            }
        }

        public static List<DialogNodeGraph> GetNextDialogsForAllCharacters()
        {
            List<DialogNodeGraph> dialogNodeGraphs = new List<DialogNodeGraph>();
            foreach (var dialog in dialogContextualizedList)
            {
                if (dialog.CheckContext())
                {
                    DialogNodeGraph dialogNodeGraph = dialog.getNextDialog();
                    if(dialogNodeGraph is not null)
                    {
                        dialogNodeGraphs.Add(dialogNodeGraph);
                    }
                }
                
            }
            return dialogNodeGraphs;
        }

        public static DialogNodeGraph GetNextDialogForSpecificEntity(CharacterData characterData)
        {
            foreach (var dialog in dialogContextualizedList)
            {
                if (dialog.CheckContext(characterData))
                {
                    DialogNodeGraph dialogNodeGraph = dialog.getNextDialog();
                    if(dialogNodeGraph is not null)
                    {
                        return dialogNodeGraph;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }
    }
}