using UnityEngine;

namespace WitchGate.Prototype
{
    public class Track : MonoBehaviour, IInteractable
    {
        [field: SerializeField] private GameObject vfx;
        [field: SerializeField] private GameObject nextTrackStep;
        

        private void ActivateNextTrackStep()
        {
            if(nextTrackStep)
                nextTrackStep.SetActive(true);
        }

        public void Interact()
        {
            vfx.SetActive(true);
            ActivateNextTrackStep();
        }
    }
}