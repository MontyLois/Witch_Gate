using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WitchGate.Controllers
{
    [CreateAssetMenu(fileName = "NewScene", menuName = "WitchGate/Scenes/Scene", order = 0)]
    public class SceneData : ScriptableObject
    {
        [SerializeField] private SceneAsset sceneAsset;
        [SerializeField] public string scenePath { get; private set; }

        public string ScenePath => scenePath;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (sceneAsset != null)
                scenePath = AssetDatabase.GetAssetPath(sceneAsset);
        }
#endif
     }
}