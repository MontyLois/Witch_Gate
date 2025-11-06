using UnityEngine;
using UnityEngine.EventSystems;

namespace WitchGate.Prototype
{
    public class DeckUI : MonoBehaviour,IPointerClickHandler
    {

        private bool IsDeckVisible;
        [field: SerializeField] public GameObject Deck { get; private set; }
        
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Deck.SetActive(!IsDeckVisible);
            IsDeckVisible = !IsDeckVisible;
        }

        public void Click()
        {
            Deck.SetActive(!IsDeckVisible);
            IsDeckVisible = !IsDeckVisible;
        }
    }
}
