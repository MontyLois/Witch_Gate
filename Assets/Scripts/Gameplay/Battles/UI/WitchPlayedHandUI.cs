using Helteix.Cards;
using Helteix.Cards.Collections;
using Helteix.Cards.UI.Physical;
using Helteix.Cards.UI.Physical.Drag;
using UnityEngine;
using UnityEngine.EventSystems;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.TurnPhases;
using WitchGate.Gameplay.Cards;

namespace WitchGate.Gameplay.Battles.UI
{
    public class WitchPlayedHandUI : PhysicalCardCollectionUI<GameCard>, 
        IPhaseListener<BattlePhase>,
        ICardDropTarget<GameCard>
    {
        [SerializeField] private Witch witch;
        
        [field : SerializeField] public int PlayedHandIndex { get; private set; }
        
        private int priority;

        private Hand<GameCard> hand;
        private BattlePhase battlePhase;
        private void OnEnable()
        {
            this.Register();
        }

        private void OnDisable()
        {
            this.Unregister();
        }

        public void OnPhaseBegins(BattlePhase phase)
        {
            battlePhase = phase;
            hand = phase.PlayedHands[PlayedHandIndex];
            /*
            hand = PlayedHandIndex switch
            {
                0 => phase.Elaris.PlayedHand,
                1 => phase.Velmora.PlayedHand,
                _ => null,
            };*/
            
            Connect(hand);
        }

        public void OnPhaseEnds(BattlePhase phase)
        {
            Disconnect();
        }

        public void OnPhaseCanceled(BattlePhase phase)
        {
            Disconnect();
        }

        protected override void DisconnectWithCurrent()
        {
            base.DisconnectWithCurrent();
            hand = null;
        }

        int ICardDropTarget<GameCard>.Priority => priority;

        bool ICardDropTarget<GameCard>.Accepts(GameCard card)
        {
            var accepts = (card.Data.WitchDeck & witch)!= 0 && (hand.CurrentSize==0) ;
            return accepts;
        }

        void ICardDropTarget<GameCard>.OnCardEnter(GameCard cardUI)
        {
            transform.localScale = Vector3.one * 1.2f;
        }

        void ICardDropTarget<GameCard>.OnCardExit(GameCard cardUI)
        {
            
            transform.localScale = Vector3.one ;
        }

        void ICardDropTarget<GameCard>.OnCardDrop(GameCard card)
        {
            hand.TryAddCard(card);
            transform.localScale = Vector3.one;
        }

        void ICardDropTarget<GameCard>.OnCardHover(GameCard cardUICurrent)
        {
        }
        
        protected override bool CanCardBeClicked(ICard card)
        {
            return true;
        }

        protected override void OnCardPointerDown(CardHolderUI holder, PointerEventData eventData)
        {
            base.OnCardPointerDown(holder, eventData);
            if (holder.CardUI is WitchGameCardUI cardUI)
            {
                var targetHand = cardUI.Current.Data.WitchDeck switch
                {
                    Witch.Elaris => battlePhase.Elaris.Hand,
                    Witch.Velmora => battlePhase.Velmora.Hand,
                    _ => null,
                };
                targetHand?.TryAddCard(cardUI.Current);
            }
        }
    }
}