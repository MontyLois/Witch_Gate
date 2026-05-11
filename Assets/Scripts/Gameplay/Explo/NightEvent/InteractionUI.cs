using UnityEngine;
using WitchGate.Gameplay.Explo.Controller.Component;
using WitchGate.Gameplay.Explo.Controller.Component.Helpers;

namespace WitchGate.Gameplay.Explo.NightEvent
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