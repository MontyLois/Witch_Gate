using UnityEngine;

namespace WitchGate.Prototype
{
    public class ToogleUI : MonoBehaviour
    {
        [field: SerializeField] public GameObject UI { get; private set; }
        private bool IsVisible;
        
        public void Toogle()
        {
            UI.SetActive(!IsVisible);
            IsVisible = !IsVisible;
        }
    }
}