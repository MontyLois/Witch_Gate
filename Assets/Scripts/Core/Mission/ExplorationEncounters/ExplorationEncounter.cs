using cherrydev;
using WitchGate.Controllers;
using WitchGate.Mission.ExplorationEncounters.Data;
using WitchGate.ScenesManagement.Scenes;

namespace WitchGate.Mission.ExplorationEncounters
{
    public class ExplorationEncounter
    {
        public ExplorationEncounterContextualizedData explorationEncounter { get; private set; }
        public EncounterContext lastEncounterContext{ get; private set; }

        public ExplorationEncounter(ExplorationEncounterContextualizedData explorationEncounterContextualizedData)
        {
            this.explorationEncounter = explorationEncounterContextualizedData;
        }

        public void SetLastEncounterContext(EncounterContext encounterContext)
        {
            lastEncounterContext = encounterContext;
        }

        /**
         * Check context base on current Game State and character
         */
        public bool CheckContext(CharacterData characterData, Location location)
        {
            if (characterData == explorationEncounter.CharacterData
                && CheckContext(location))
            {
                return true;
            }
            return false;
        }
        
        /**
         * Check context base on current Game State (stage and location)
         */
        public bool CheckContext(Location location)
        {
            if (location == explorationEncounter.Location
                && GameController.Investigation.CurrentStage == explorationEncounter.InvestigationStage)
                return true;
            return false;
        }

        public SceneData GetEncounterScene()
        {
            return explorationEncounter.EncounterScene;
        }

    }
}