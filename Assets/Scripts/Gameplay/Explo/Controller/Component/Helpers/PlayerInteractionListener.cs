using System;

namespace WitchGate.Gameplay.Controller.Component
{
    public class PlayerInteractionListener
    {
        public void Bind(PlayerBody body, Action callback)
        {
            body.OnInteract += callback;
        }

        public void Unbind(PlayerBody body, Action callback)
        {
            body.OnInteract -= callback;
        }
        
        public void Bind(PlayerBody body, Action<bool> callback)
        {
            body.OnInteractable += callback;
        }

        public void Unbind(PlayerBody body, Action<bool> callback)
        {
            body.OnInteractable -= callback;
        }
    }
}