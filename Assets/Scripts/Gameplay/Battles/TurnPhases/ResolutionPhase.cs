using UnityEngine;
using WitchGate.Controllers;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class ResolutionPhase : IPhase
    {
        public readonly ITurnAction[] Actions;

        public ResolutionPhase(ITurnAction[] actions)
        {
            Actions = actions;
        }

        async Awaitable IPhase.OnBegin()
        {
            await PhaseController.CompletedAwaitable;
        }

        async Awaitable IPhase.Execute()
        {
            for (int i = 0; i < Actions.Length; i++)
                await Actions[i].Execute();
        }

        async Awaitable IPhase.OnEnd()
        {
            await PhaseController.CompletedAwaitable;
        }
    }
}