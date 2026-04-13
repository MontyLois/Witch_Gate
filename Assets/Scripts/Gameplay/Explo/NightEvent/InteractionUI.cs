using UnityEngine;
using WitchGate.Gameplay.Controller;
using WitchGate.Gameplay.Controller.Component;

namespace WitchGate.Prototype
{
    public class InteractionUI : PlayerComponent
    {
        [field: SerializeField] private GameObject interaction;
        private PlayerInteractionListener interactionListener = new();
        
        private void OnEnable()
        {
            interactionListener.Bind(Manager.Body, OnInteraction);
        }

        private void OnDisable()
        {
            interactionListener.Unbind(Manager.Body, OnInteraction);
        }

        private void OnInteraction(bool isinteractable)
        {
            interaction.SetActive(isinteractable);
        }
    }
}