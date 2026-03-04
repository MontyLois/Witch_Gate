using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.Entities.Interface;
using WitchGate.Gameplay.Cards;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class PlayerTurnPhase : TurnPhase
    {
        public bool IsReady { get; private set; }

        private Dictionary<GameCard, PlayCardAction> cardActions;
        public PlayerTurnPhase(BattlePhase battlePhase) : base(battlePhase)
        {
            cardActions = new();
        }
        
        protected override async Awaitable OnBegin()
        {
            IsReady = false;
            for (int i = 0; i < BattlePhase.PlayedHands.Length; i++)
            {
                var hand = BattlePhase.PlayedHands[i];
                hand.OnCardAdded += AddCardActionEvent;
                hand.OnCardRemoved += RemoveCardActionEvent;
            }

            await Task.CompletedTask;
        }



        protected override async Awaitable Execute()
        {
            while (!IsReady)
                await Awaitable.NextFrameAsync();
        }

        protected override async Awaitable OnEnd()
        {
            for (int i = 0; i < BattlePhase.PlayedHands.Length; i++)
            {
                var hand = BattlePhase.PlayedHands[i];
                hand.OnCardAdded -= AddCardActionEvent;
                hand.OnCardRemoved -= RemoveCardActionEvent;
            }
            await PhaseController.CompletedAwaitable;
        }


        private void AddCardActionEvent(GameCard card)
        {
            PlayCardAction playCardAction = new PlayCardAction(card, BattlePhase);
            if(cardActions.TryAdd(card, playCardAction))
                BattlePhase.TurnTimeline.AddAction(playCardAction);
        }

        private void RemoveCardActionEvent(GameCard card)
        {
            if(cardActions.Remove(card, out PlayCardAction action))
                BattlePhase.TurnTimeline.RemoveAction(action);
                
        }
        public void SetReady()
        {
            IsReady = true;
        }
    }
}