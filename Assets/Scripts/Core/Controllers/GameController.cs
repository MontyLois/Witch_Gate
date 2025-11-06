namespace WitchGate.Controllers
{
    public static class GameController
    {
        public static GameMetrics Metrics => GameMetrics.Current;

        public static readonly PhaseController PhaseController;

        static GameController()
        {
            PhaseController = new PhaseController();
        }
    }
}