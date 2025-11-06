namespace WitchGate.Controllers
{
    public static class PhaseExtensions
    {
        public static void Register<T>(this IPhaseListener<T> listener) where T : IPhase
        {
            GameController.PhaseController.RegisterListener(listener);
        }
        
        public static void Unregister<T>(this IPhaseListener<T> listener) where T : IPhase
        {
            GameController.PhaseController.UnregisterListener(listener);
        }
        
        public static void Begin(this IPhase phase)
        {
            phase.OnBegin();
            GameController.PhaseController.TriggerListenerForBegin(phase);
        }
        public static void Complete(this IPhase phase)
        {
            phase.OnComplete();
            GameController.PhaseController.TriggerListenerForComplete(phase);
        }
        
        public static void Cancel(this IPhase phase)
        {
            phase.OnCancel();
            GameController.PhaseController.TriggerListenerForComplete(phase);
        }
    }
}