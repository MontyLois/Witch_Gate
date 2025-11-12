namespace WitchGate.Controllers
{
    public interface IPhaseListener { }

    public interface IPhaseListener<in T> : IPhaseListener where T : IPhase
    {
        void OnPhaseBegins(T phase);

        void OnPhaseEnds(T phase);
    }
}