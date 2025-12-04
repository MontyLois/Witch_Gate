using System;
using Helteix.Cards.UI.Physical;
using UnityEngine;
using UnityEngine.UI;
using WitchGate.Gameplay.Cards;
using TMPro;

namespace WitchGate.Gameplay
{
    public class WitchGameCardUI : CardUI<GameCard>
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
