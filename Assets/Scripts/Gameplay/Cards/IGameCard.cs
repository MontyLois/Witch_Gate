using System;
using System.Collections.Generic;
using Helteix.Cards;
using UnityEngine;
using UnityEngine.EventSystems;
using WitchGate.Cards;
using WitchGate.Cards.Collections;
using WitchGate.Gameplay.Entities.Interface;

namespace WitchGate.Gameplay.Cards
{
    public interface IGameCard :ICard, IDescription
    {
        event Action OnPointerEnter;
        event Action OnPointerExit;
        
        public Awaitable Use(IReadOnlyList<ICanFight> targets, ICanFight caster);
        public CardData CardData { get; }
        public ICardAnimator CardAnimator { get; set; }
        public Witch WitchDeck { get; }

        public void TriggerOnPointerEnter(PointerEventData eventData);
        public void TriggerOnPointerExit(PointerEventData eventData);
    }
}