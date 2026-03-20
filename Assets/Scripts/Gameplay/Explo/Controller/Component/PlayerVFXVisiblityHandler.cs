using System;
using UnityEngine;

namespace WitchGate.Gameplay.Controller.Component
{
    public class PlayerVFXVisiblityHandler : PlayerComponent
    {
        [field: SerializeField] public bool VisibleWhenGrounded { get; private set; }
        [field: SerializeField] public GameObject Vfx { get; private set; }
        
        private PlayerGroundedListener groundedListener = new();
        
        private void OnEnable()
        {
            groundedListener.Bind(Manager.Body, OnGroundedChanged);
        }

        private void OnDisable()
        {
            groundedListener.Unbind(Manager.Body, OnGroundedChanged);
        }

        private void OnGroundedChanged(bool grounded)
        {
            Vfx.SetActive(grounded == VisibleWhenGrounded);
        }
    }
}