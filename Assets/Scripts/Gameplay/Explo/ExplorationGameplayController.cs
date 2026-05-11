using WitchGate.Controllers;
using WitchGate.Gameplay.Explo.Phase;

namespace WitchGate.Gameplay.Explo
{
    public static class ExplorationGameplayController
    {
        public static ExplorationPhase phase = null;
        
        public static void StartPhase(Location location)
        {
            phase = new ExplorationPhase(location);
            phase.Run();
        }

        public static void RestartPhase()
        {
            Location lastLocation;
            if (phase is null)
                lastLocation = Location.City_1;
            else
            {
                lastLocation = phase.Location;
                phase.SetReady();
            }
            phase = new ExplorationPhase(lastLocation);
            phase.Run();
        }
    }
}