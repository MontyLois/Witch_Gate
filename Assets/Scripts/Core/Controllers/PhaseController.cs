using System.Collections.Generic;

namespace WitchGate.Controllers
{
    public class PhaseController
    {
        private readonly List<IPhaseListener> listeners = new();

        public void RegisterListener<T>(IPhaseListener<T> listener) where T : IPhase
        {
            listeners.Add(listener);
        }
        public void UnregisterListener<T>(IPhaseListener<T> listener) where T : IPhase
        {
            listeners.Remove(listener);
        }
        
        internal void TriggerListenerForBegin<T>(T phase) where T : IPhase
        {
            foreach (var listener in listeners)
            {
                if(listener is IPhaseListener<T> compatible)
                    compatible.OnPhaseBegins(phase);
            }
        }
        
        internal void TriggerListenerForComplete<T>(T phase) where T : IPhase
        {
            foreach (var listener in listeners)
            {
                if(listener is IPhaseListener<T> compatible)
                    compatible.OnPhaseCompletes(phase);
            }
        }
        
        internal void TriggerListenerForCancel<T>(T phase) where T : IPhase
        {
            foreach (var listener in listeners)
            {
                if(listener is IPhaseListener<T> compatible)
                    compatible.OnPhaseCanceled(phase);
            }
        }
    }
}