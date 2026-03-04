using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.Timelines;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public class ResolutionPhase : IPhase
    {
        public readonly TurnTimeline timeline;
        
        
        public ResolutionPhase(TurnTimeline timeline)
        {
            this.timeline = timeline;
        }

        async Awaitable IPhase.OnBegin()
        {
            await PhaseController.CompletedAwaitable;
        }

        async Awaitable IPhase.Execute()
        {
            foreach (ITurnAction turnAction in timeline.Actions)
                await turnAction.Execute();
        }

        async Awaitable IPhase.OnEnd()
        {
            await PhaseController.CompletedAwaitable;
        }
    }
}