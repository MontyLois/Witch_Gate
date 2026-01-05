using DG.Tweening;
using Helteix.Cards.UI.Physical;
using UnityEngine;
using UnityEngine.EventSystems;
using WitchGate.Controllers;
using WitchGate.Prototype;
using WitchGate.VisualNovel.Visual_Novel.Cards.UI;

namespace WitchGate.VisualNovel.Visual_Novel.Cards
{
    public class VNHandUI : PhysicalCardCollectionUI<VNCard>, IPhaseListener<TestimonyPhase>
    {
        
        private void OnEnable()
        {
            this.Register();
        }

        private void OnDisable()
        {
            this.Unregister();
        }
        
        
        public void OnPhaseBegins(TestimonyPhase phase)
        {
            Connect(phase.VnWitch.Hand);
        }

        public void OnPhaseEnds(TestimonyPhase phase)
        {
            Disconnect();
        }
        
        protected override void OnCardPointerEnter(CardHolderUI holder, PointerEventData eventData)
        {
            base.OnCardPointerEnter(holder, eventData);
            if (holder.CardUI is VNCardUI cardUI)
            {
                holder.transform.DOLocalMoveY( 3,0);
                holder.transform.localScale = Vector3.one * 1.2f;
            }
        }
        
        protected override void OnCardPointerExit(CardHolderUI holder, PointerEventData eventData)
        {
            base.OnCardPointerExit(holder, eventData);
            if (holder.CardUI is VNCardUI cardUI)
            {
                holder.transform.DOLocalMoveY(0,0);
                holder.transform.localScale = Vector3.one;
            }
        }
    }
}