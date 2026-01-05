using System.Collections.Generic;
using Helteix.Cards;
using TMPro;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Controllers;
using WitchGate.Gameplay.Cards.Effects;

namespace WitchGate.VisualNovel.Visual_Novel.Cards
{
    public class VNCard : Card, IGameCard
    {
        public CardData Data { get; }
        public int Level { get; private set; }

        public VNCard(CardData data, int level)
        {
            if(data == null)
                Debug.LogError("No data was given to the card");
            Data = data;
            this.Level = level;
        }
        
        public IEnumerable<CardVNEffectData> Effects => VNCardManager.GetEffectsFor(Data);
        
        
        public async Awaitable Use(TMP_Text text)
        {
            foreach (var effect in Effects)
            {
                effect.AffectTarget(text);
            }
            await PhaseController.CompletedAwaitable;
        }
    }
}