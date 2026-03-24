using Helteix.Tools.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using WitchGate.Gameplay.Battles.TurnPhases;
using WitchGate.Gameplay.Cards.UI;

namespace WitchGate.Gameplay.Battles.UI
{
    public class TurnActionUI : UIItem<ITurnAction>, IPointerEnterHandler, IPointerExitHandler
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

        public void OnPointerEnter(PointerEventData eventData)
        {
            UIManager.OnCardHovered?.Invoke(Current.GameCard);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            UIManager.OnCardUnhovered?.Invoke();
        }
    }
}