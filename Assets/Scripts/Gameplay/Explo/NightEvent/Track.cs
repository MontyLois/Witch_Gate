using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Playables;


namespace WitchGate.Prototype
{
    public class Track : MonoBehaviour, IInteractable
    {
        [field: SerializeField] private GameObject vfx;
        [field: SerializeField] private GameObject nextTrackStep;
        [field: SerializeField] private PlayableDirector custscene;


        private void Start()
        {
            var brain = Camera.main.GetComponent<CinemachineBrain>();

            foreach (var output in custscene.playableAsset.outputs)
            {
                if (output.streamName == "Cinemachine Track")
                {
                    custscene.SetGenericBinding(output.sourceObject, brain);
                }
            }
        }

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