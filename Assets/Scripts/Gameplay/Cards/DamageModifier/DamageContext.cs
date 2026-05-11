using WitchGate.Gameplay.Entities.Interface;

namespace WitchGate.Gameplay.Cards.DamageModifier
{
    public class DamageContext
    {
        public ICanFight Source;
        public ICanFight Target;
        public int Amount;
    }
}