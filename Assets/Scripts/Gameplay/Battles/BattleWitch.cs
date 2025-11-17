using Helteix.Cards;
using Helteix.Cards.Collections;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Gameplay.Cards;
using WitchGate.Players;

namespace WitchGate.Gameplay.Battles
{
    public class BattleWitch
    {
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; private set; }
        public Hand<GameCard> Hand { get; private set; }
        public Deck<GameCard> Deck { get; private set; }
        public Hand<GameCard> PlayedHand { get; private set; }
        
        public Deck<GameCard> Discard { get; private set; }
        public BattleWitch(WitchProfile profile)
        {
            Hand = new Hand<GameCard>(GameController.Metrics.MaxBattleHandSize);
            
            Deck = new Deck<GameCard>();
            Discard = new Deck<GameCard>();
            
            PlayedHand = new Hand<GameCard>();
            foreach (var cardProfile in profile.Deck)
            {
                GameCard gameCard = new GameCard(cardProfile.CardData);
                Deck.TryAddCard(gameCard);
            }
            
            Deck.Shuffle();

            CurrentHealth = profile.Health;
            MaxHealth = profile.MaxHealth;
        }

        public void DrawMissingCards()
        {
            int missing = Hand.MaxSize - Hand.CurrentSize;
            for (int i = 0; i < missing; i++)
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
}