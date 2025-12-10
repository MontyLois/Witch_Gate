using System.Collections;
using UnityEngine;
using WitchGate.Controllers;
using WitchGate.Controllers.LocationLayouts;

namespace WitchGate.VisualNovel.Visual_Novel.Map
{
    public class MapSelection : MonoBehaviour
    {
        [field: SerializeField]
        public Location Location { get; private set; }
        [field: SerializeField]
        public bool isLocked { get; private set; }

        public async Awaitable OnMapSelected()
        {
            await SceneController.Instance.LoadGameMode(GameMode.Exploration);
        }


        public void OnSelection()
        {
            if (!isLocked)
            {
                SceneController.Instance.LoadGameMode(GameMode.Exploration);
            }
        }
    }
}