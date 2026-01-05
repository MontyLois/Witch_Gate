using UnityEngine;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Gameplay.Battles.Entities.Interface;

namespace WitchGate.Gameplay.Cards.DamageModifier
{
    public class MitigateDamagesEffect : IDamageModifier
    {
        private float damagePercent;
        public int RemainingTurns { get; set; }

        public MitigateDamagesEffect(float damagePercent, int life)
        {
            this.damagePercent = damagePercent;
            RemainingTurns = life;
        }
        
        public void Modify(ref DamageContext context)
        {
            context.Amount -= GetNewDamageAmount(context);
        }
        
        private int GetNewDamageAmount(DamageContext context) =>  Mathf.RoundToInt(context.Amount * damagePercent);
        
    }
}