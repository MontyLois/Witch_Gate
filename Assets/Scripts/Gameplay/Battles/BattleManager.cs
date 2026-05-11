using System;
using Helteix.Singletons.MonoSingletons;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Gameplay.Entities;
using WitchGate.Profiles.Data;

namespace WitchGate.Gameplay.Battles
{
    public class BattleManager : MonoBehaviour
    {
        [field: SerializeField]
        private BattleProfile enemyProfile;

        private void Start()
        {
            if (BattleController.phase is null)
            {
                BattleController.StartBattle(enemyProfile);
            }
        }
    }
}