using System;
using Helteix.Singletons.MonoSingletons;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Gameplay.Entities;

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
                GameController.ChangeLocation(Location.City_1);
                BattleController.StartBattle(enemyProfile);
            }
        }
    }
}