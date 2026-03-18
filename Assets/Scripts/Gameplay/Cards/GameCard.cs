using System;
using System.Collections.Generic;
using System.Linq;
using Helteix.Cards;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles;
using WitchGate.Gameplay.Battles.Entities.Interface;
using WitchGate.Gameplay.Cards.Effects;

namespace WitchGate.Gameplay.Cards
{
    [Serializable]
    public class GameCard : Card, IGameCard
    {
        [field: SerializeField]
        public CardData Data { get; private set; }

        public int Level { get; private set; }
        
        public ICardAnimator CardAnimator { get; internal set; }
        public string CardDescription { get; private set; }
        
        public event Action CardPutDown;
        public event Action UseCard;

        public GameCard(CardData data, int level)
        {
            if(data == null)
                Debug.LogError("No data was given to the card");
            Data = data;
            this.Level = level;
            CardDescription = GetDescription();
        }

        public IEnumerable<CardBattleEffectData> Effects => CardManager.GetEffectsFor(Data);
        
        public string GetDescription()
        {
            string description = "";
            int effectsLenght = Effects.Count();
            for (int i = 0; i < effectsLenght; i++)
            {
                description += Effects.ElementAt(i).GetEffectDescription(Level);
                if (i < Effects.Count() - 1)
                {
                    description += ", ";
                }
            }
            description += ".";
            return description;
        }

        public string GetTitle()
        {
            return Data.Name;
        }

        public async Awaitable Use(IReadOnlyList<ICanFight> targets, ICanFight caster)
        {
            if (CardAnimator != null)
                await CardAnimator.OnAttack();
            
            foreach (var effect in Effects)
            {
                effect.AffectTargets(targets, caster, Level);
            }
            UseCard?.Invoke();
            await PhaseController.CompletedAwaitable;
        }

        public void OnSelected()
        {
            CardPutDown?.Invoke();
        }
    }
}