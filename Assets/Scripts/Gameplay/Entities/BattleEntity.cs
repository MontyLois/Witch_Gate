using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using WitchGate.Gameplay.Battles.Entities.Interface;

namespace WitchGate.Gameplay.Battles.Entities
{
    public abstract class BattleEntity : ICanFight
    {
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; private set; }
        public int CurrentShield { get; private set; }
        public abstract Faction Faction { get; }
        public List<IDamageModifier> DamageModifiers { get; }

        public event Action<int> OnShieldUpdate;
        public event Action OnShieldDown;
        public event Action<float> OnDamageTaken;
        public event Action<float> OnHealReceived;
        public event Action OnDeath;

        protected BattleEntity(int maxHealth, int currentHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
            CurrentShield = 0;
            DamageModifiers = new List<IDamageModifier>();
            TargetRegistry.Register(this);
        }

        public void TakeDamages(DamageContext context)
        {
            foreach (var modifier in DamageModifiers)
                modifier.Modify(context);

            context.Target.ApplyDamage(context.Amount);
        }

        public void ApplyDamage(int damages)
        {
            if (CurrentShield > 0)
            {
                DamageShield(ref damages);
            }

            if (damages > 0)
            {
                CurrentHealth -= damages;
                CurrentHealth = Mathf.Max(CurrentHealth, 0);

                OnDamageTaken?.Invoke(Mathf.Clamp01((float)CurrentHealth/MaxHealth));

                if (CurrentHealth == 0)
                {
                    OnDeath?.Invoke();
                    TargetRegistry.Unregister(this);
                }
            }
        }

        private void DamageShield(ref int damages)
        {
            if (CurrentShield <= damages)
            {
                damages -= CurrentShield;
                CurrentShield = 0;
                OnShieldDown?.Invoke();
            }
            else
            {
                CurrentShield -= damages;
                damages = 0;
                OnShieldUpdate?.Invoke(CurrentShield);
            }
        }

        public void HealHealth(int heal)
        {
            CurrentHealth = Mathf.Min(CurrentHealth + heal, MaxHealth);
            OnHealReceived?.Invoke(Mathf.Clamp01((float)CurrentHealth/MaxHealth));
        }

        public void AddShield(int shield)
        {
            CurrentShield += shield;
            OnShieldUpdate?.Invoke(CurrentShield);
        }

        public void AddModifier(IDamageModifier modifier) => DamageModifiers.Add(modifier);
        public void RemoveModifier(IDamageModifier modifier) => DamageModifiers.Remove(modifier);

        public void ResetShield()
        {
            CurrentShield = 0;
            OnShieldDown?.Invoke();
        }

        public void OnEndTurn()
        {
            ResetShield();
            using (ListPool<IDamageModifier>.Get(out var list))
            {
                list.AddRange(DamageModifiers);
                foreach (var damageModifier in list)
                    RemoveModifier(damageModifier);
            }
        }
    }
}