using WitchGate.Controllers;
using WitchGate.Gameplay.Entities;
using WitchGate.Profiles.Data;

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