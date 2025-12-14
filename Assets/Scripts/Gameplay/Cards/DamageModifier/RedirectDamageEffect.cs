using UnityEngine;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Gameplay.Battles.Entities.Interface;

namespace WitchGate.Gameplay.Cards.DamageModifier
{
    public class RedirectDamageEffect : IDamageModifier
    {
        private ICanFight target;
        private float damagePercent;
        public int RemainingTurns { get; private set; }
        public RedirectDamageEffect(ICanFight target, float damagePercent, int life)
        {
            this.target = target;
            this.damagePercent = damagePercent;
            RemainingTurns = life;
        }

        public void Modify(ref DamageContext context)
        {
            if (TryRedirect(ref context))
                return;
            
            var targetContext = new DamageContext()
            {
                Source = context.Source,
                Target = context.Target,
                Amount = GetNewDamageAmount(context),
            };
            
            target.TakeDamages(targetContext);
            context.Amount -= targetContext.Amount;
        }

        public bool Tick()
        {
            RemainingTurns--;
            return RemainingTurns <= 0;
        }

        private bool TryRedirect(ref DamageContext context) => ReferenceEquals(target,context.Target);

        private int GetNewDamageAmount(DamageContext context) =>  Mathf.RoundToInt(context.Amount * damagePercent);
        
    }
}