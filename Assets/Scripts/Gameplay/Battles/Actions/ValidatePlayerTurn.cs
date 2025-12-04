using UnityEngine;
using WitchGate.Controllers;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class ValidatePlayerTurn : MonoBehaviour, IPhaseListener<PlayerTurnPhase>
    {


        private PlayerTurnPhase playerTurnPhase;
        
        public void OnPhaseBegins(PlayerTurnPhase phase)
        {
            this.Register();
            playerTurnPhase = phase;
        }

        public void OnPhaseEnds(PlayerTurnPhase phase)
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