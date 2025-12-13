using System.Collections.Generic;
using UnityEngine;
using WitchGate.Gameplay.Battles.Entities.Interface;

namespace WitchGate.Gameplay.Cards.Effects
{
    [CreateAssetMenu(fileName = "NewShieldEffect", menuName = "WitchGate/Cards/Effects/Shield", order = 0)]
    public class ShieldCardBattleEffectData : CardBattleEffectData
    {
        [field: SerializeField]
        public int Shield { get; private set; }
        
        protected override void ApplyEffect(ICanFight target, ICanFight caster)
        {
           target.AddShield(Shield);
        }
    }
}