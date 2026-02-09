using System.Linq;
using UnityEngine;
using WitchGate.Cards.UI;
using WitchGate.Controllers;
using WitchGate.Players;

namespace WitchGate.Cards
{
    public class RemoveCardUpgrade : MonoBehaviour, IDeckImprovement<CardProfile>
    {
        [field: SerializeField]
        public CardUI CardUI { get; set; }
        public CardProfile card { get; set; }

        private PlayerProfile playerProfile;
        
        public Witch selectedWitch  { get; set; } = Witch.None;

        private void OnEnable()
        {
            playerProfile = GameController.GameDatabase.PlayerProfile;
            card = getCard();
            Connect(card);
        }
        
        public void Connect(CardProfile card)
        {
            CardUI.ConnectCard(card);
        }

        public CardProfile getCard()
        {
            if(selectedWitch == Witch.None)
                return playerProfile.GetRandomCardProfile(playerProfile.WitchProfiles.ElementAt(UnityEngine.Random.Range(0,
                    playerProfile.WitchProfiles.Count)).Key);
            return playerProfile.GetRandomCardProfile(selectedWitch);
        }

        public void SelectWitch(Witch witch)
        {
            selectedWitch = witch;
            card = playerProfile.GetRandomCardProfile(selectedWitch);
            Connect(card);
        }

        public void OnSelect()
        {
            playerProfile.RemoveCard(card,card.CardData.WitchDeck);
        }
    }
}