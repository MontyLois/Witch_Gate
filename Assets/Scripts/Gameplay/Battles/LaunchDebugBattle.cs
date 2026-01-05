using System;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Gameplay.Entities;
using WitchGate.Players;

namespace WitchGate.Gameplay.Battles
{
    public class LaunchDebugBattle : MonoBehaviour
    {
        [SerializeField]
        private BattleProfile enemyProfile;
        
        private void Start()
        {
            BattlePhase phase = new BattlePhase(new BattleEnemy(enemyProfile));
            phase.Run();
        }
    }
}