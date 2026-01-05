using Helteix.Cards.UI.Physical;
using UnityEngine;
using UnityEngine.UI;

namespace WitchGate.Gameplay.Cards.UI
{
    public class EnemyGameCArdUI: CardUI<GameCard>
    {
        [field : SerializeField] private Image cardIllustration;
        
        protected override void ConnectWithCurrent()
        {
            cardIllustration.sprite = Current.Data.Icon;
        }
        
        protected override void DisconnectWithCurrent()
        {
            cardIllustration.sprite = null;
        }
    }
}