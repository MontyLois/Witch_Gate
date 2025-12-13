using UnityEngine;
using WitchGate.Gameplay.Battles.Entities.Interface;
using WitchGate.Gameplay.Cards.DamageModifier;

namespace WitchGate.Gameplay.Cards.Effects
{
    [CreateAssetMenu(fileName = "NewRedirectDamageEffect", menuName = "WitchGate/Cards/Effects/RedirectDamage", order = 0)]
    public class RedirectDamageToSelfEffectData : CardBattleEffectData
    {
        [field: SerializeField, Range(0f, 1f)] public int DamagePercent { get; private set; }
        [field: SerializeField] public int LifeCycle { get; private set; }
        protected override void ApplyEffect(ICanFight target, ICanFight caster)
        {
            IDamageModifier damageModifier = new RedirectDamageEffect(caster, DamagePercent,LifeCycle);
            target.AddModifier(damageModifier);
        }
    }
}