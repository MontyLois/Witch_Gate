using System.Collections.Generic;
using cherrydev;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Mission;

namespace WitchGate.Gameplay.Phase
{
    public class ExplorationPhase : IPhase
    {
        public bool IsReady { get; private set; }

        public Dictionary<CharacterData, ExplorationEncounter> ExplorationEncounters;
        public Location Location { get; private set; }

        public ExplorationPhase(Location location)
        {
            ExplorationEncounters = new Dictionary<CharacterData, ExplorationEncounter>();
            Location = location;
        }
        
        public async Awaitable OnBegin()
        {
            IsReady = false;
        }

        public async Awaitable Execute()
        {
            while (!IsReady)
                await Awaitable.NextFrameAsync();
        }

        public async Awaitable OnEnd()
        {
            
        }

        private void GetAllEncounter()
        {
            List<ExplorationEncounter> explorationEncounters =
                ExplorationEncounterController.GetAllCurrentExplorationEncounter(Location);
            foreach (var explorationEncounter in explorationEncounters)
            {
                ExplorationEncounters.Add(explorationEncounter.explorationEncounter.CharacterData, explorationEncounter);
            }
        }

        private void ValidateEncounterForCharacter(CharacterData characterData)
        {
            if (ExplorationEncounters.ContainsKey(characterData))
            {
                ExplorationEncounters.Remove(characterData);
            }
        }

        //For defeat behavior
        public void ResetPhase()
        {
            SetReady();
        }
        
        public void SetReady()
        {
            IsReady = true;
        }

        /*
         * End the exploration phase, get to next day and yay
         */
        public void ReturnToTheShopAndSkipToNextDay()
        {
            GameController.ChangeContext(EncounterContext.FromCityToVinylShop);
            GameController.ChangeDay();
            SetReady();
        }
    }
}