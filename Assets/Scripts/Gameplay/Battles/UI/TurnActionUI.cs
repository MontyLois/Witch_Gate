using Helteix.Tools.UI;
using TMPro;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.TurnPhases;

namespace WitchGate.Gameplay.Battles.UI
{
    public class TurnActionUI : UIItem<ITurnAction>
    {
        [SerializeField] 
        private TMP_Text actionName;
        [SerializeField] 
        private CanvasGroup group;
        
        protected override void SyncUI(ITurnAction current)
        {
            actionName.text = current.Label;
            group.alpha = 1;
        }

        protected override void ClearUI()
        {
            
        }
    }
}