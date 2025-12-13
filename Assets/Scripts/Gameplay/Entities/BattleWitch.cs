using Helteix.Cards;
using Helteix.Cards.Collections;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Gameplay.Cards;
using WitchGate.Players;

namespace WitchGate.Gameplay.Battles
{
    public class BattleWitch : BattleEntity
    {
        public Witch WitchName { get; private set; }
        public override Faction Faction { get; } = Faction.Witch;
        public Hand<GameCard> Hand { get; private set; }
        public Deck<GameCard> Deck { get; private set; }
        public Deck<GameCard> Discard { get; private set; }
        
        public BattleWitch(WitchProfile profile) : base(profile.MaxHealth, profile.Health)
        {
            Hand = new Hand<GameCard>(GameController.Metrics.MaxBattleHandSize);
            Deck = new Deck<GameCard>();
            Discard = new Deck<GameCard>();
            WitchName = profile.Witch;
            
            //remplissage du deck
            foreach (var cardProfile in profile.Deck)
            {
                var data = cardProfile.CardData;
                GameCard gameCard = new GameCard(data);
                Deck.TryAddCard(gameCard);
            }
            Deck.Shuffle();
        }

        public void DrawMissingCards()
        {
            int missing = Hand.MaxSize - Hand.CurrentSize;
            for (int i = 0; i < missing; i++)
            {
                DrawCard();
            }
        }

        public void DrawCard()
        {
            if(!Deck.TryGet(out GameCard card))
            {
                Debug.Log("Rebuilding deck from discard...");
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
    }
}