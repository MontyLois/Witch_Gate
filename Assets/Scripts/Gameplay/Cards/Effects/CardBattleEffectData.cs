using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using WitchGate.Cards;
using WitchGate.Gameplay.Battles;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Gameplay.Battles.Entities.Interface;

namespace WitchGate.Gameplay.Cards.Effects
{
    public abstract class CardBattleEffectData : ScriptableObject
    {
        [field: SerializeField]
        public CardData CardData { get; private set; }
        
        [field: SerializeField]
        public bool SelfAffected { get; private set; }
        
        [field: SerializeField]
        public bool AlliesAffected { get; private set; }
        
        [field: SerializeField]
        public bool EnemiesAffected { get; private set; }

        public void AffectTargets(IReadOnlyList<ICanFight> targets, ICanFight caster)
        {
            using (ListPool<ICanFight>.Get(out List<ICanFight> iCanFights))
            {
                iCanFights.AddRange(targets);
                foreach (var target in iCanFights)
                {
                    AffectTargets(target, caster);
                }
            }
        }

        public void AffectTargets(ICanFight target, ICanFight caster)
        {
            if ((IsSelf(target, caster)&& SelfAffected)||
                (IsAlly(target, caster)&& AlliesAffected)||
                (IsEnemy(target, caster)&& EnemiesAffected))
            {
                ApplyEffect(target, caster);
            }
        }

        private bool IsSelf(ICanFight target, ICanFight caster) => ReferenceEquals(target, caster);
        private bool IsAlly(ICanFight target, ICanFight caster) => target.Faction == caster.Faction && !IsSelf(target, caster);
        private bool IsEnemy(ICanFight target, ICanFight caster) => target.Faction != caster.Faction;
                                                          
        
        protected abstract void ApplyEffect(ICanFight target, ICanFight caster);
    }
}