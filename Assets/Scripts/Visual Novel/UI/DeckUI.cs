using UnityEngine;

namespace WitchGate.VisualNovel.Visual_Novel.UI
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
