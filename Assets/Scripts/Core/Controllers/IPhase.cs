namespace WitchGate.Controllers
{
    public interface IPhase
    {
        void OnBegin();
        void OnComplete();
        void OnCancel();
    }
}