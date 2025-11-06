using UnityEngine;

namespace WitchGate.Gameplay.Cards.Effects
{
    [CreateAssetMenu(fileName = "NewDamageEffect", menuName = "WitchGate/Cards/Effects/Damage", order = 0)]
    public class DamageCardEffect : CardEffect
    {
        [field: SerializeField]
        public int Damage { get; private set; }
    }
}