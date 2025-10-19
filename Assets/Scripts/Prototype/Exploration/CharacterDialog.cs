using System;
using cherrydev;
using UnityEngine;

namespace WitchGate.Prototype
{
    public class CharacterDialog : MonoBehaviour
    {
        
        [SerializeField] private DialogBehaviour _dialogBehaviour;
        [SerializeField] private DialogNodeGraph _dialogGraph;

        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialog();
            }
        }

        private void StartDialog()
        {
            _dialogBehaviour.StartDialog(_dialogGraph);
        }
    }
}
