using System;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Gameplay.Entities;
using WitchGate.Profiles.Data;

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