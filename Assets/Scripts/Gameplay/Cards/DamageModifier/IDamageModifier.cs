namespace WitchGate.Gameplay.Battles.Entities.Interface
{
    public interface IDamageModifier
    {
        int RemainingTurns { get; set; }
        void Modify(ref DamageContext context);

        bool Tick()
        {
            RemainingTurns--;
            return RemainingTurns <= 0;
        }

    }
}