using System;
using Helteix.Cards;
using Helteix.Cards.UI.Physical;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Players;

namespace WitchGate.Cards
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