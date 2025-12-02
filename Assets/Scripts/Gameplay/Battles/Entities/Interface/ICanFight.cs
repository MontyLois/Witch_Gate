namespace WitchGate.Gameplay.Battles.Entities.Interface
{
    public interface ICanFight
    {
        void TakeDamages(int damages);
        void HealHealth(int heal);
        void AddShield(int shield);
    }
}