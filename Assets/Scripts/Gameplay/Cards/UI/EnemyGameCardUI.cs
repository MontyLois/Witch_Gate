using Helteix.Cards.UI.Physical;
using Helteix.Cards.UI.Physical.Components;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WitchGate.Cards;

namespace WitchGate.Gameplay.Cards.UI
{
    public class EnemyGameCardUI: CardUI<IGameCard>, ICardAnimator, ICardPointerHoverHandler
    {
        [field : SerializeField] private Image cardIllustration;
        public ICardUI CardUI { get; set; }
        
        protected override void ConnectWithCurrent()
        {
            cardIllustration.sprite = Current.CardData.Icon;
            Current.CardAnimator = this;
        }
        
        protected override void DisconnectWithCurrent()
        {
            cardIllustration.sprite = null;
            Current.CardAnimator = null;
        }

        public async Awaitable OnAttack()
        {
            
        }

        public void OnSelected()
        {
            
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