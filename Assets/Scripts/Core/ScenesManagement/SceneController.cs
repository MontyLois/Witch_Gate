using System;
using System.Collections.Generic;
using Helteix.Singletons.MonoSingletons;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
using WitchGate.Controllers.LocationLayouts;

namespace WitchGate.Controllers
{
    public class SceneController : MonoSingleton<SceneController>
    {
        [field: SerializeField]
        public SceneData currentGameModeScene { get; private set; } //Loaded GameMode Scene
        [field: SerializeField]
        public SceneData currentLocationScene { get; private set; } //Loaded Location Scene
        private List<EncounterSceneData> encounterScene; //Active encounter scenes
        private List<EncounterSceneData> loadedEncounterScene; //All loaded encounter scenes
       
        //Data of all GameModeLayout for each GameMode
        private static Dictionary<GameMode, GameModeLayoutData> gameModeLayouts; 
        private GameMode currentgameMode;
        
        //Data of all LocationLayout for each Location
        private static Dictionary<Location, LocationLayoutData> locationLayouts; 
        private Location currentLocation;

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
            encounterScene = new List<EncounterSceneData>();
            loadedEncounterScene = new List<EncounterSceneData>();
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
            Debug.Log("Are we really in the same location ? Is that how it is ?");
            if (location == currentLocation)
                return;
            Debug.Log("we are changing location");
            if (locationLayouts.TryGetValue(location, out var locationLayout))
            {
                Debug.Log("we are in location "+ location);
                currentLocation = location;
                if(currentLocationScene is not null)
                    await  SceneManager.UnloadSceneAsync(currentLocationScene.ScenePath);
            
                // Load next main scene
                await SceneManager.LoadSceneAsync(locationLayout.LocationScene.ScenePath, LoadSceneMode.Additive);
                currentLocationScene = locationLayout.LocationScene;

                HandleEncounterScene();
            }
        }
        
        
        private async Awaitable HandleEncounterScene()
        {
            foreach (var scene in encounterScene)
            {
                if (scene.SceneLocation == currentLocation)
                    LoadEncounterScene(scene);
                else
                    UnloadEncounterScene(scene);
            }
        }
        

        private async Awaitable LoadEncounterScene(EncounterSceneData encounterSceneData)
        {
            if (!loadedEncounterScene.Contains(encounterSceneData))
            {
                await SceneManager.LoadSceneAsync(encounterSceneData.MissionScene.ScenePath, LoadSceneMode.Additive);
                loadedEncounterScene.Add(encounterSceneData);
            }
        }

        private async Awaitable UnloadEncounterScene(EncounterSceneData encounterSceneData)
        {
            if (loadedEncounterScene.Contains(encounterSceneData))
            {
                await SceneManager.UnloadSceneAsync(encounterSceneData.MissionScene.ScenePath);
                loadedEncounterScene.Remove(encounterSceneData);
            }
        }
        
        public async Awaitable RemoveEncounterScene(EncounterSceneData encounterSceneData)
        {
            if (encounterScene.Contains(encounterSceneData))
            {
                if (encounterSceneData.SceneLocation == currentLocation)
                    await UnloadEncounterScene(encounterSceneData);
                encounterScene.Remove(encounterSceneData);
            }
        }
        
        public bool TryAddMEncounterScene(EncounterSceneData data)
        {
            if (encounterScene.Contains(data))
                return false;
            encounterScene.Add(data);
            if (data.SceneLocation == currentLocation) 
                LoadEncounterScene(data);
            return true;
        }

        public async Awaitable UnloadLocationScene()
        {
            if(currentLocationScene is not null)
                await  SceneManager.UnloadSceneAsync(currentLocationScene.ScenePath);
            foreach (var lEncounterSceneData in loadedEncounterScene)
            {
                await UnloadEncounterScene(lEncounterSceneData);
            }
            loadedEncounterScene.Clear();
        }
    }
    
}