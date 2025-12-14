namespace WitchGate.Gameplay.Battles.Entities.Interface
{
    public interface IDamageModifier
    {
        int RemainingTurns { get; }
        void Modify(ref DamageContext context);
        bool Tick();

    }
}