using UnityEngine;
using WitchGate.Gameplay.Battles.Entities.Interface;
using WitchGate.Gameplay.Cards.DamageModifier;

namespace WitchGate.Gameplay.Cards.Effects
{
    [CreateAssetMenu(fileName = "NewMitigateDamagesEffectData", menuName = "WitchGate/Cards/Effects/MitigateDamages", order = 0)]
    public class MitigateDamagesEffectData : CardBattleEffectData
    {
        
        [field: SerializeField, Range(0f, 1f)] public float DamagePercent { get; private set; }
        [field: SerializeField] public int LifeCycle { get; private set; }
        
        protected override void ApplyEffect(ICanFight target, ICanFight caster)
        {
            IDamageModifier damageModifier = new MitigateDamagesEffect(DamagePercent,LifeCycle);
            target.AddModifier(damageModifier);
        }
    }
}