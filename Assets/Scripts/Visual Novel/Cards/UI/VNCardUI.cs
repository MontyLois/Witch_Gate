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
        
        public ICardUI CardUI { get; set; }
        

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

        public string GetDescription()
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

        public string GetTitle()
        {
            return Current.Data.Name;
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            UIManager.OnCardHovered?.Invoke(this);
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