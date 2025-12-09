namespace WitchGate.Gameplay.Controller.Component
{
    public abstract class PlayerGroundedListener : PlayerComponent
    {
        protected virtual void OnEnable()
        {
            Manager.Body.OnChangedGrounded += OnGroundedChanged;
        }

        protected virtual void OnDisable()
        {
            Manager.Body.OnChangedGrounded -= OnGroundedChanged;
        }

        protected abstract void OnGroundedChanged(bool grounded);
    }
}