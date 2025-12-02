namespace WitchGate.Gameplay.Battles.Entities
{
    public class BattleEnemy : BattleEntity, IBattleEnemy
    {
        public BattleEnemy(int maxHealth) : base(maxHealth, maxHealth)
        {
            
        }
    }
}