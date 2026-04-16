using Helteix.Cards.UI.Physical;
using Helteix.Cards.UI.Physical.Components;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WitchGate.Controllers;
using WitchGate.Players;

namespace WitchGate.Cards.UI
{
    public class WitchCardUI : MonoBehaviour
    {
        [field: SerializeField] public Image CardIllustration;
        [field: SerializeField] public Image CardBackground;
        [field: SerializeField] public TMP_Text CardName;
        
        [field: SerializeField] public GameObject CardDescriptionGameObject { get; private set; }
        
        private CardData cardData;
        

        public void ConnectCard(CardData cardData)
        {
            this.cardData = cardData;
            this.CardIllustration.sprite = this.cardData.Icon;
            this.CardName.text = this.cardData.Name;
            this.CardBackground.sprite = this.cardData.BG;
        }
        
        public void ConnectCard(CardProfile cardProfile)
        {
            ConnectCard(cardProfile.CardData);
        }
    }
}