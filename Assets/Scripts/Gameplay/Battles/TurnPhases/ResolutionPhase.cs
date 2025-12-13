using System.Collections.Generic;
using UnityEngine;
using WitchGate.Controllers;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class ResolutionPhase : IPhase
    {
        public readonly List<ITurnAction> Actions;
        
        
        public ResolutionPhase(List<ITurnAction> actions)
        {
            Actions = actions;
        }

        async Awaitable IPhase.OnBegin()
        {
            await PhaseController.CompletedAwaitable;
        }

        async Awaitable IPhase.Execute()
        {
            for (int i = 0; i < Actions.Count; i++)
                await Actions[i].Execute();
            
            await Awaitable.WaitForSecondsAsync(2f);
        }

        async Awaitable IPhase.OnEnd()
        {
            await PhaseController.CompletedAwaitable;
        }
    }
}