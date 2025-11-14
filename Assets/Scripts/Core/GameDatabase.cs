using WitchGate.Controllers;
using UnityEngine;
using WitchGate.Controllers.LocationLayouts;

namespace WitchGate
{
    public class GameDatabase
    {
        public GameModeLayoutData[] GameModeLayouts { get; private set; }
        public LocationLayoutData[] LocationLayouts { get; private set; }
        
        public GameDatabase()
        {
            GameModeLayouts = Resources.LoadAll<GameModeLayoutData>("GameModeLayouts");
            LocationLayouts = Resources.LoadAll<LocationLayoutData>("LocationLayouts");
        }
    }
}