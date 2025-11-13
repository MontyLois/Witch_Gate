using System;

namespace WitchGate.Gameplay.Controller.Component
{
    public abstract class PlayerDirectionListener: PlayerComponent
    {
        protected void OnEnable()
        {
            Manager.Body.OnChangedXDirection += OnDirectionChanged;
        }

        protected void OnDisable()
        {
            Manager.Body.OnChangedXDirection -= OnDirectionChanged;
        }

        protected abstract void OnDirectionChanged(float dir);
    }
}