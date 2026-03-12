using System;
using System.Collections;
using System.Collections.Generic;
using cherrydev;
using UnityEngine;
using UnityEngine.SceneManagement;
using WitchGate.Controllers;
using Helteix.Singletons.MonoSingletons;
using UnityEngine.EventSystems;
using WitchGate.Mission.Dialogs;
using WitchGate.Mission.Plannings;
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

        [SerializeField] private List<DialogNodeGraph> customersDialogNodeGraphs = new List<DialogNodeGraph>();
        [SerializeField] private List<CharacterData> customers = new List<CharacterData>();

        
        private TestimonyPhase currentTestimonyphase;
        private int currentClientIndex = 0;

        private void Start()
        {
            Hand.SetActive(false);
            getTodaysCustomers();
            dialogBehaviour.BindExternalFunction("InteractiveChoice", ChooseVinyl);
            NextClient();
        }

        public void EndDay()
        {
            ShowMap();
        }

        /**
         * fill the dialogs list with dialogs of all present customers (via planning controller)
         * for the vinyl shop based on current stage (via dialogs controller)
         */
        private void GetTodaysDialogs()
        {
            customersDialogNodeGraphs.Clear();
            List<CharacterData> characterDatas = PlanningController.GetAllCharacterPresent();

            foreach (var characterData in characterDatas)
            {
                var dialog = DialogsController.GetNextDialogForSpecificEntity(characterData);
                if(dialog)
                    customersDialogNodeGraphs.Add(dialog);
            }
        }

        /**
         * Get all today customers
         */
        private void getTodaysCustomers()
        {
            customers.Clear();
            GameController.ChangeContext(EncounterContext.VinylShop);
            customers.AddRange(PlanningController.GetAllCharacterPresent());
            Debug.Log("Nomber of customers today : "+customers.Count);
        }

        public void NextClient()
        {
            if(currentTestimonyphase is not null) 
                currentTestimonyphase.SetReady();
            
            /*
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
            */
            if (currentClientIndex < customers.Count)
            {
                currentTestimonyphase = new TestimonyPhase(Witch.Elaris);
                currentTestimonyphase.Run();
                Debug.Log("Current client : "+customers[currentClientIndex].displayName);
                //retrieve the current dialog for this client
                DialogNodeGraph dialogNodeGraph =
                    DialogsController.GetNextDialogForSpecificEntity(customers[currentClientIndex]);
                if (dialogNodeGraph is not null)
                {
                    dialogBehaviour.StartDialog(dialogNodeGraph);
                    DialogueUI.SetActive(true);
                }
                else
                {
                    Debug.LogError("wtf c'est null");
                }
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
