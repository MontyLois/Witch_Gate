using UnityEngine;
using WitchGate.Controllers;

namespace WitchGate
{
    public class MenuManager : MonoBehaviour
    {
        public void StartGame()
        {
            SceneController.Instance.LoadGameMode(GameMode.VisualNovel);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void MainMenu()
        {
            SceneController.Instance.LoadGameMode(GameMode.None);
        }
    }
}
