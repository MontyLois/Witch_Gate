using UnityEngine;

namespace WitchGate.Controllers
{
    public static class GameController
    {
        public static GameMetrics Metrics => GameMetrics.Current;
        public static GameDatabase GameDatabase { get; private set; }

        
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