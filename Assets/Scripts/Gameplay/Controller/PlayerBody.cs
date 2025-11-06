using UnityEngine;

namespace WitchGate.Gameplay.Controller
{
    [DefaultExecutionOrder(100)]
    public class PlayerBody : PlayerComponent
    {
        [SerializeField] 
        private Rigidbody rb;

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
            rb.linearVelocity = CurrentVelocity;
            
            CurrentVelocity = Vector3.zero;

            CheckGround();
        }

        private void CheckGround()
        {
            if(checkGroundPosition == null)
                return;
            
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
        }

        private void OnDrawGizmos()
        {
            if(checkGroundPosition == null)
                return;
            
            Gizmos.color = Color.red;
            Gizmos.DrawRay(checkGroundPosition.position, Vector3.down * checkGroundDistance);
        }
    }
}