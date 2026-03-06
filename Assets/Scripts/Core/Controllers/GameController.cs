using System;
using UnityEngine;
using WitchGate.Mission;

namespace WitchGate.Controllers
{
    public static class GameController
    {
        public static GameMetrics Metrics => GameMetrics.Current;
        public static GameDatabase GameDatabase { get; private set; }
        
        
        
        public static int CurrentDay { get; private set; }
        public static EncounterContext CurrentContext  { get; private set; }
        public static Investigation Investigation { get; private set; }

        public static event Action<int> DayChanged;
        public static event Action<int> InvestigationChanged;

        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Load()
        {
            //generate the database
            GameDatabase = new GameDatabase();
        }
        
        static GameController()
        {
            
        }
    }
}