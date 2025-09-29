using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Core.Controller
{
    public class PlayerMovement : PlayerComponent
    {
        public Vector3 InputDirection { get; private set; }
        
        public Vector3 TargetVelocity { get; private set; }
        
        public Vector3 CurrentVelocity { get; private set; }

        [SerializeField] 
        private float maxSpeed;
        
        [SerializeField] 
        private float acceleration;
        [SerializeField] 
        private float deceleration;
        
        public bool IsMoving { get; private set; }
        
        private InputAction moveAction;
        
        [SerializeField]
        private Transform reference;

        [SerializeField] 
        private Vector3 inputModifier = Vector3.one;
        
        private void Awake()
        {
            moveAction = InputSystem.actions.FindActionMap("Player").FindAction("3DMovement");
        }

        private void Update()
        {
            ReadInput();
        }

        private void FixedUpdate()
        {
            IsMoving = InputDirection.sqrMagnitude > .1f;
            float deltaTime = Time.deltaTime;
            Vector3 targetVelocity;

            if (IsMoving)
                targetVelocity = InputDirection.normalized * maxSpeed;
            else
                targetVelocity = Vector3.zero;

            targetVelocity.x *= inputModifier.x;
            targetVelocity.y *= inputModifier.y;
            targetVelocity.z *= inputModifier.z;

            float accel = IsMoving ? acceleration : deceleration;

            Vector3 velocity = Vector3.MoveTowards(
                CurrentVelocity, 
                targetVelocity, 
                accel * deltaTime);

            TargetVelocity = targetVelocity;
            CurrentVelocity = velocity;

            Manager.Body.ApplyVelocity(CurrentVelocity);
            
            Debug.Log("Movement Update");
        }

        private void ReadInput()
        {
            Vector3 localInput = moveAction.ReadValue<Vector3>().normalized;

            Vector3 forwardDirection = Vector3.ProjectOnPlane(reference.transform.right, Vector3.up).normalized;
            Vector3 depthDirection = Vector3.ProjectOnPlane(reference.transform.forward, Vector3.up).normalized;
            Vector3 upDirection = Vector3.up;

            InputDirection = forwardDirection * localInput.x +
                             depthDirection * localInput.z +
                             upDirection * localInput.y;
        }
    }
}