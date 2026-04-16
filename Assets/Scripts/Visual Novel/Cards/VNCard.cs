using System.Collections.Generic;
using cherrydev;
using Helteix.Cards;
using TMPro;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Cards.Collections;
using WitchGate.Controllers;
using WitchGate.Gameplay.Cards.Effects;

namespace WitchGate.VisualNovel.Visual_Novel.Cards
{
    public class VNCard : Card
    {
        public CardData Data { get; }
        public int Level { get; private set; }
        public Witch WitchName { get; private set; }

        public VNCard(CardData data, int level, Witch witchName)
        {
            if(data == null)
                Debug.LogError("No data was given to the card");
            Data = data;
            this.Level = level;
            WitchName = witchName;
        }
        
        public IEnumerable<CardVNEffectData> Effects => VNCardManager.GetEffectsFor(Data);
        
        public async Awaitable Use()
        {
            /*
            foreach (var effect in Effects)
            {
                effect.AffectTarget(text);
            }*/
            
            await PhaseController.CompletedAwaitable;
        }
    }
}