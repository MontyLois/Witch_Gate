using System.Collections.Generic;
using UnityEngine;
using WitchGate.Gameplay.Battles.Entities.Interface;

namespace WitchGate.Gameplay.Cards.Effects
{
    [CreateAssetMenu(fileName = "NewDamageEffect", menuName = "WitchGate/Cards/Effects/Damage", order = 0)]
    public class DamageCardEffect : CardEffect
    {
        [field: SerializeField]
        public int Damage { get; private set; }


        protected override void ApplyEffect(ICanFight target)
        {
            Debug.Log("we are dealing damages with this card");
            target.TakeDamages(Damage);
        }
    }
}