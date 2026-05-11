using Helteix.Singletons.MonoSingletons;
using UnityEngine;
using WitchGate.Gameplay.Explo.Controller;

namespace WitchGate.Gameplay.Explo
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

        public void ReturnToTheShop()
        {
            ExplorationGameplayController.phase.ReturnToTheShopAndSkipToNextDay();
        }

    }
}