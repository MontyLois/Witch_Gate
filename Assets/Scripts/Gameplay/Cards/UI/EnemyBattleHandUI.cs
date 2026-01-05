using Helteix.Cards.UI.Physical;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles;

namespace WitchGate.Gameplay.Cards.UI
{
    public class EnemyBattleHandUI : PhysicalCardCollectionUI<GameCard>, IPhaseListener<BattlePhase>
    {
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
            Connect(phase.Enemy.Hand);
        }

        public void OnPhaseEnds(BattlePhase phase)
        {
            Disconnect();
        }
    }
}