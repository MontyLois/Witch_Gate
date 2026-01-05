using Helteix.Cards.UI.Physical;
using Helteix.Cards.UI.Physical.Drag;
using TMPro;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Prototype;

namespace WitchGate.VisualNovel.Visual_Novel.Cards.UI
{
    public class VNPlayedHandUI : PhysicalCardCollectionUI<VNCard>, ICardDropTarget<VNCard>, IPhaseListener<TestimonyPhase>
    {

        [field: SerializeField] public GameObject VisionUI { get; private set;}
        [field: SerializeField] public TMP_Text VisionText { get; private set;}

        private VNWitch vnWitch;
        private int priority;
        
        private void OnEnable()
        {
            this.Register();
        }

        private void OnDisable()
        {
            this.Unregister();
        }
        
        
        int ICardDropTarget<VNCard>.Priority => priority;

        bool ICardDropTarget<VNCard>.Accepts(VNCard card)
        {
            return true;
        }

        void ICardDropTarget<VNCard>.OnCardEnter(VNCard cardUI)
        {
            
        }

        void ICardDropTarget<VNCard>.OnCardExit(VNCard cardUI)
        {
            
           
        }

        void ICardDropTarget<VNCard>.OnCardDrop(VNCard card)
        {
            card.Use(VisionText);
            vnWitch.Discard.TryAddCard(card);
            VisionUI.SetActive(true);
        }

        void ICardDropTarget<VNCard>.OnCardHover(VNCard cardUICurrent)
        {
        }
        

        public void OnPhaseBegins(TestimonyPhase phase)
        {
            vnWitch = phase.VnWitch;
        }

        public void OnPhaseEnds(TestimonyPhase phase)
        {
           
        }
    }
}