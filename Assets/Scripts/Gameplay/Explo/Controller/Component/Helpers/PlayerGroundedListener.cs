using System;

namespace WitchGate.Gameplay.Controller.Component
{
    public class PlayerGroundedListener
    {
        public void Bind(PlayerBody body, Action<bool> callback)
        {
            body.OnChangedGrounded += callback;
        }

        public void Unbind(PlayerBody body, Action<bool> callback)
        {
            body.OnChangedGrounded -= callback;
        }
    }
}