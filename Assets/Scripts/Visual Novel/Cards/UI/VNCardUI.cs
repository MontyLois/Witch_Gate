using Helteix.Cards.UI.Physical;
using Helteix.Cards.UI.Physical.Components;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WitchGate.Cards.Collections;
using WitchGate.Gameplay.Cards.UI;

namespace WitchGate.VisualNovel.Visual_Novel.Cards.UI
{
    public class VNCardUI : CardUI<VNCard>, IDescription, ICardPointerHoverHandler
    {
        [field : SerializeField] private Image cardIllustration;
        [field: SerializeField] private TMP_Text CardName;
        [field: SerializeField] public Image CardBackground;
        [field: SerializeField] public Image CardLogo;

        ICardUI ICardUIComponent.CardUI { get; set; }
        

        protected override void ConnectWithCurrent()
        {
            cardIllustration.sprite = Current.Data.Icon;
            CardName.text = Current.Data.Name;
            CardBackground.sprite = Current.Data.BG;
            CardLogo.sprite = Current.Data.Type_Sprite;
        }
        
        protected override void DisconnectWithCurrent()
        {
            cardIllustration.sprite = null;
            CardName.text = "";
        }

        string IDescription.GetDescription()
        {
            string description = "";
            switch (Current.Data.CardType)
            {
                case CardType.Defensive :
                    description = "Plongez dans sa mémoire mémoire";
                    break;
                case CardType.Offensive : description = "Révélez les mensonges";
                    break;
                case CardType.Special : description = "Dévoilez le destin";
                    break;
                default: description = "???";
                    break;
            }
            return description;
        }

        string IDescription.GetTitle()
        {
            return Current.Data.Name;
        }

        void ICardPointerHoverHandler.OnPointerEnter(PointerEventData eventData)
        {
            UIManager.TriggerOnCardHovered(this);
        }

        void ICardPointerHoverHandler.OnPointerExit(PointerEventData eventData)
        {
            UIManager.TriggerOnCardUnhovered();
        }

        void ICardPointerHoverHandler.OnPointerMove(PointerEventData eventData)
        {
            
        }
    }
}