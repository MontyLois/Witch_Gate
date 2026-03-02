using System;
using Helteix.Cards.UI.Physical;
using UnityEngine;
using UnityEngine.UI;
using WitchGate.Gameplay.Cards;
using TMPro;

namespace WitchGate.Gameplay
{
    public class WitchGameCardUI : CardUI<GameCard>, ICardAnimator
    {

        [field : SerializeField] private Image cardIllustration;
        [field: SerializeField] private TMP_Text CardName;
        [field: SerializeField] private Image cardBackground;
        [field: SerializeField] private Animator cardAnimator;
        

        protected override void ConnectWithCurrent()
        {
            cardIllustration.sprite = Current.Data.Icon;
            CardName.text = Current.Data.Name;
            cardBackground.sprite = Current.Data.BG;
            Current.CardAnimator = this;
            
            //Current.GetAttackAwaitable = OnAttack;
            
            Current.CardPutDown += OnSelected;
        }
        
        protected override void DisconnectWithCurrent()
        {
            cardIllustration.sprite = null;
            CardName.text = "";
            Current.CardAnimator = null;
            Current.CardPutDown -= OnSelected;
        }

        public void OnSelected()
        {
            cardAnimator.SetTrigger("PutDownCard");
        }

        public async Awaitable OnAttack()
        {
            
        }
    }
}
