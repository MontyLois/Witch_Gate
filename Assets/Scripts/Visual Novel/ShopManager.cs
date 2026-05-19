using System.Collections.Generic;
using cherrydev;
using UnityEngine;
using WitchGate.Cards.Collections;
using WitchGate.Controllers;
using WitchGate.Mission;
using WitchGate.Mission.Dialogs;
using WitchGate.Mission.Plannings;
using WitchGate.VisualNovel.Visual_Novel.Cards.UI;
using WitchGate.VisualNovel.Visual_Novel.UI;
using WitchGate.VisualNovel.Visual_Novel.Vinyles;
using WitchGate.VisualNovel.Visual_Novel.Visions;
using VisionUI = WitchGate.VisualNovel.Visual_Novel.Visions.VisionUI;

namespace WitchGate.VisualNovel.Visual_Novel
{
    public class ShopManager : MonoBehaviour
    {
        
        [Header("UI")]
        [field: SerializeField] public GameObject Map_UI { get; private set; }
        [field: SerializeField] public GameObject CloseButton { get; private set; }
        [field: SerializeField] public GameObject DialogueUI { get; private set; }
        [field: SerializeField] public GameObject VinylePanel { get; private set; }
        [field: SerializeField] public GameObject CardUI { get; private set; }
        
        [Header("Card")]
        [field: SerializeField] public VNPlayedHandUI CardDropZone { get; private set; }
        [field: SerializeField] public GameObject Hand { get; private set; }
        
        [Header("Vision")]
        [field: SerializeField] public VisionUI Vision { get; private set; }
        
        [Header("Dialog")]
        [SerializeField] private DialogBehaviour dialogBehaviour;
        [SerializeField] private DialogNodeGraph[] dialogGraph;

        [field: SerializeField] public DialogNodeGraph NoMoreDialog { get; private set; }
        private bool endOfDay = false;
        private bool thereIsADialog = false;
        [field: SerializeField] public CharacterData SistersData {get; private set;}

        [SerializeField] private List<DialogNodeGraph> customersDialogNodeGraphs = new List<DialogNodeGraph>();
        [SerializeField] private List<CharacterData> customers = new List<CharacterData>();

        
        private TestimonyPhase currentTestimonyphase;
        private int currentClientIndex = 0;
        public CharacterData currentClientData;

        private void Start()
        {
            VisionController.Load();
            endOfDay = false;
            thereIsADialog = false;
            Hand.SetActive(true);
            getTodaysCustomers();
            dialogBehaviour.BindExternalFunction("InteractiveChoice", ChooseVinyl);
            dialogBehaviour.BindExternalFunction("NextPhase", ShowMap);
            dialogBehaviour.BindExternalFunction("ChooseCard", ToogleCardPanel);
            NextClient();
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
                var dialog = DialogsController.GetDialogForSpecificEntity(characterData);
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
        }

        public void NextClient()
        {
            if (endOfDay)
            {
                DialogsController.ValidateReadDialog();
                ShowMap();
            }
            
            if(currentTestimonyphase is not null) 
                currentTestimonyphase.SetReady();
           
            if (currentClientIndex < customers.Count)
            {
                currentTestimonyphase = new TestimonyPhase(Witch.Elaris, customers[currentClientIndex]);
                currentTestimonyphase.Run();
                
               
                
                //retrieve the current dialog for this client
                DialogNodeGraph dialogNodeGraph =
                    DialogsController.GetDialogForSpecificEntity(customers[currentClientIndex]);
                if (dialogNodeGraph is not null)
                {
                    Debug.Log("Who is the current customer ? "+customers[currentClientIndex]);
                    currentClientData = customers[currentClientIndex];
                    thereIsADialog = true;
                    dialogBehaviour.StartDialog(dialogNodeGraph);
                    DialogueUI.SetActive(true);
                }
                else
                {
                    currentClientIndex++;
                    NextClient();
                    return;
                }
                currentClientIndex++;
            }
            else
            {
                if (!endOfDay)
                {
                    endOfDay = true;
                    EndDay();
                }
            }
        }
        
        public void EndDay()
        {
            CardDropZone.gameObject.SetActive(false);
            if (!thereIsADialog)
            {
                dialogBehaviour.StartDialog(NoMoreDialog);
            }
            else
            {
                GameController.ChangeContext(EncounterContext.FromVinylShopToCity);
                DialogNodeGraph dialogNodeGraph =
                    DialogsController.GetDialogForSpecificEntity(SistersData);
                if (dialogNodeGraph is not null)
                {
                    dialogBehaviour.StartDialog(DialogsController.GetDialogForSpecificEntity(SistersData));
                }
                else
                {
                    ShowMap();
                }
            }
        }
        
        private void ShowCloseButton()
        {
            CloseButton.SetActive(true);
        }

        private void ShowMap()
        {
            DialogueUI.SetActive(false);
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

        public void ClickDebug()
        {
            Debug.Log("Click Debug");
        }

        public void ToogleCardPanel()
        {
            CardUI.SetActive(!CardUI.activeSelf);
            DialogueUI.SetActive(!CardUI.activeSelf);
        }
        
        public void ShowVision(int ct)
        {
            CardType cardType = (CardType)ct;
            Debug.Log(currentClientData);
            if (currentClientData is not null)
            {
                Vision.ShowVision(VisionController.GetVisionForSpecificEntity(currentClientData, cardType));
            }
            ToogleCardPanel();
            dialogBehaviour.NextNode();
        }
        
    }
}
