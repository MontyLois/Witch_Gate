using UnityEngine;
using WitchGate.Cards;
using WitchGate.Gameplay.Cards;

namespace WitchGate.Gameplay.Battles.TurnPhases
{
    public interface ITurnAction
    {
        public int Priority { get; set; }
        string Label { get; }
        GameCard GameCard { get;  }
        Awaitable Execute();
    }
}