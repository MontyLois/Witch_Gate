using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Gameplay.Explo.Phase;
using WitchGate.Mission;

namespace WitchGate.Gameplay.Explo.Map
{
    public class MapSelection : MonoBehaviour
    {
        [field: SerializeField]
        public Location Location { get; private set; }
        [field: SerializeField]
        public bool isLocked { get; private set; }

        public async Awaitable OnMapSelected()
        {
            await SceneController.Instance.LoadGameModeAndLocation(Location, GameMode.Exploration);
        }


        public void OnSelection()
        {
            if (!isLocked)
            {
                GameController.ChangeLocation(Location);
                ExplorationGameplayController.StartPhase(Location);
                SceneController.Instance.LoadLocation(Location);
                SceneController.Instance.LoadGameMode(GameMode.Exploration);
            }
        }
    }
}