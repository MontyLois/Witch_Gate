using UnityEngine;
using WitchGate.Gameplay.Controller.Component;

namespace WitchGate.Gameplay.Controller
{
    public class PlayerRenderer : PlayerDirectionListener
    {
        [SerializeField] 
        private SpriteRenderer spriteRenderer;
        
        protected override void OnDirectionChanged(float dir)
        {
            spriteRenderer.flipX = dir < 0;
        }
    }
}
