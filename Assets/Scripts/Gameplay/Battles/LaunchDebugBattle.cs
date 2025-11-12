using System;
using UnityEngine;
using WitchGate.Controllers;

namespace WitchGate.Gameplay.Battles
{
    public class LaunchDebugBattle : MonoBehaviour
    {
        private void Start()
        {
            BattlePhase phase = new BattlePhase(new DebugEnemy());
            phase.Run();
        }
    }

    internal class DebugEnemy : IBattleEnemy
    {
        
    }
}