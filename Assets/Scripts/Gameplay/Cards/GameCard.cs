using System;
using System.Collections.Generic;
using System.Linq;
using Helteix.Cards;
using UnityEngine;
using UnityEngine.EventSystems;
using WitchGate.Cards;
using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.Entities.Interface;
using WitchGate.Gameplay.Cards.Effects;
using WitchGate.Players;

namespace WitchGate.Gameplay.Cards
{
    [Serializable]
    public class GameCard : Card, IGameCard
    {
        public event Action OnPointerEnter;
        public event Action OnPointerExit;
        
        [field: SerializeField]
        public CardProfile Data { get; private set; }
        public Witch WitchDeck {get; private set;}
        public int Level { get; private set; }
        public string Label => Data.CardData.name;
        public int Priority => Data.CardData.Priority;
        public CardData CardData => Data.CardData;
        
        public ICardAnimator CardAnimator { get; set; }
        
        

        public GameCard(CardProfile data)
        {
            if(data == null)
                Debug.LogError("No data was given to the card");
            Data = data;
            this.Level = data.Level;
            WitchDeck = data.witch;
        }

        public IEnumerable<CardBattleEffectData> Effects => CardManager.GetEffectsFor(Data.CardData);
        
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
            return Label;
        }
        
        public async Awaitable Use(IReadOnlyList<ICanFight> targets, ICanFight caster)
        {
            if (CardAnimator != null)
                await CardAnimator.OnAttack();
            
            ApplyEffects(targets, caster);
          
            await PhaseController.CompletedAwaitable;
        }
        
        void IGameCard.TriggerOnPointerEnter(PointerEventData eventData)
        {
            OnPointerEnter?.Invoke();
        }

        void IGameCard.TriggerOnPointerExit(PointerEventData eventData)
        {
            OnPointerExit?.Invoke();
        }
        private void ApplyEffects(IReadOnlyList<ICanFight> targets, ICanFight caster)
        {
            foreach (var effect in Effects)
            {
                effect.AffectTargets(targets, caster, Level);
            }
        }
    }
}