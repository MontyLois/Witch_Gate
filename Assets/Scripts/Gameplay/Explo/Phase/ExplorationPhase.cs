using System.Collections.Generic;
using cherrydev;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Mission;

namespace WitchGate.Gameplay.Explo.Phase
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
            await GetAllEncounter();
        }

        public async Awaitable Execute()
        {
            while (!IsReady)
                await Awaitable.NextFrameAsync();
        }

        public async Awaitable OnEnd()
        {
            await ClearAllEncounter();
        }

        private async Awaitable GetAllEncounter()
        {
            List<ExplorationEncounter> explorationEncounters =
                ExplorationEncounterController.GetAllCurrentExplorationEncounter(Location);
            Debug.Log("nb of encounters : "+explorationEncounters.Count);
            foreach (var explorationEncounter in explorationEncounters)
            {
                ExplorationEncounters.Add(explorationEncounter.explorationEncounter.CharacterData, explorationEncounter);
                await SceneController.Instance.TryAddMEncounterScene(explorationEncounter.explorationEncounter);
            }
        }

        private async Awaitable ClearAllEncounter()
        {
            foreach (var explorationEncounter in ExplorationEncounters)
            {
                await SceneController.Instance.RemoveEncounterScene(explorationEncounter.Value.explorationEncounter);
            }
            ExplorationEncounters.Clear();
        }

        private async Awaitable ValidateEncounterForCharacter(CharacterData characterData)
        {
            if (ExplorationEncounters.ContainsKey(characterData))
            {
                await SceneController.Instance.RemoveEncounterScene(ExplorationEncounters[characterData].explorationEncounter);
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
        public async Awaitable ReturnToTheShopAndSkipToNextDay()
        {
            GameController.ChangeContext(EncounterContext.FromCityToVinylShop);
            await SceneController.Instance.UnloadLocationScene();
            await SceneController.Instance.LoadGameMode(GameMode.VisualNovel);
            GameController.ChangeDay();
            SetReady();
        }
    }
}