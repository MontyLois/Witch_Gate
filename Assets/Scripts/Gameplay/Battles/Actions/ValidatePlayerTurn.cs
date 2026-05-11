using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.TurnPhases;

namespace WitchGate.Gameplay.Battles.Actions
{
    public class ValidatePlayerTurn : MonoPhaseListener<PlayerTurnPhase>
    {

        private PlayerTurnPhase playerTurnPhase;

        protected override void OnEnable()
        {
            base.OnEnable();
            this.Register();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            this.Unregister();
        }

        protected override void OnPhaseBegins(PlayerTurnPhase phase)
        {
            playerTurnPhase = phase;
        }

        protected override void OnPhaseEnds(PlayerTurnPhase phase)
        {
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