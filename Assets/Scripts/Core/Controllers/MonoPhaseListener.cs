using System;
using UnityEngine;

namespace WitchGate.Controllers
{
    public abstract class MonoPhaseListener<T> : MonoBehaviour, IPhaseListener<T> where T : IPhase
    {
        protected virtual void OnEnable()
        {
            this.Register();
        }

        protected virtual  void OnDisable()
        {
            this.Unregister();
        }
        
        void IPhaseListener<T>.OnPhaseBegins(T phase)
        {
            OnPhaseBegins(phase);
        }

        void IPhaseListener<T>.OnPhaseEnds(T phase)
        {
            OnPhaseEnds(phase);
        }


        protected virtual void OnPhaseBegins(T phase){ }
        protected virtual void OnPhaseEnds(T phase) { }
    }
}