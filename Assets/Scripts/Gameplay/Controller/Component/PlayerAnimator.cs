using System;
using UnityEngine;
using WitchGate.Gameplay.Controller.Component;

namespace WitchGate.Gameplay.Controller
{
    public class PlayerAnimator : PlayerGroundedListener
    {
        [SerializeField] 
        private Animator animator;

        private void Update()
        {
            animator.SetFloat("Velocity", Manager.Body.rb.linearVelocity.magnitude);
        }

        protected override void OnGroundedChanged(bool grounded)
        {
            animator.SetBool("Grounded",grounded);
        }

        private void OnVelocityChange(float velocity)
        {
            
        }
    }
}