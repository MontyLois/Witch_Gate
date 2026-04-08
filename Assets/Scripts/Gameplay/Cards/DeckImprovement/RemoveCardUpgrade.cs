using System.Linq;
using Helteix.Cards.UI.Physical;
using Helteix.Cards.UI.Physical.Components;
using UnityEngine;
using UnityEngine.EventSystems;
using WitchGate.Cards.UI;
using WitchGate.Controllers;
using WitchGate.Players;

namespace WitchGate.Cards
{
    public class RemoveCardUpgrade : DeckImprovement
    {
        protected override void Start()
        {
            base.Start();
            card = GetCard();
            Connect(card);
        }

        public override CardProfile GetCard()
        {
            Debug.Log(selectedWitch);
            if(selectedWitch == Witch.None)
                return playerProfile.GetRandomCardProfile(playerProfile.WitchProfiles.ElementAt(UnityEngine.Random.Range(0,
                    playerProfile.WitchProfiles.Count)).Key);
            return playerProfile.GetRandomCardProfile(selectedWitch);
        }

        public override void OnSelect()
        {
            base.OnSelect();
            playerProfile.RemoveCard(card,card.Witch);
        }
    }
}