using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
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
            SortByPriority();
            for (int i = 0; i < Actions.Count; i++)
                await Actions[i].Execute();
        }

        async Awaitable IPhase.OnEnd()
        {
            await PhaseController.CompletedAwaitable;
        }

        private void SortByPriority()
        {
            Actions.Sort((a, b) => a.Priority.CompareTo(b.Priority));
        }
    }
}