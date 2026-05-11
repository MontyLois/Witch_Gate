using System.Collections.Generic;
using UnityEngine;
using WitchGate.Gameplay.Entities.Interface;

namespace WitchGate.Gameplay.Cards.Effects
{
    [CreateAssetMenu(fileName = "NewHealEffect", menuName = "WitchGate/Decks/Cards/Effects/Fight/Heal", order = 0)]
    public class HealCardBattleEffectData : CardBattleEffectData
    {
        [field: SerializeField]
        public int Heal { get; private set; }

        public override string GetEffectDescription(int level)
        {
            return Description.Replace("[value]", (Heal+(UpgradableValue? level : 0)).ToString());
        }

        protected override void ApplyEffect(ICanFight target, ICanFight caster, int level)
        {
            Debug.Log("use heal");
            target.HealHealth(Heal+(UpgradableValue? level : 0));
        }
    }
}