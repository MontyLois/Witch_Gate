using UnityEngine;

namespace WitchGate.Prototype
{
    public class Track : MonoBehaviour
    {
        [field: SerializeField] private GameObject vfx;
        [field: SerializeField] private GameObject interaction;
        [field: SerializeField] private GameObject nextTrackStep;
        
        
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
                vfx.SetActive(true);
                ActivateNextTrackStep();
            }
        }

        private void ActivateNextTrackStep()
        {
            if(nextTrackStep)
                nextTrackStep.SetActive(true);
        }
    }
}