using System;
using System.Collections.Generic;
using cherrydev;
using WitchGate.Controllers;
using WitchGate.Mission.Data;

namespace WitchGate.Mission
{
    public static class ExplorationEncounterController
    {
        
        private static List<ExplorationEncounter> explorationEncountersList = new List<ExplorationEncounter>();
        
        public static void Load()
        {
            ExplorationEncounterContextualizedData[] explorationEncounters = GameController.GameDatabase.ExplorationEncounterContextualizedDatas;
            foreach (var explorationEncounter in explorationEncounters)
            {
                explorationEncountersList.Add(new ExplorationEncounter(explorationEncounter));
            }
        }

        public static SceneData GetEncounterSceneForSpecificCharacter(CharacterData characterData, Location location)
        {
            foreach (var exploration in explorationEncountersList)
            {
                if (exploration.CheckContext(characterData,location))
                {
                    return exploration.GetEncounterScene();
                }
            }
            return null;
        }

        public static List<ExplorationEncounter> GetAllCurrentExplorationEncounter(Location location)
        {
            List<ExplorationEncounter> explorationEncounters = new List<ExplorationEncounter>();
            foreach (var exploration in explorationEncountersList)
            {
                if (exploration.CheckContext(location))
                {
                    explorationEncounters.Add(exploration);
                }
            }
            return explorationEncounters;
        }
    }
}