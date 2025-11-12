using UnityEngine;

namespace WitchGate.Controllers
{
    public interface IPhase
    {
        Awaitable OnBegin();
        Awaitable Execute();
        Awaitable OnEnd();
    }
}