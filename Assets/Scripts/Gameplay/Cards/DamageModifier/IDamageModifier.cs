namespace WitchGate.Gameplay.Battles.Entities.Interface
{
    public interface IDamageModifier
    {
        int RemainingTurns { get; }
        void Modify(DamageContext context);
        bool Tick();

    }
}