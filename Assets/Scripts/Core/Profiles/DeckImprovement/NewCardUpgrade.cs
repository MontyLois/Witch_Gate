
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WitchGate.Cards.UI;
using WitchGate.Controllers;
using WitchGate.Players;

namespace WitchGate.Cards
{
    public class NewCardUpgrade : MonoBehaviour, IDeckImprovement<CardData>
    {
        [field: SerializeField]
        public CardUI CardUI { get; set; }
        public CardData card { get; set; }
        
        
        [field: SerializeField]
        public List<WitchCardDatas> WitchCardDatas { get; private set; }
        public Dictionary<Witch, CardData[]> WitchNewCards { get; private set; }

        public Witch selectedWitch  { get; set; } = Witch.None;

        private void Start()
        {
            WitchNewCards =  new Dictionary<Witch, CardData[]>();
            foreach (WitchCardDatas cardData in WitchCardDatas)
            {
                WitchNewCards[cardData.WitchName] = cardData.CardDatas;
            }
            
            card = getCard();
            Connect(card);
        }

        public void Connect(CardData card)
        {
            CardUI.ConnectCard(card);
        }

        public CardData getCard()
        {
            if (selectedWitch == Witch.None)
            {
                int index = UnityEngine.Random.Range(0, WitchNewCards.Count);
                var pair = WitchNewCards.ElementAt(index); // KeyValuePair<Witch, CardData[]>

                var cards = pair.Value;
                return cards[UnityEngine.Random.Range(0, cards.Length)];
            }
                
            return WitchNewCards[selectedWitch][UnityEngine.Random.Range(0, WitchNewCards[selectedWitch].Length)];
        }

        public void SelectWitch(Witch witch)
        {
            selectedWitch = witch;
            card = WitchNewCards[witch][UnityEngine.Random.Range(0, WitchNewCards[witch].Length)];
            Connect(card);
        }

        public void OnSelect()
        {
            GameController.GameDatabase.PlayerProfile.AddCard(card,card.WitchDeck);
        }
    }
}