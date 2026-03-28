using WitchGate.Controllers;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Gameplay.Entities;

namespace WitchGate.Gameplay.Battles
{
    public static class BattleController
    {
        public static BattlePhase phase = null;
        
        public static void StartBattle(BattleProfile profile)
        {
            phase = new BattlePhase(new BattleEnemy(profile));
            phase.Run();
        }
    }
}