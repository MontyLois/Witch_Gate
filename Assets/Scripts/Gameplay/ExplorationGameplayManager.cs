using UnityEngine;
using WitchGate.Gameplay.Controller;

namespace WitchGate.Gameplay
{
    public class ExplorationGameplayManager : MonoBehaviour
    {
        // The one and only instance
        public static ExplorationGameplayManager Instance { get; private set; }

        [field: SerializeField] public PlayerManager playerManager { get; private set; }
        void Awake()
        {
                // If there’s already an instance and it’s not this → destroy duplicate
                if (Instance != null && Instance != this)
                {
                    Destroy(gameObject);
                    return;
                }

                Instance = this;

                // Optional: Keep across scene loads
                DontDestroyOnLoad(gameObject);
        }

        public void LockPlayerMovement()
        {
            playerManager.Body.setCanMove(false);
        }
        
        public void UnLockPlayerMovement()
        {
            playerManager.Body.setCanMove(true);
        }
    }
}