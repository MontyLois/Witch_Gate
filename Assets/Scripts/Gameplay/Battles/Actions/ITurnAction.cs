using UnityEngine;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public interface ITurnAction
    {
        Awaitable Execute();
    }
}