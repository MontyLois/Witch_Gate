using System.Collections.Generic;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.Entities.Interface;
using WitchGate.Gameplay.Cards;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class PlayerTurnPhase : TurnPhase
    {
        public bool IsReady { get; private set; }
        
        public PlayerTurnPhase(BattlePhase battlePhase) : base(battlePhase)
        {
           
        }
        
        protected override async Awaitable OnBegin()
        {
            IsReady = false;
            
        }

        protected override async Awaitable<List<ITurnAction>> Execute()
        {
            while (!IsReady)
                await Awaitable.NextFrameAsync();
            
            List<GameCard> playedCards = BattlePhase.GetAllPlayedCards();
            List<ITurnAction> turnActions = new List<ITurnAction>();
            for (int i = 0; i < playedCards.Count; i++)
            {
                turnActions.Add(new PlayCardAction(playedCards[i], BattlePhase));
            }
            return turnActions;
        }

        protected override async Awaitable OnEnd()
        {
            await PhaseController.CompletedAwaitable;
        }


        public void SetReady()
        {
            IsReady = true;
        }
    }
}