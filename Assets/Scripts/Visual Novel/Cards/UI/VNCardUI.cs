using Helteix.Cards.UI.Physical;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WitchGate.VisualNovel.Visual_Novel.Cards.UI
{
    public class VNCardUI : CardUI<VNCard>
    {
        [field : SerializeField] private Image cardIllustration;
        [field: SerializeField] private TMP_Text CardName;
        

        protected override void ConnectWithCurrent()
        {
            cardIllustration.sprite = Current.Data.Icon;
            CardName.text = Current.Data.Name;
        }
        
        protected override void DisconnectWithCurrent()
        {
            cardIllustration.sprite = null;
            CardName.text = "";
        }
    }
}