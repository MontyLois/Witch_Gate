using System;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Controllers;

namespace WitchGate.Gameplay.Cards.DeckImprovement
{
    public class DeckImprovementPhase : IPhase
    {

        public Action<CardProfile> OnHoveredCard;
        public Action<CardProfile> UnHoveredCard;

        public bool IsReady=false;
        
        public async Awaitable OnBegin()
        {
            
        }

        public async Awaitable Execute()
        {
            while (!IsReady)
                await Awaitable.NextFrameAsync();
        }

        public async Awaitable OnEnd()
        {
            
        }
    }
}