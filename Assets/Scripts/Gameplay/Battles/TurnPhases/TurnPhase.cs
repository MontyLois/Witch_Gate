using UnityEngine;
using WitchGate.Controllers;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public abstract class TurnPhase : IPhase
    {
        protected readonly BattlePhase BattlePhase;

        protected TurnPhase(BattlePhase battlePhase)
        {
            this.BattlePhase = battlePhase;
        }

        Awaitable IPhase.OnBegin()
        {
            return OnBegin();
        }

        async Awaitable IPhase.Execute()
        {
            ITurnAction[] turnActions = await Execute();

            ResolutionPhase resolutionPhase = new ResolutionPhase(turnActions);

            await resolutionPhase.RunAsync();
        }

        Awaitable IPhase.OnEnd()
        {
            return OnEnd();
        }

        protected abstract Awaitable OnBegin();
        protected abstract Awaitable<ITurnAction[]> Execute();
        protected abstract Awaitable OnEnd();
    }
}