namespace WitchGate.Gameplay.Battles.Entities.Interface
{
    public interface ICanFight
    {
        Faction Faction { get;}
        void TakeDamages(int damages);
        void HealHealth(int heal);
        void AddShield(int shield);
    }
}