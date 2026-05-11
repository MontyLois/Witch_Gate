using cherrydev;
using UnityEngine;

namespace WitchGate.Gameplay.Explo.NightEvent
{
    public class CharacterDialog : MonoBehaviour, IInteractable
    {
        
        [SerializeField] protected DialogBehaviour _dialogBehaviour;
        [SerializeField] protected DialogNodeGraph _dialogGraph;

        private void StartDialog()
        {
            _dialogBehaviour.StartDialog(_dialogGraph);
        }

        public void Interact()
        {
            StartDialog();
        }
    }
}
