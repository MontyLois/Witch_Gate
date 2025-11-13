using UnityEngine;
using WitchGate.Gameplay.Controller.Component;

namespace WitchGate.Gameplay.Controller
{
    public class PlayerAnimator : PlayerGroundedListener
    {
        [SerializeField] 
        private Animator animator;
        

        protected override void OnGroundedChanged(bool grounded)
        {
            animator.SetBool("Grounded",grounded);
        }
    }
}