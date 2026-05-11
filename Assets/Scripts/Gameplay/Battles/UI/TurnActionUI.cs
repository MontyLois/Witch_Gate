using System;
using DG.Tweening;
using Helteix.Tools.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using WitchGate.Cards.Collections;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.Actions;
using WitchGate.Gameplay.Battles.Actions.Interface;
using WitchGate.Gameplay.Battles.TurnPhases;
using WitchGate.Gameplay.Cards.UI;

namespace WitchGate.Gameplay.Battles.UI
{
    public class TurnActionUI : UIItem<ITurnAction>, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] 
        private TMP_Text actionName;
        [SerializeField] 
        private CanvasGroup group;

        [SerializeField] 
        private GameObject maybe;

        [SerializeField] 
        private GameObject outline;
        
        private ITurnAction currentAction;

        protected override void SyncUI(ITurnAction current)
        {
            currentAction = current;
            actionName.text = current.Label;
            group.alpha = 1;
            maybe.SetActive(false);

            current.GameCard.OnPointerEnter += ShowOutline;
            current.GameCard.OnPointerExit += HideOutline;
            
            if (current is EnemyAction enemyAction)
            {
                enemyAction.OnConfirmationChanged += OnConfirmationChanged;
                OnConfirmationChanged();
            }
        }
        

        protected override void ClearUI()
        {
            if(currentAction == null)
                return;
            
            currentAction.GameCard.OnPointerEnter -= ShowOutline;
            currentAction.GameCard.OnPointerExit -= HideOutline;

            if (currentAction is EnemyAction enemyAction)
            {
                enemyAction.OnConfirmationChanged -= OnConfirmationChanged;
                group.alpha = 1;
                maybe.SetActive(false);
            }
        }

        private void ShowOutline()
        {
            outline.SetActive(true);
            transform.DOKill(true);
            transform.DOPunchScale(Vector3.one * .2f, .3f);
        }

        private void HideOutline()
        {
            outline.SetActive(false);
        }

        private void OnConfirmationChanged()
        {
            if (currentAction is EnemyAction enemyAction)
            {
                maybe.SetActive(!enemyAction.IsConfirmed);
                group.alpha = enemyAction.IsConfirmed ? 1 : .5f;
            }
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            Current.GameCard.TriggerOnPointerEnter(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Current.GameCard.TriggerOnPointerExit(eventData);
        }
    }
}