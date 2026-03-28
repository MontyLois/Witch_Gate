using System;
using System.Threading.Tasks;
using Helteix.Cards.UI.Physical;
using Helteix.Cards.UI.Physical.Components;
using UnityEngine;
using UnityEngine.UI;
using WitchGate.Gameplay.Cards;
using TMPro;
using UnityEngine.EventSystems;
using WitchGate.Gameplay.Cards.UI;
using WitchGate.Utilities;

namespace WitchGate.Gameplay
{
    public class WitchGameCardUI : CardUI<GameCard>, ICardAnimator, ICardPointerHoverHandler
    {

        [field : SerializeField] private Image cardIllustration;
        [field: SerializeField] private TMP_Text CardName;
        [field: SerializeField] private Image cardBackground;
        [field: SerializeField] private Animator cardAnimator;
        
        public ICardUI CardUI { get; set; }

        protected override void ConnectWithCurrent()
        {
            cardIllustration.sprite = Current.Data.Icon;
            CardName.text = Current.Data.Name;
            cardBackground.sprite = Current.Data.BG;
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
            UIManager.OnCardHovered?.Invoke(Current);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            UIManager.OnCardUnhovered?.Invoke();
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            
        }
    }
}
