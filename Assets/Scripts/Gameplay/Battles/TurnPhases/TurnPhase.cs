using UnityEngine;
using WitchGate.Controllers;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public abstract class TurnPhase : IPhase
    {
        Awaitable IPhase.OnBegin()
        {
            return OnBegin();
        }

        Awaitable IPhase.Execute()
        {
            return Execute();
        }

        Awaitable IPhase.OnEnd()
        {
            return OnEnd();
        }

        protected abstract Awaitable OnBegin();
        protected abstract Awaitable Execute();
        protected abstract Awaitable OnEnd();
    }
}