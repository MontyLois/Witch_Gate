using System.Collections.Generic;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.Entities.Interface;

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