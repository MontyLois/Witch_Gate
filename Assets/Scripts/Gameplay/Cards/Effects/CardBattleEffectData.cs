using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using WitchGate.Cards;
using WitchGate.Gameplay.Entities.Interface;

namespace WitchGate.Gameplay.Cards.Effects
{
    public abstract class CardBattleEffectData : ScriptableObject
    {
        [field: SerializeField]
        public CardData CardData { get; private set; }
        
        [field: SerializeField]
        public string Description { get; private set; }
        
        [field: SerializeField]
        public bool SelfAffected { get; private set; }
        
        [field: SerializeField]
        public bool AlliesAffected { get; private set; }
        
        [field: SerializeField]
        public bool EnemiesAffected { get; private set; }
        
        [field: SerializeField]
        public GameObject Vfx { get; private set; }
        
        [field: SerializeField]
        public bool UpgradableValue { get; private set; }

        public void AffectTargets(IReadOnlyList<ICanFight> targets, ICanFight caster, int cardLevel)
        {
            using (ListPool<ICanFight>.Get(out List<ICanFight> iCanFights))
            {
                iCanFights.AddRange(targets);
                foreach (var target in iCanFights)
                {
                    AffectTargets(target, caster, cardLevel);
                }
            }
        }

        public void AffectTargets(ICanFight target, ICanFight caster, int cardLevel)
        {
            if ((IsSelf(target, caster)&& SelfAffected)||
                (IsAlly(target, caster)&& AlliesAffected)||
                (IsEnemy(target, caster)&& EnemiesAffected))
            {
                ApplyEffect(target, caster, cardLevel);
            }
        }

        public abstract string GetEffectDescription(int level);

        private bool IsSelf(ICanFight target, ICanFight caster) => ReferenceEquals(target, caster);
        private bool IsAlly(ICanFight target, ICanFight caster) => target.Faction == caster.Faction && !IsSelf(target, caster);
        private bool IsEnemy(ICanFight target, ICanFight caster) => target.Faction != caster.Faction;
                                                          
        
        protected abstract void ApplyEffect(ICanFight target, ICanFight caster, int level);
    }
}