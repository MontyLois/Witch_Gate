using UnityEngine;
using WitchGate.Controllers;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class PlayerTurnPhase : TurnPhase
    {
        public bool IsReady { get; private set; }

        public BattleWitch Velmora => BattlePhase.Velmora;
        public BattleWitch Elaris => BattlePhase.Elaris;
  
        
        public PlayerTurnPhase(BattlePhase battlePhase) : base(battlePhase)
        {
           
        }
        
        protected override async Awaitable OnBegin()
        {
            IsReady = false;
            Velmora.DrawMissingCards();
            Elaris.DrawMissingCards();
        }

        protected override async Awaitable<ITurnAction[]> Execute()
        {
            while (!IsReady)
                await Awaitable.NextFrameAsync();

            ITurnAction[] turnActions = {
                new PlayCardAction(BattlePhase),
                new PlayCardAction(BattlePhase),
            };

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