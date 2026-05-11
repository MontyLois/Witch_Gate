using Helteix.Cards.UI.Physical;
using Helteix.Cards.UI.Physical.Components;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WitchGate.Cards.UI;
using WitchGate.Utilities;

namespace WitchGate.Gameplay.Cards.UI
{
    public class WitchGameCardUI : CardUI<IGameCard>, ICardAnimator, ICardPointerHoverHandler
    {

        [field : SerializeField] private Image cardIllustration;
        [field: SerializeField] private TMP_Text CardName;
        [field: SerializeField] private Image cardBackground;
        [field: SerializeField] public Image CardLogo;
        [field: SerializeField] private Animator cardAnimator;
        
        public ICardUI CardUI { get; set; }

        protected override void ConnectWithCurrent()
        {
            cardIllustration.sprite = Current.CardData.Icon;
            CardName.text = Current.CardData.Name;
            cardBackground.sprite = Current.CardData.BG;
            CardLogo.sprite = Current.CardData.Type_Sprite;
            Current.CardAnimator = this;
        }
        
        protected override void DisconnectWithCurrent()
        {
            cardIllustration.sprite = null;
            CardName.text = "";
            Current.CardAnimator = null;
        }

        public void OnSelected()
        {
            cardAnimator.SetTrigger("PutDownCard");
        }

        public async Awaitable OnAttack()
        {
            cardAnimator.Play("Card_Attack");
            await cardAnimator.WaitForAnimation("Card_Attack");
        }
       
        public void OnPointerEnter(PointerEventData eventData)
        {
            UIManager.TriggerOnCardHovered(Current);
            Current.TriggerOnPointerEnter(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            UIManager.TriggerOnCardUnhovered();
            Current.TriggerOnPointerExit(eventData);
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            
        }
    }
}
