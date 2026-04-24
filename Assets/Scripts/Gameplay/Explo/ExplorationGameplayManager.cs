using System;
using Helteix.Singletons.MonoSingletons;
using UnityEngine;
using WitchGate.Gameplay.Controller;

namespace WitchGate.Gameplay
{
    public class ExplorationGameplayManager : MonoSingleton<ExplorationGameplayManager>
    {

        [field: SerializeField] public PlayerManager playerManager { get; private set; }

        public void Start()
        {
            
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