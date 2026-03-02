using UnityEngine;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public interface ITurnAction
    {
        public int Priority { get; set; }
        string Label { get; }
        Awaitable Execute();
    }
}