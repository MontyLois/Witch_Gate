using System;
using UnityEngine;
using WitchGate.ScenesManagement;

namespace WitchGate.Menu
{
    public class MenuManager : MonoBehaviour
    {
        public void Start()
        {
            Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
        }

        public void StartGame()
        {
            SceneController.Instance.LoadGameMode(GameMode.VisualNovel);
            SceneController.Instance.LoadLocation(Location.Shop);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void MainMenu()
        {
            SceneController.Instance.LoadGameMode(GameMode.None);
            SceneController.Instance.LoadLocation(Location.Default);
        }
    }
}
