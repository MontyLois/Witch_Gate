using System;

namespace WitchGate.Gameplay.Explo.Controller.Component.Helpers
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