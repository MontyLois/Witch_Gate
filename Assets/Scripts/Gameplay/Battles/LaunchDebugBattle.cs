using System;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Players;

namespace WitchGate.Gameplay.Battles
{
    public class LaunchDebugBattle : MonoBehaviour
    {
        [SerializeField]
        private PlayerProfile playerProfile;
        private void Start()
        {
            BattlePhase phase = new BattlePhase(new BattleEnemy(10), playerProfile);
            phase.Run();
        }
    }
}