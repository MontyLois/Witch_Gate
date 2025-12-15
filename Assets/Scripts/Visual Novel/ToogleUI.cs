using UnityEngine;

namespace WitchGate.Prototype
{
    public class ToogleUI : MonoBehaviour
    {
        [field: SerializeField] public GameObject UI { get; private set; }
        private bool IsDeckVisible;
        
        public void Toogle()
        {
            UI.SetActive(!IsDeckVisible);
            IsDeckVisible = !IsDeckVisible;
        }
    }
}