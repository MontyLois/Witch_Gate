using UnityEngine;

namespace WitchGate.VisualNovel.Visual_Novel
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