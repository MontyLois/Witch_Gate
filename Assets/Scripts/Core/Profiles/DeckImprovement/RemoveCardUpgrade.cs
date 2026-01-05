using System.Linq;
using UnityEngine;
using WitchGate.Cards.UI;
using WitchGate.Controllers;
using WitchGate.Players;

namespace WitchGate.Cards
{
    public class RemoveCardUpgrade : MonoBehaviour, IDeckImprovement<CardProfile>
    {
        public CardUI CardUI { get; set; }
        public CardProfile card { get; set; }

        private PlayerProfile playerProfile;

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
            return playerProfile.WitchProfiles.ElementAt(UnityEngine.Random.Range(0,
                playerProfile.WitchProfiles.Count)).Value.GetRandomCardFromDeck();
        }
        
        public void OnSelect()
        {
            playerProfile.RemoveCard(card,card.CardData.WitchDeck);
        }
    }
}