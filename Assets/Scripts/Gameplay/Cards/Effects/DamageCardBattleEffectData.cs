using System.Collections.Generic;
using UnityEngine;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Gameplay.Battles.Entities.Interface;

namespace WitchGate.Gameplay.Cards.Effects
{
    [CreateAssetMenu(fileName = "NewDamageEffect", menuName = "WitchGate/Cards/Effects/Damage", order = 0)]
    public class DamageCardBattleEffectData : CardBattleEffectData
    {
        [field: SerializeField]
        public int Damage { get; private set; }


        protected override void ApplyEffect(ICanFight target, ICanFight caster)
        {
            var context = new DamageContext
            {
                Source = caster,
                Target = target,
                Amount = Damage
            };
            
            Debug.Log("deal damages");
            target.TakeDamages(context);
        }
    }
}