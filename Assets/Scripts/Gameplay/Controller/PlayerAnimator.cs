using UnityEngine;

namespace WitchGate.Gameplay.Controller
{
    public class PlayerAnimator : PlayerComponent
    {
        [SerializeField] 
        private Animator animator;

        private void Update()
        {
            animator.SetBool("Grounded",Manager.Body.IsGrounded);
        }
    }
}