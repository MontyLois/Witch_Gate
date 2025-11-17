using System;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Players;

namespace WitchGate.Gameplay.Battles
{
    public class LaunchDebugBattle : MonoBehaviour
    {
        [SerializeField]
        private PlayerProfile playerProfile;
        private void Start()
        {
            BattlePhase phase = new BattlePhase(new DebugEnemy(), playerProfile);
            phase.Run();
        }
    }

    internal class DebugEnemy : IBattleEnemy
    {
        public int CurrentHealth => 10;
    }
}