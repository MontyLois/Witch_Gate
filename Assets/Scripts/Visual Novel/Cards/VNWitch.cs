using Helteix.Cards;
using Helteix.Cards.Collections;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Players;

namespace WitchGate.VisualNovel.Visual_Novel.Cards
{
    public class VNWitch
    {
        public Witch WitchName { get; private set; }
        public Hand<VNCard> Hand { get; private set; }
        public Deck<VNCard> Deck { get; private set; }
        public Deck<VNCard> Discard { get; private set; }

        public VNWitch(WitchProfile witchProfile)
        {
            Hand = new Hand<VNCard>(GameController.Metrics.MaxBattleHandSize);
            Deck = new Deck<VNCard>();
            Discard = new Deck<VNCard>();
            WitchName = witchProfile.Witch;
            
            //remplissage du deck
            foreach (var cardProfile in witchProfile.Deck)
            {
                var data = cardProfile.CardData;
                VNCard gameCard = new VNCard(data, cardProfile.Level);
                Deck.TryAddCard(gameCard);
            }
            Deck.Shuffle();
        }
        
        public void DrawCard()
        {
            if(!Deck.TryGet(out VNCard card))
            {
                while (Discard.TryGet(out var discardCard))
                    Deck.TryAddCard(discardCard);
                Deck.Shuffle();

                if (!Deck.TryGet(out card))
                {
                    Debug.LogError("??");
                    return;
                }
            }
            Hand.TryAddCard(card);
        }
        
        public void DrawMissingCards()
        {
            int missing = Hand.MaxSize - Hand.CurrentSize;
            for (int i = 0; i < missing; i++)
            {
                DrawCard();
            }
        }
        
    }
}