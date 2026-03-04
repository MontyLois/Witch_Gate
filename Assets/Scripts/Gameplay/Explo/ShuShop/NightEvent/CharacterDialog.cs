using System;
using cherrydev;
using UnityEngine;

namespace WitchGate.Prototype
{
    public class CharacterDialog : MonoBehaviour
    {
        
        [SerializeField] protected DialogBehaviour _dialogBehaviour;
        [SerializeField] protected DialogNodeGraph _dialogGraph;
        [field: SerializeField] private GameObject interaction;

        private void OnTriggerEnter(Collider other)
        {
            interaction.SetActive(true);
        }

        private void OnTriggerExit(Collider other)
        {
            interaction.SetActive(false);
        }

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
