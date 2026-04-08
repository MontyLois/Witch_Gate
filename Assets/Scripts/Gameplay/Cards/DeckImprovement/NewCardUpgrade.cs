
using System;
using System.Collections.Generic;
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
    public class NewCardUpgrade : DeckImprovement
    {
        
        [field: SerializeField]
        public List<WitchCardDatas> WitchCardDatas { get; private set; }
        public Dictionary<Witch, CardData[]> WitchNewCards { get; private set; }
        
        protected override void Start()
        {
            base.Start();
            InitCards();
            card = GetCard();
            Connect(card);
        }

        private void InitCards()
        {
            WitchNewCards =  new Dictionary<Witch, CardData[]>();
            foreach (WitchCardDatas cardData in WitchCardDatas)
            {
                WitchNewCards[cardData.WitchName] = cardData.CardDatas;
            }
        }

        public void Connect(CardData card)
        {
            WitchCardUI.ConnectCard(card);
        }

        public override CardProfile GetCard()
        {
            CardProfile card;
            if (selectedWitch == Witch.None)
            {
                int index = UnityEngine.Random.Range(0, WitchNewCards.Count);
                var pair = WitchNewCards.ElementAt(index); // KeyValuePair<Witch, CardData[]>

                selectedWitch = pair.Key;
                var cards = pair.Value;
                card = new CardProfile(cards[UnityEngine.Random.Range(0, cards.Length)],
                    selectedWitch,0);
                return card;
            }

            card =
                new CardProfile(
                    WitchNewCards[selectedWitch][UnityEngine.Random.Range(0, WitchNewCards[selectedWitch].Length)],
                    selectedWitch,0);
            return card;
        }

        public override void OnSelect()
        {
            base.OnSelect();
            Debug.Log(selectedWitch);
            GameController.GameDatabase.PlayerProfile.AddCard(card,selectedWitch);
        }
    }
}