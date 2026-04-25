using System;
using Helteix.Singletons.MonoSingletons;
using UnityEngine;
using UnityEngine.Serialization;
using WitchGate.Controllers;
using WitchGate.Gameplay.Controller;

namespace WitchGate.Gameplay
{
    public class ExplorationGameplayManager : MonoSingleton<ExplorationGameplayManager>
    {

        [field: SerializeField] public PlayerManager playerManager { get; private set; }
        [field: SerializeField]
        private Location location;
        
        private void Start()
        {
            if (ExplorationGameplayController.phase is null)
            {
                GameController.ChangeLocation(location);
                ExplorationGameplayController.StartPhase(location);
            }
        }

        public void LockPlayerMovement()
        {
            PlayerManager.Instance.Body.setCanMove(false);
        }
        
        public void UnLockPlayerMovement()
        {
            PlayerManager.Instance.Body.setCanMove(true);
        }

        

    }
}