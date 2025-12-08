using UnityEngine;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public interface ITurnAction
    {
        public int Priority { get; set; }
        Awaitable Execute();
    }
}