using UnityEngine;

namespace WitchGate.Prototype.Prototype.Shop
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
