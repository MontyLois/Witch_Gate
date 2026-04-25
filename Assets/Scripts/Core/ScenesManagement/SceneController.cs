using System;
using System.Collections.Generic;
using Helteix.Singletons.MonoSingletons;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
using WitchGate.Controllers.LocationLayouts;
using WitchGate.Mission.Data;

namespace WitchGate.Controllers
{
    public class SceneController : MonoSingleton<SceneController>
    {
        [field: SerializeField]
        public SceneData currentGameModeScene { get; private set; } //Loaded GameMode Scene
        [field: SerializeField]
        public SceneData currentLocationScene { get; private set; } //Loaded Location Scene
        
        private List<ExplorationEncounterContextualizedData> encounterScene; //Active encounter scenes
        private List<ExplorationEncounterContextualizedData> loadedEncounterScene; //All loaded encounter scenes
        
        private List<SceneData> encounterExplorationScenes; //Active encounter scenes
       
        //Data of all GameModeLayout for each GameMode
        private static Dictionary<GameMode, GameModeLayoutData> gameModeLayouts; 
        private GameMode currentgameMode;
        
        //Data of all LocationLayout for each Location
        private static Dictionary<Location, LocationLayoutData> locationLayouts; 
        public Location currentLocation{ get; private set; }
        public Location lastLocation { get; private set; }

        public event Action<Location> OnGameLocationChanged;
        
        private void Start()
        {
            LoadGameModeLayouts();
            LoadLocationLayouts();
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            gameModeLayouts = new Dictionary<GameMode, GameModeLayoutData>();
            locationLayouts = new Dictionary<Location, LocationLayoutData>();
            encounterScene = new List<ExplorationEncounterContextualizedData>();
            loadedEncounterScene = new List<ExplorationEncounterContextualizedData>();
            LoadGameModeLayouts();
            LoadLocationLayouts();
        }

        private void LoadGameModeLayouts()
        {
            GameModeLayoutData[] loadedGameModeLayouts = GameController.GameDatabase.GameModeLayouts;
            foreach (var gameModeLayout in loadedGameModeLayouts)
            {
                gameModeLayouts[gameModeLayout.Mode] = gameModeLayout;
            }
        }
        
        private void LoadLocationLayouts()
        {
            LocationLayoutData[] loadedLocationLayouts = GameController.GameDatabase.LocationLayouts;
            foreach (var locationLayout in loadedLocationLayouts)
            {
                locationLayouts[locationLayout.Location] = locationLayout;
            }
        }

        public Awaitable LoadGameMode(GameMode gameMode) => LoadGameModeAsync(gameMode);

        public async Awaitable LoadGameModeAsync(GameMode gameMode)
        {
            if (gameModeLayouts.TryGetValue(gameMode, out var gameModeLayout))
            {
                if (currentgameMode == gameModeLayout.Mode)
                    return;
                currentgameMode = gameModeLayout.Mode;

                //load transition scene
                await SceneManager.LoadSceneAsync(gameModeLayout.TransitionScene.ScenePath, LoadSceneMode.Additive);

                Debug.Log(currentGameModeScene.name);
                //Unload last game mode scene
                if (currentGameModeScene is not null)
                    await SceneManager.UnloadSceneAsync(currentGameModeScene.ScenePath);

                // Load next main scene
                var operation = SceneManager.LoadSceneAsync(gameModeLayout.MainScene.ScenePath, LoadSceneMode.Additive);
                await operation;

                Scene mainScene = SceneManager.GetSceneByPath(gameModeLayout.MainScene.ScenePath);
                SceneManager.SetActiveScene(mainScene);
                
                currentGameModeScene = gameModeLayout.MainScene;

                //Unload the transition
                await SceneManager.UnloadSceneAsync(gameModeLayout.TransitionScene.ScenePath);
                
            }
        }
        

        public async Awaitable LoadGameModeAndLocation(Location location, GameMode gameMode)
        {
            await LoadLocation(location);
            await LoadGameMode(gameMode);
        }

        public async Awaitable LoadLocation(Location location)
        {
            /*Debug.Log("Are we really in the same location ? Is that how it is ?");
            if (location == currentLocation)
                return;
            Debug.Log("we are changing location");*/
            lastLocation = currentLocation;
            currentLocation = location;
            if (locationLayouts.TryGetValue(location, out var locationLayout))
            {
                Debug.Log("we are in location "+ location);
                if(currentLocationScene is not null)
                    await  SceneManager.UnloadSceneAsync(currentLocationScene.ScenePath);
            
                // Load next main scene
                await SceneManager.LoadSceneAsync(locationLayout.LocationScene.ScenePath, LoadSceneMode.Additive);
                currentLocationScene = locationLayout.LocationScene;

                HandleEncounterScene();
            }
        }
        
        public async Awaitable UnloadLocationScene()
        {
            if(currentLocationScene is not null)
                await  SceneManager.UnloadSceneAsync(currentLocationScene.ScenePath);
            using (ListPool<ExplorationEncounterContextualizedData>.Get(out List<ExplorationEncounterContextualizedData> encounters))
            {
                encounters.AddRange(loadedEncounterScene);
                foreach (var encounter in encounters)
                    await UnloadEncounterScene(encounter);
            }
            loadedEncounterScene.Clear();
        }
        
        
        private async Awaitable HandleEncounterScene()
        {
            foreach (var scene in encounterScene)
            {
                if (scene.Location == currentLocation)
                    LoadEncounterScene(scene);
                else
                    UnloadEncounterScene(scene);
            }
        }
        

        private async Awaitable LoadEncounterScene(ExplorationEncounterContextualizedData encounterSceneData)
        {
            if (!loadedEncounterScene.Contains(encounterSceneData))
            {
                await SceneManager.LoadSceneAsync(encounterSceneData.EncounterScene.ScenePath, LoadSceneMode.Additive);
                loadedEncounterScene.Add(encounterSceneData);
            }
        }

        private async Awaitable UnloadEncounterScene(ExplorationEncounterContextualizedData encounterSceneData)
        {
            if (loadedEncounterScene.Contains(encounterSceneData))
            {
                await SceneManager.UnloadSceneAsync(encounterSceneData.EncounterScene.ScenePath);
                loadedEncounterScene.Remove(encounterSceneData);
            }
        }
        
        public async Awaitable RemoveEncounterScene(ExplorationEncounterContextualizedData encounterSceneData)
        {
            if (encounterScene.Contains(encounterSceneData))
            {
                if (encounterSceneData.Location == currentLocation)
                    await UnloadEncounterScene(encounterSceneData);
                encounterScene.Remove(encounterSceneData);
            }
        }
        
        public async Awaitable TryAddMEncounterScene(ExplorationEncounterContextualizedData data)
        {
            if (encounterScene.Contains(data))
                return;
            encounterScene.Add(data);
            if (data.Location == currentLocation) 
                await LoadEncounterScene(data);
        }
    }
}