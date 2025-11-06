using Helteix.Cards.UI.Physical;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Gameplay.Cards;

namespace WitchGate.Gameplay.Battles.UI
{
    public class WitchBattleHandUI : PhysicalCardCollectionUI<GameCard>, IPhaseListener<BattlePhase>
    {
        [SerializeField] private Witch witch;
        
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
            var hand = witch switch
            {
                Witch.Elaris => phase.ElarisHand,
                Witch.Velmora => phase.VelmoraHand,
                _ => null,
            };
            
            Connect(hand);
        }

        public void OnPhaseCompletes(BattlePhase phase)
        {
            Disconnect();
        }

        public void OnPhaseCanceled(BattlePhase phase)
        {
            Disconnect();
        }
    }
}