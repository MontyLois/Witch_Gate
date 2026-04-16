using System;
using cherrydev;
using UnityEngine;

namespace WitchGate.Prototype
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
