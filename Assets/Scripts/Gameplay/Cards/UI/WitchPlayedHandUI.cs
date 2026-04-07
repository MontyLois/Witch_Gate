using Helteix.Cards;
using Helteix.Cards.Collections;
using Helteix.Cards.UI.Physical;
using Helteix.Cards.UI.Physical.Drag;
using UnityEngine;
using UnityEngine.EventSystems;
using WitchGate.Cards;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.TurnPhases;
using WitchGate.Gameplay.Cards;

namespace WitchGate.Gameplay.Battles.UI
{
    public class WitchPlayedHandUI : PhysicalCardCollectionUI<IGameCard>, 
        IPhaseListener<BattlePhase>,
        ICardDropTarget<IGameCard>
    {
        [SerializeField] private Witch witch;
        
        [field : SerializeField] public int PlayedHandIndex { get; private set; }
        
        private int priority;

        private Hand<IGameCard> hand;
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

        int ICardDropTarget<IGameCard>.Priority => priority;

        bool ICardDropTarget<IGameCard>.Accepts(IGameCard card)
        {
            var accepts = (card.WitchDeck & witch)!= 0 && (hand.CurrentSize==0) ;
            return accepts;
        }

        void ICardDropTarget<IGameCard>.OnCardEnter(IGameCard cardUI)
        {
            //transform.localScale = Vector3.one * 1.2f;
        }

        void ICardDropTarget<IGameCard>.OnCardExit(IGameCard cardUI)
        {
            //transform.localScale = Vector3.one ;
        }

        void ICardDropTarget<IGameCard>.OnCardDrop(IGameCard card)
        {
            hand.TryAddCard(card);
            //transform.localScale = Vector3.one;
        }

        void ICardDropTarget<IGameCard>.OnCardHover(IGameCard cardUICurrent)
        {
        }


        protected override void OnCardAdded(IGameCard card)
        {
            base.OnCardAdded(card);
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
                var targetHand = battlePhase.GetBattleWich(cardUI.Current.WitchDeck).Hand;
                targetHand?.TryAddCard(cardUI.Current);
            }
        }
    }
}