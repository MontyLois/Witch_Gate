using System;
using UnityEngine;

namespace WitchGate.Gameplay.Controller
{
    [DefaultExecutionOrder(100)]
    public class PlayerBody : PlayerComponent
    {
        [SerializeField] 
        public Rigidbody rb;

        [field: SerializeField]
        public Vector3 CurrentVelocity { get; private set; }

        [SerializeField] 
        private LayerMask groundLayer;
        [SerializeField] 
        private Transform checkGroundPosition;
        [SerializeField] 
        private float checkGroundDistance;

        public Vector3 GroundPosition { get; private set; }
        public bool IsGrounded { get; private set; }
        
        public bool CanMove { get; private set; }
        private float direction = 1;

        public event Action<float> OnChangedXDirection;
        public event Action<bool> OnChangedGrounded;
        
        public void ApplyVelocity(Vector3 currentVelocity)
        {
            if (CanMove)
            {
                CurrentVelocity += currentVelocity;
            }
        }

        public void setCanMove(bool canMove)
        {
            CanMove = canMove;
        }

        private void FixedUpdate()
        {
            CheckDirectionChange();
            
            rb.linearVelocity = CurrentVelocity;
            
            CurrentVelocity = Vector3.zero;

            CheckGround();
        }

        private void CheckGround()
        {
            if(checkGroundPosition == null)
                return;

            bool wasGrounded = IsGrounded;
            
            if (Physics.Raycast(checkGroundPosition.position, Vector3.down, out RaycastHit hit, checkGroundDistance,
                    groundLayer))
            {
                GroundPosition = hit.point;
                IsGrounded = true;
            }
            else
            {
                GroundPosition = checkGroundPosition.position;
                IsGrounded = false;
            }

            if (wasGrounded != IsGrounded)
                OnChangedGrounded?.Invoke(IsGrounded);
        }

        private void OnDrawGizmos()
        {
            if(checkGroundPosition == null)
                return;
            
            Gizmos.color = Color.red;
            Gizmos.DrawRay(checkGroundPosition.position, Vector3.down * checkGroundDistance);
        }

        private void CheckDirectionChange()
        {
            if (CurrentVelocity.x != 0 && (Mathf.Sign(CurrentVelocity.x) != Mathf.Sign(direction)))
            {
                direction = Mathf.Sign(CurrentVelocity.x);
                OnChangedXDirection?.Invoke(direction);
            }
        }
    }
}