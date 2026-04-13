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
        }

        public override CardProfile GetCard()
        {
            Debug.Log(SelectedWitch);
            if(SelectedWitch == Witch.None)
                return playerProfile.GetRandomCardProfile(playerProfile.WitchProfiles.ElementAt(UnityEngine.Random.Range(0,
                    playerProfile.WitchProfiles.Count)).Key);
            return playerProfile.GetRandomCardProfile(SelectedWitch);
        }

        public override void OnSelect()
        {
            playerProfile.RemoveCard(card,card.witch);
        }
    }
}