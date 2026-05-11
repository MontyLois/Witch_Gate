using UnityEditor;
using UnityEngine;

namespace WitchGate.ScenesManagement.Scenes
{
        [CreateAssetMenu(fileName = "NewScene", menuName = "WitchGate/SceneManagement/Scene", order = 0)]
        public class SceneData : ScriptableObject
        {
#if UNITY_EDITOR
                [SerializeField] private SceneAsset sceneAsset;
#endif

                [field: SerializeField, HideInInspector]
                public string ScenePath { get; private set; }

#if UNITY_EDITOR
                private void OnValidate()
                {
                        ScenePath = AssetDatabase.GetAssetPath(sceneAsset);
                }
#endif
        }
}