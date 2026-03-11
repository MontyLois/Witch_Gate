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
        
        public event Action CardPutDown;
        public event Action UseCard;

        public GameCard(CardData data, int level)
        {
            if(data == null)
                Debug.LogError("No data was given to the card");
            Data = data;
            this.Level = level;
        }

        public IEnumerable<CardBattleEffectData> Effects => CardManager.GetEffectsFor(Data);


        public async Awaitable Use(IReadOnlyList<ICanFight> targets, ICanFight caster)
        {
            if (CardAnimator != null)
                await CardAnimator.OnAttack();
            
            foreach (var effect in Effects)
            {
                effect.AffectTargets(targets, caster);
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