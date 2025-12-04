using System.Collections.Generic;
using UnityEngine;
using WitchGate.Gameplay.Battles.Entities.Interface;

namespace WitchGate.Gameplay.Cards.Effects
{
    [CreateAssetMenu(fileName = "NewShieldEffect", menuName = "WitchGate/Cards/Effects/Shield", order = 0)]
    public class ShieldCardEffect : CardEffect
    {
        [field: SerializeField]
        public int Shield { get; private set; }
        
        protected override void ApplyEffect(ICanFight target)
        {
           target.AddShield(Shield);
        }
    }
}