using System.Collections.Generic;
using UnityEngine;
using WitchGate.Gameplay.Battles.Entities.Interface;

namespace WitchGate.Gameplay.Cards.Effects
{
    [CreateAssetMenu(fileName = "NewHealEffect", menuName = "WitchGate/Cards/Effects/Heal", order = 0)]
    public class HealCardEffect : CardEffect
    {
        [field: SerializeField]
        public int Heal { get; private set; }


        protected override void ApplyEffect(ICanFight target)
        {
            target.HealHealth(Heal);
        }
    }
}