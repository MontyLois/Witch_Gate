
using System;
using UnityEngine;
using WitchGate.Cards.UI;
using WitchGate.Controllers;

namespace WitchGate.Cards
{
    public class NewCardUpgrade : MonoBehaviour, IDeckImprovement<CardData>
    {
        [field: SerializeField]
        public CardUI CardUI { get; set; }
        public CardData card { get; set; }

        [field: SerializeField]
        public CardData[] CardDatas { get; set; }

        private void OnEnable()
        {
            card = getCard();
            Connect(card);
        }

        public void Connect(CardData card)
        {
            CardUI.ConnectCard(card);
        }

        public CardData getCard()
        {
            return CardDatas[UnityEngine.Random.Range(0, CardDatas.Length)];
        }
        
        public void OnSelect()
        {
            GameController.GameDatabase.PlayerProfile.AddCard(card,card.WitchDeck);
        }
    }
}