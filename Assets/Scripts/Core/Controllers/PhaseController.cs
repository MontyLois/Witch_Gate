using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace WitchGate.Controllers
{
    public static class PhaseController
    {
        static readonly AwaitableCompletionSource CompletionSource = new();
        public static Awaitable CompletedAwaitable
        {
            get
            {
                CompletionSource.SetResult();
                var awaitable = CompletionSource.Awaitable;
                CompletionSource.Reset();
                return awaitable;
            }
        }

        private static readonly List<IPhaseListener> listeners = new();

        public static void Register<T>(this IPhaseListener<T> listener) where T : IPhase
        {
            listeners.Add(listener);
        }

        public static void Unregister<T>(this IPhaseListener<T> listener) where T : IPhase
        {
            listeners.Remove(listener);
        }

        public static Awaitable Run<T>(this T phase) where T : IPhase
        {
            return RunAsync(phase);
        }

        public static async Awaitable RunAsync<T>(this T phase) where T : IPhase
        {
            try
            {
                using (ListPool<IPhaseListener<T>>.Get(out List<IPhaseListener<T>> compatibles))
                {
                    await phase.OnBegin();
                    GetListeners(compatibles);

                    foreach (var compatible in compatibles)
                        compatible.OnPhaseBegins(phase);

                    await phase.Execute();

                    GetListeners(compatibles);
                    foreach (var compatible in compatibles)
                        compatible.OnPhaseEnds(phase);

                    await phase.OnEnd();
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private static void GetListeners<T>(List<IPhaseListener<T>> compatibles) where T : IPhase
        {
            compatibles.Clear();
            foreach (var listener in listeners)
                if (listener is IPhaseListener<T> compatible)
                    compatibles.Add(compatible);
        }
    }
}