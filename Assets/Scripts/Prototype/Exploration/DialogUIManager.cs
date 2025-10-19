using UnityEngine;

namespace WitchGate.Prototype
{
    public class DialogUIManager : MonoBehaviour
    {
        
        [field: SerializeField]
        public GameObject DialogUI { get; private set; }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public void ShowDialog()
        {
            DialogUI.SetActive(true);
        }
        public void HideDialog()
        {
            DialogUI.SetActive(false);
        }
    }
}
