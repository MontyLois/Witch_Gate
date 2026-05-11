using UnityEngine;
using WitchGate.Gameplay.Explo.Controller.Component.Helpers;

namespace WitchGate.Gameplay.Explo.Controller.Component
{
    public class PlayerAnimator : PlayerComponent
    {
        [SerializeField] 
        private Animator animator;

        private PlayerDirectionListener directionListener = new();
        private PlayerGroundedListener groundedListener = new();
        private PlayerInteractionListener interactionListener = new();

        private void OnEnable()
        {
            directionListener.Bind(Manager.Body, OnDirectionChanged);
            groundedListener.Bind(Manager.Body, OnGroundedChanged);
            interactionListener.Bind(Manager.Body, OnInteraction);
        }

        private void OnDisable()
        {
            directionListener.Unbind(Manager.Body, OnDirectionChanged);
            groundedListener.Unbind(Manager.Body, OnGroundedChanged);
            interactionListener.Unbind(Manager.Body, OnInteraction);
        }
        
        private void Update()
        {
            animator.SetFloat("Velocity", Manager.Body.rb.linearVelocity.magnitude);
        }

        private void OnGroundedChanged(bool grounded)
        {
            animator.SetBool("Grounded",grounded);
        }
        
        private void OnDirectionChanged(float velocity)
        {
            animator.SetFloat("Direction",velocity);
            animator.SetTrigger("DirectionChanged");
        }

        private void OnInteraction()
        {
            animator.SetTrigger("Interaction");
        }
    }
}