using System;
using UnityEngine;
using WitchGate.Controllers;

namespace WitchGate.Gameplay.Battles.UI
{
    public class BattlePhaseUI : MonoBehaviour, IPhaseListener<BattlePhase>
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
            
        }

        public void OnPhaseCompletes(BattlePhase phase)
        {
            
        }

        public void OnPhaseCanceled(BattlePhase phase)
        {
            
        }
    }
}