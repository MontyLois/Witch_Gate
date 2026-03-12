using UnityEngine;

namespace WitchGate.Utilities
{
    public class ToggleElement : MonoBehaviour
    {
        [field: SerializeField] public GameObject gameObject { get; private set; }
        
        public void Toogle()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}