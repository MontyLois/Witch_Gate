using System;
using System.Collections;
using System.Collections.Generic;
using cherrydev;
using UnityEngine;
using UnityEngine.SceneManagement;
using WitchGate.Controllers;
using Helteix.Singletons.MonoSingletons;
using UnityEngine.EventSystems;
using WitchGate.Prototype.Vinyles;
using WitchGate.VisualNovel.Visual_Novel.Cards.UI;

namespace WitchGate.Prototype
{
    public class ShopManager : MonoBehaviour
    {
        
        [Header("UI")]
        [field: SerializeField] public GameObject Map_UI { get; private set; }
        [field: SerializeField] public GameObject CloseButton { get; private set; }
        [field: SerializeField] public GameObject DialogueUI { get; private set; }
        [field: SerializeField] public GameObject VinylePanel { get; private set; }
        
        [Header("Card")]
        [field: SerializeField] public VNPlayedHandUI CardDropZone { get; private set; }
        [field: SerializeField] public GameObject Hand { get; private set; }
        
        [Header("Dialog")]
        [SerializeField] private DialogBehaviour dialogBehaviour;
        [SerializeField] private DialogNodeGraph[] dialogGraph;

        
        private TestimonyPhase currentTestimonyphase;
        private int currentClientIndex;

        private void Start()
        {
            currentClientIndex = 0;
            NextClient();
            Hand.SetActive(false);
            dialogBehaviour.BindExternalFunction("InteractiveChoice", ChooseVinyl);
            
        }

        public void EndDay()
        {
            ShowMap();
        }

        public void NextClient()
        {
            if(currentTestimonyphase is not null) 
                currentTestimonyphase.SetReady();
            
            if (currentClientIndex < dialogGraph.Length)
            {
                currentTestimonyphase = new TestimonyPhase(Witch.Elaris);
                currentTestimonyphase.Run();
                
                
                dialogBehaviour.StartDialog(dialogGraph[currentClientIndex]);
                
                DialogueUI.SetActive(true);
                currentClientIndex++;
            }
            else
            {
                CardDropZone.gameObject.SetActive(false);
                DialogueUI.SetActive(false);
                ShowCloseButton();
            }
        }

        private void ShowCloseButton()
        {
            CloseButton.SetActive(true);
        }

        private void ShowMap()
        {
            Map_UI.SetActive(true);
        }

        private IEnumerator WaitToSwapScene()
        {
            yield return new WaitForSeconds(1);
            SceneController.Instance.LoadGameMode(GameMode.Exploration);
        }

        public void SelectMusic(Vinyle vinyle)
        {
            dialogBehaviour.SetVariableValue("interactiveChoiceValue",vinyle.VinyleNumber);
            ToogleVinylPanel();
            dialogBehaviour.NextNode();
        }

        public void ChooseVinyl()
        {
            ToogleVinylPanel();
        }

        public void ToogleVinylPanel()
        {
            VinylePanel.SetActive(!VinylePanel.activeSelf);
            DialogueUI.SetActive(!VinylePanel.activeSelf);
        }
        
    }
}
