using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Controllers;

namespace WitchGate.Gameplay.Cards.DeckImprovement
{
    public class NewCardUpgrade : DeckImprovement
    {
        
        [field: SerializeField]
        public List<WitchCardDatas> WitchCardDatas { get; private set; }
        public Dictionary<Witch, CardData[]> WitchNewCards { get; private set; }
        
        protected override void Start()
        {
            InitCards();
            base.Start();
        }

        private void InitCards()
        {
            WitchNewCards =  new Dictionary<Witch, CardData[]>();
            foreach (WitchCardDatas cardData in WitchCardDatas)
            {
                WitchNewCards[cardData.WitchName] = cardData.CardDatas;
            }
        }

        public override CardProfile GetCard()
        {
            CardProfile card;
            if (SelectedWitch == Witch.None)
            {
                int index = UnityEngine.Random.Range(0, WitchNewCards.Count);
                var pair = WitchNewCards.ElementAt(index); // KeyValuePair<Witch, CardData[]>

                SelectedWitch = pair.Key;
                var cards = pair.Value;
                card = new CardProfile(cards[UnityEngine.Random.Range(0, cards.Length)],
                    SelectedWitch,0);
                return card;
            }
            card =
                new CardProfile(
                    WitchNewCards[SelectedWitch][UnityEngine.Random.Range(0, WitchNewCards[SelectedWitch].Length)],
                    SelectedWitch,0);
            return card;
        }

        public override void OnSelect()
        {
            GameController.GameDatabase.PlayerProfile.AddCard(card,SelectedWitch);
        }
    }
}