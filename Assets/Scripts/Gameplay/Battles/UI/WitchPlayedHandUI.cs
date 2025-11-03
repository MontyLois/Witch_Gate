using Helteix.Cards;
using Helteix.Cards.Collections;
using Helteix.Cards.UI.Physical;
using Helteix.Cards.UI.Physical.Drag;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Gameplay.Cards;

namespace WitchGate.Gameplay.Battles.UI
{
    public class WitchPlayedHandUI : PhysicalCardCollectionUI<GameCard>, 
        IPhaseListener<BattlePhase>,
        ICardDropTarget<GameCard>
    {
        [SerializeField] private Witch witch;
        private int priority;

        private Hand<GameCard> hand;
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
            hand = witch switch
            {
                Witch.Elaris => phase.PlayedElarisHand,
                Witch.Velmora => phase.PlayedVelmoraHand,
                _ => null,
            };
            
            Connect(hand);
        }

        public void OnPhaseCompletes(BattlePhase phase)
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

        bool ICardDropTarget<GameCard>.Accepts(GameCard card) => (card.Data.WitchDeck & witch) != 0;

        void ICardDropTarget<GameCard>.OnCardEnter(GameCard cardUI)
        {
        }

        void ICardDropTarget<GameCard>.OnCardExit(GameCard cardUI)
        {
        }

        void ICardDropTarget<GameCard>.OnCardDrop(GameCard card)
        {
            hand.TryAddCard(card);
        }

        void ICardDropTarget<GameCard>.OnCardHover(GameCard cardUICurrent)
        {
        }
    }
}