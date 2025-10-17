using UnityEngine;

namespace WitchGate.Gameplay.Cards.Effects
{
    [CreateAssetMenu(fileName = "NewHealEffect", menuName = "WitchGate/Cards/Effects/Heal", order = 0)]
    public class HealCardEffect : CardEffect
    {
        [field: SerializeField]
        public int Heal { get; private set; }
    }
}