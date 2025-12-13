using UnityEngine;

namespace WitchGate.Gameplay.Controller
{
    public abstract class PlayerComponent : MonoBehaviour
    {
        [field: SerializeField]
        public PlayerManager Manager { get; private set; }

        private void OnValidate()
        {
            if (Manager == null)
                Manager = GetComponentInParent<PlayerManager>();
        }
    }
}