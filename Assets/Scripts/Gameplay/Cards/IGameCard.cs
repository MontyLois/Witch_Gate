using System.Collections.Generic;
using Helteix.Cards;
using UnityEngine;
using WitchGate.Cards.Collections;
using WitchGate.Gameplay.Battles.Entities.Interface;
using WitchGate.Gameplay.Cards;

namespace WitchGate.Cards
{
    public interface IGameCard :ICard, IDescription
    {
        public Awaitable Use(IReadOnlyList<ICanFight> targets, ICanFight caster);
        public CardData CardData { get; }
        public ICardAnimator CardAnimator { get; set; }
        public Witch WitchDeck { get; }
    }
}