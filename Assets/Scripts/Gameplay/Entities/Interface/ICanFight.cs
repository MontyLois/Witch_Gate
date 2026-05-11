using System.Collections.Generic;
using WitchGate.Gameplay.Cards.DamageModifier;

namespace WitchGate.Gameplay.Entities.Interface
{
    public interface ICanFight
    {
        Faction Faction { get;}
        List<IDamageModifier> DamageModifiers { get; }
        void TakeDamages(DamageContext context);
        void ApplyDamage(int damages);
        void HealHealth(int heal);
        void AddShield(int shield);
        void AddModifier(IDamageModifier modifier);
        void RemoveModifier(IDamageModifier modifier);
        void OnEndTurn();
    }
}