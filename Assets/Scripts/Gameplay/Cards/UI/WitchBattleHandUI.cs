using DG.Tweening;
using Helteix.Cards;
using Helteix.Cards.UI.Physical;
using UnityEngine;
using UnityEngine.EventSystems;
using WitchGate.Controllers;
using WitchGate.Gameplay.Cards;

namespace WitchGate.Gameplay.Battles.UI
{
    public class WitchBattleHandUI : PhysicalCardCollectionUI<GameCard>, IPhaseListener<BattlePhase>
    {
        [SerializeField] private Witch witch;

        private BattleWitch battleWitch;
        
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
            battleWitch = phase.GetBattleWich(witch);
            Connect(battleWitch.Hand);
            battleWitch.OnDeath += OnBattleWitchDeath;
        }

        public void OnPhaseEnds(BattlePhase phase)
        {
            Disconnect();
            battleWitch.OnDeath -= OnBattleWitchDeath;
        }

        protected override void OnCardPointerEnter(CardHolderUI holder, PointerEventData eventData)
        {
            base.OnCardPointerEnter(holder, eventData);
            if (holder.CardUI is WitchGameCardUI cardUI)
            {
                holder.transform.DOLocalMoveY( 3,0);
                holder.transform.localScale = Vector3.one * 1.2f;
            }
        }
        
        protected override void OnCardPointerExit(CardHolderUI holder, PointerEventData eventData)
        {
            base.OnCardPointerExit(holder, eventData);
            if (holder.CardUI is WitchGameCardUI cardUI)
            {
                holder.transform.DOLocalMoveY(0,0);
                holder.transform.localScale = Vector3.one;
            }
        }

        private void OnBattleWitchDeath()
        {
            //this.gameObject.SetActive(false);
        }

    }
}