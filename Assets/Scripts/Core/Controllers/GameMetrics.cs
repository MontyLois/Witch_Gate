using Helteix.Tools.Settings;
using UnityEngine;

namespace WitchGate.Controllers
{
    [AutoGenerateGameSettings]
    public class GameMetrics : GameSettings<GameMetrics>
    {
        [field: SerializeField]
        public string BattleScenePath { get; private set; }
        
        [field: SerializeField, Range(1, 10)]
        public int MaxBattleHandSize { get; private set; } = 5;
    }
}