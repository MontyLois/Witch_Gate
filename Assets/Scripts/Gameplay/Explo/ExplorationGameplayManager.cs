using UnityEngine;
using WitchGate.Gameplay.Controller;

namespace WitchGate.Gameplay
{
    public class ExplorationGameplayManager : MonoBehaviour
    {
        // The one and only instance
        public static ExplorationGameplayManager Instance { get; private set; }

        [field: SerializeField] public PlayerManager playerManager { get; private set; }

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