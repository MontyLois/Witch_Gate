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
        private SceneData mainScene;
        private SceneData currentLocationScene;
        private List<SceneData> additiveScenes;
        private MissionData loadedMissionScene; //For Mission
        
        //Data of all GameModeLayout for each GameMode
        private static Dictionary<GameMode, GameModeLayoutData> gameModeLayouts; 
        private GameMode currentgameMode;
        
        //Data of all LocationLayout for each Location
        private static Dictionary<Location, LocationLayoutData> locationLayouts; 
        private Location currentLocation;

        public event Action<Location> OnGameLocationChanged;
        
        private void Start()
        {
            additiveScenes = new List<SceneData>();
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

        public async Awaitable LoadGameMode(GameMode gameMode)
        {
            if (gameModeLayouts.TryGetValue(gameMode, out var gameModeLayout))
            {
                if (currentgameMode == gameModeLayout.Mode)
                    return;
                currentgameMode = gameModeLayout.Mode;

                //load transition scene
                await SceneManager.LoadSceneAsync(gameModeLayout.TransitionScene.scenePath, LoadSceneMode.Additive);

                //Unload last scene
                if (mainScene != null)
                    await SceneManager.UnloadSceneAsync(mainScene.scenePath);

                // Load next main scene
                await SceneManager.LoadSceneAsync(gameModeLayout.MainScene.scenePath, LoadSceneMode.Single);
                mainScene = gameModeLayout.MainScene;

                //load additive scenes
                await LoadAdditiveScenes(gameModeLayout);

                //Unload the transition
                await SceneManager.UnloadSceneAsync(gameModeLayout.TransitionScene.scenePath);
            }
        }

        private async Awaitable UnloadAdditiveScenes()
        {
            foreach (var scene in additiveScenes)
            {
                await SceneManager.UnloadSceneAsync(scene.scenePath);
            }
            additiveScenes.Clear();
        }
        
        private async Awaitable LoadAdditiveScenes(GameModeLayoutData gameModeLayoutData)
        {
            await UnloadAdditiveScenes();
            foreach (var sceneData in gameModeLayoutData.AdditiveScenes)
            {
                if (!additiveScenes.Contains(sceneData))
                {
                    await SceneManager.LoadSceneAsync(sceneData.scenePath, LoadSceneMode.Additive);
                    TryAddScene(sceneData);
                }
            }
        }

        public async Awaitable LoadLocation(Location location)
        {
            if (location == currentLocation)
                return;
            
            if (locationLayouts.TryGetValue(location, out var locationLayout))
            {
                currentLocation = location;
                await  SceneManager.UnloadSceneAsync(currentLocationScene.scenePath);
            
                // Load next main scene
                await SceneManager.LoadSceneAsync(locationLayout.LocationScene.scenePath, LoadSceneMode.Additive);
                currentLocationScene = locationLayout.LocationScene;
            
                if (loadedMissionScene.SceneLocation == location)
                    await LoadMissionScene();
            }
        }
        

        private async Awaitable LoadMissionScene()
        {
            if (loadedMissionScene.SceneLocation == currentLocation)
            {
                await SceneManager.LoadSceneAsync(loadedMissionScene.MissionScene.scenePath, LoadSceneMode.Additive);
            }
        }
        
        public async Awaitable AddMissionScene(MissionData missionData)
        {
            if (loadedMissionScene)
            {
                RemoveMissionScene(loadedMissionScene);
                await LoadMissionScene();
                loadedMissionScene = missionData;
            }
        }
        
        public void RemoveMissionScene(MissionData missionData)
        {
            if (loadedMissionScene == missionData)
            {
                SceneManager.UnloadSceneAsync(loadedMissionScene.MissionScene.scenePath);
                loadedMissionScene = null;
            }
        }
        
        public bool TryAddScene(SceneData data)
        {
            if (additiveScenes.Contains(data))
                return false;

            additiveScenes.Add(data);
            return true;
        }

    }
    
}