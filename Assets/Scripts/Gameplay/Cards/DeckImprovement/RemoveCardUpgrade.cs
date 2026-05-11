using System.Linq;
using UnityEngine;
using WitchGate.Cards;

namespace WitchGate.Gameplay.Cards.DeckImprovement
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