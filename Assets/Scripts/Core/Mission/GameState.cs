using System;
using Helteix.Singletons.MonoSingletons;

namespace WitchGate.Mission
{
    public class GameState : MonoSingleton<GameState>
    {
        public int CurrentDay { get; private set; }
        public EncounterContext CurrentContext  { get; private set; }
        public Investigation Investigation { get; private set; }

        public event Action<int> DayChanged;
        public event Action<int> InvestigationChanged;

        private void Start()
        {
            Investigation = new Investigation();
            CurrentDay = 1;
        }

        public void ChangeDay()
        {
            CurrentDay++;
            DayChanged?.Invoke(CurrentDay);
        }

        public void ProgressInvestigation()
        {
            Investigation.Progress();
            InvestigationChanged?.Invoke(Investigation.CurrentStage);
            
        }
    }
}