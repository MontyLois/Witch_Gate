using UnityEngine;

namespace WitchGate.Gameplay.Controller
{
    public class PlayerRenderer : PlayerComponent
    {
        [SerializeField] 
        private SpriteRenderer spriteRenderer;
        
        private void Update()
        {
            float x = Manager.Movement.CurrentVelocity.x;
            
            if (x != 0)
                spriteRenderer.flipX = x > 0;
        }
    }
}
