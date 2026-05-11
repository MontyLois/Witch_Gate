using System.Collections.Generic;
using UnityEngine;
using WitchGate.Gameplay.Entities.Interface;

namespace WitchGate.Gameplay.Cards.Effects
{
    [CreateAssetMenu(fileName = "NewShieldEffect", menuName = "WitchGate/Decks/Cards/Effects/Fight/Shield", order = 0)]
    public class ShieldCardBattleEffectData : CardBattleEffectData
    {
        [field: SerializeField]
        public int Shield { get; private set; }
        
        public override string GetEffectDescription(int level)
        {
            string desc = Description.Replace("[value]", (Shield+(UpgradableValue? level : 0)).ToString());
            return desc;
        }
        protected override void ApplyEffect(ICanFight target, ICanFight caster, int level)
        {
           target.AddShield(Shield+(UpgradableValue? level : 0));
        }
    }
}