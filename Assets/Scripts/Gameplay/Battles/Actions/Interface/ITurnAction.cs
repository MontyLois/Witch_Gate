using UnityEngine;
using WitchGate.Gameplay.Cards;

namespace WitchGate.Gameplay.Battles.Actions.Interface
{
    public interface ITurnAction
    {
        public int Priority { get; set; }
        string Label { get; }
        
        
        IGameCard GameCard { get;  }
        Awaitable Execute();
    }
}