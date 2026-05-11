using UnityEngine;
using WitchGate.Gameplay.Cards.DamageModifier;
using WitchGate.Gameplay.Entities.Interface;

namespace WitchGate.Gameplay.Cards.Effects
{
    [CreateAssetMenu(fileName = "NewMitigateDamagesEffectData", menuName = "WitchGate/Decks/Cards/Effects/Fight/MitigateDamages", order = 0)]
    public class MitigateDamagesEffectData : CardBattleEffectData
    {
        [field: SerializeField]
        public bool UpgradableCycleValue { get; private set; }
        [field: SerializeField, Range(0f, 1f)] public float DamagePercent { get; private set; }
        [field: SerializeField] public int LifeCycle { get; private set; }
        
        
        public override string GetEffectDescription(int level)
        {
            string desc = Description.Replace("[value]", ((DamagePercent+(UpgradableValue? level : 0))*100).ToString());
            desc = desc.Replace("[lifeCycle]", (LifeCycle+(UpgradableCycleValue? level : 0)).ToString());
            return desc;
        }
        
        protected override void ApplyEffect(ICanFight target, ICanFight caster, int level)
        {
            IDamageModifier damageModifier = new MitigateDamagesEffect(DamagePercent+(UpgradableValue? level : 0),
                LifeCycle+ (UpgradableCycleValue? level : 0));
            target.AddModifier(damageModifier);
        }
    }
}