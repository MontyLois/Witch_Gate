using WitchGate.Gameplay.Battles.Entities.Interface;

namespace WitchGate.Gameplay.Battles.Entities
{
    public class DamageContext
    {
        public ICanFight Source;
        public ICanFight Target;
        public int Amount;
    }
}