using System;
using cherrydev;
using UnityEngine;
using WitchGate.Mission;
using WitchGate.Mission.Dialogs;
using WitchGate.Mission.Plannings;

namespace WitchGate.Controllers
{
    public static class GameController
    {
        public static GameMetrics Metrics => GameMetrics.Current;
        public static GameDatabase GameDatabase { get; private set; }
        
        
        [Header("GameState")]
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
            Investigation = new Investigation();
            CurrentDay = 1;
            
            PlanningController.Load();
            DialogsController.Load();
        }
        
        
        public static void ChangeDay()
        {
            CurrentDay++;
            DayChanged?.Invoke(CurrentDay);
        }
        
        public static void ChangeContext(EncounterContext encounterContext)
        {
            CurrentContext = encounterContext;
        }

        public static void ProgressInvestigation()
        {
            Investigation.Progress();
            InvestigationChanged?.Invoke(Investigation.CurrentStage);
        }
      
    }
}