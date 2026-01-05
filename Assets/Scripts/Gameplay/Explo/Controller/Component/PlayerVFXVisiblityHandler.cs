using UnityEngine;

namespace WitchGate.Gameplay.Controller.Component
{
    public class PlayerVFXVisiblityHandler : PlayerGroundedListener
    {
        [field: SerializeField] public bool VisibleWhenGrounded { get; private set; }
        
        private void OnEnable()
        {
            base.OnEnable();
            OnGroundedChanged(Manager.Body.IsGrounded);
        }
        protected override void OnGroundedChanged(bool grounded)
        {
            this.gameObject.SetActive(grounded == VisibleWhenGrounded);
        }
    }
}