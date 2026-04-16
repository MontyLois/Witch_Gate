using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

namespace WitchGate.Prototype
{
    public class Track : MonoBehaviour, IInteractable
    {
        [field: SerializeField] private GameObject vfx;
        [field: SerializeField] private GameObject nextTrackStep;
        [field: SerializeField] private PlayableDirector custscene;


        private void ActivateNextTrackStep()
        {
            if(nextTrackStep)
                nextTrackStep.SetActive(true);
        }

        public void Interact()
        {
            vfx.SetActive(true);
            ActivateNextTrackStep(); 
            custscene.Play();
        }
    }
}