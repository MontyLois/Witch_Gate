using System;
using cherrydev;
using UnityEngine;

namespace WitchGate.Prototype
{
    public class CharacterDialog : MonoBehaviour, IInteractable
    {
        
        [SerializeField] protected DialogBehaviour _dialogBehaviour;
        [SerializeField] protected DialogNodeGraph _dialogGraph;
        [field: SerializeField] private GameObject interaction;

        private bool _playerInside = false;
        private void OnTriggerEnter(Collider other)
        {
            interaction.SetActive(true);
            _playerInside = true;
        }

        private void OnTriggerExit(Collider other)
        {
            interaction.SetActive(false);
            _playerInside = false;
        }
        
        private void Update()
        {
            if (_playerInside && Input.GetKeyDown(KeyCode.E))
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
