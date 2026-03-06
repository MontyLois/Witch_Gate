using Helteix.Singletons.MonoSingletons;

namespace WitchGate.Mission
{
    public class GameState : MonoSingleton<GameState>
    {
        public int CurrentDay { get; private set; }
        public EncounterContext CurrentContext  { get; private set; }
    }
}