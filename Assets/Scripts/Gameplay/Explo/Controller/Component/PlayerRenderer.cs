using System;
using UnityEngine;
using WitchGate.Gameplay.Controller.Component;

namespace WitchGate.Gameplay.Controller
{
    public class PlayerRenderer : PlayerComponent
    {
        [SerializeField] 
        private SpriteRenderer spriteRenderer;
        private PlayerDirectionListener directionListener = new();

        private void OnEnable()
        {
            directionListener.Bind(Manager.Body, OnDirectionChanged);
        }

        private void OnDisable()
        {
            directionListener.Unbind(Manager.Body, OnDirectionChanged);
        }

        private void OnDirectionChanged(float dir)
        {
            spriteRenderer.flipX = dir < 0;
        }
    }
}
