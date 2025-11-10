using WitchGate.Controllers;

namespace WitchGate.Gameplay.Battles
{
    public class BattleManager
    {
        
        
        public void OnBattleStart(IBattleEnemy battleEnemy)
        {
            BattlePhase battlePhase = new BattlePhase(battleEnemy);
            battlePhase.Begin();
        }
    }
}