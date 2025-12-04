using System;
using UnityEngine;
using WitchGate.Gameplay.Battles.Entities.Interface;

namespace WitchGate.Gameplay.Battles.Entities
{
    public abstract class BattleEntity : ICanFight
    {
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; private set; }
        public int CurrentShield { get; private set; }

        public event Action<int> OnShieldHurt;
        public event Action OnShieldDown;
        public event Action<int> OnDamageTaken;
        public event Action OnDeath;

        protected BattleEntity(int maxHealth, int currentHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
            CurrentShield = 0;
        }

        public void TakeDamages(int damages)
        {
            if (CurrentShield > 0)
            {
                DamageShield(ref damages);
            }

            if (damages > 0)
            {
                CurrentHealth -= damages;
                CurrentHealth = Mathf.Max(CurrentHealth, 0);

                OnDamageTaken?.Invoke(CurrentHealth);

                if (CurrentHealth == 0)
                    OnDeath?.Invoke();
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
                OnShieldHurt?.Invoke(CurrentShield);
            }
        }

        public void HealHealth(int heal)
        {
            CurrentHealth = Mathf.Min(CurrentHealth + heal, MaxHealth);
        }

        public void AddShield(int shield)
        {
            CurrentShield += shield;
        }
    }
}