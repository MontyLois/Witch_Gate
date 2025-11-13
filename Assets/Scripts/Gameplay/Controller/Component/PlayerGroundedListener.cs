namespace WitchGate.Gameplay.Controller.Component
{
    public abstract class PlayerGroundedListener : PlayerComponent
    {
        protected void OnEnable()
        {
            Manager.Body.OnChangedGrounded += OnGroundedChanged;
        }

        protected void OnDisable()
        {
            Manager.Body.OnChangedGrounded -= OnGroundedChanged;
        }

        protected abstract void OnGroundedChanged(bool grounded);
    }
}