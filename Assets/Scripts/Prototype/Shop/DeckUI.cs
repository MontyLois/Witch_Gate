using UnityEngine;
using UnityEngine.EventSystems;

namespace WitchGate.Prototype
{
    public class DeckUI : MonoBehaviour
    {

        private bool IsDeckVisible;
        [field: SerializeField] public GameObject Deck { get; private set; }
        
        public void Click()
        {
            Deck.SetActive(!IsDeckVisible);
            IsDeckVisible = !IsDeckVisible;
        }
    }
}
