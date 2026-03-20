using System;

namespace WitchGate.Gameplay.Controller.Component
{
    public class PlayerDirectionListener
    {
        public void Bind(PlayerBody body, Action<float> callback)
        {
            body.OnChangedXDirection += callback;
        }

        public void Unbind(PlayerBody body, Action<float> callback)
        {
            body.OnChangedXDirection -= callback;
        }
    }
}