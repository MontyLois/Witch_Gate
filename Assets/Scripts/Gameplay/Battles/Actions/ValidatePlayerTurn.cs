using UnityEngine;
using WitchGate.Controllers;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class ValidatePlayerTurn : MonoPhaseListener<PlayerTurnPhase>
    {

        private PlayerTurnPhase playerTurnPhase;
        
        protected override void OnPhaseBegins(PlayerTurnPhase phase)
        {
            this.Register();
            playerTurnPhase = phase;
        }

        protected override void OnPhaseEnds(PlayerTurnPhase phase)
        {
            this.Unregister();
            playerTurnPhase = null;
        }

        public void OnValidateTurn()
        {
            if(playerTurnPhase is null)
                return;
            
            playerTurnPhase.SetReady();
        }
    }
}