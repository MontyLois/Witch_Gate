using System;
using UnityEngine;
using UnityEngine.UI;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.Entities;

namespace WitchGate.Gameplay.Battles.UI
{
    public class BattlePhaseUI : MonoPhaseListener<BattlePhase>
    {
        private BattlePhase battlePhase;

        [field : SerializeField] public BattleEntityUI EnemyUI { get; private set; }
        [field : SerializeField] public BattleEntityUI VelmoraUI { get; private set; }
        [field : SerializeField] public BattleEntityUI ElarisUI { get; private set; }
        
        protected override void OnPhaseBegins(BattlePhase phase)
        {
            this.Register();
            battlePhase = phase;
            EnemyUI.Connect(phase.Enemy);
            VelmoraUI.Connect(phase.Velmora);
            ElarisUI.Connect(phase.Elaris);
        }

        protected override void OnPhaseEnds(BattlePhase phase)
        {
            this.Unregister();
            battlePhase = null;
            EnemyUI.Disconnect();
            VelmoraUI.Disconnect();
            ElarisUI.Disconnect();
        }
    }
}