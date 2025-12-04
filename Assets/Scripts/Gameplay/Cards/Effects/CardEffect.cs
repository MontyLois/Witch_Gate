using System.Collections.Generic;
using UnityEngine;
using WitchGate.Cards;
using WitchGate.Gameplay.Battles;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Gameplay.Battles.Entities.Interface;

namespace WitchGate.Gameplay.Cards.Effects
{
    public abstract class CardEffect : ScriptableObject
    {
        [field: SerializeField]
        public CardData CardData { get; private set; }
        
        
        [field: SerializeField]
        public bool SelfAffected { get; private set; }
        
        [field: SerializeField]
        public bool AlliesAffected { get; private set; }
        
        [field: SerializeField]
        public bool EnemiesAffected { get; private set; }

        protected void AffectTargets(List<ICanFight> targets, BattleWitch caster)
        {
            foreach (var target in targets)
            {
                if ((IsSelf(target, caster)&& SelfAffected)||
                    (IsAlly(target, caster)&& AlliesAffected)||
                    (IsEnemy(target)&& EnemiesAffected))
                {
                    ApplyEffect(target);
                }
            }
        }

        private bool IsSelf(ICanFight target, ICanFight caster) => ReferenceEquals(target, caster);
        private bool IsAlly(ICanFight target, ICanFight caster) => target is BattleWitch && !IsSelf(target, caster);
        private bool IsEnemy(ICanFight target) => target is BattleEnemy;
                                                          
        
        protected abstract void ApplyEffect(ICanFight target);
    }
}