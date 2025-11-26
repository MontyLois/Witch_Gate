using System.Collections.Generic;
using UnityEngine;

namespace WitchGate.Controllers
{
    [CreateAssetMenu(fileName = "newGameModeLayout", menuName = "WitchGate/GameModeLayouts/GameModeLayout", order = 0)]
    public class GameModeLayoutData : ScriptableObject
    {
        [field: SerializeField] public GameMode Mode { get; private set; }

        [Header("The main environment scene for this mode")]
        [field: SerializeField] public SceneData MainScene { get; private set; }
        
        [Header("The transition to get to this mode")]
        [field: SerializeField] public SceneData TransitionScene { get; private set; }

        [Header("Secondary layers loaded additively")]
        [field: SerializeField] public SceneData[] AdditiveScenes{ get; private set; }
    }
}