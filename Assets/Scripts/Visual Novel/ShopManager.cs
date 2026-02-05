using System;
using System.Collections;
using System.Collections.Generic;
using cherrydev;
using UnityEngine;
using UnityEngine.SceneManagement;
using WitchGate.Controllers;
using Helteix.Singletons.MonoSingletons;
using WitchGate.VisualNovel.Visual_Novel.Cards.UI;

namespace WitchGate.Prototype
{
    public class ShopManager : MonoBehaviour
    {
        
        [field: SerializeField] public GameObject Map_UI { get; private set; }
        [field: SerializeField] public GameObject CloseButton { get; private set; }
        [field: SerializeField] public GameObject DialogueUI { get; private set; }
        
        [field: SerializeField] public VNPlayedHandUI CardDropZone { get; private set; }
        
        [field: SerializeField] public GameObject Hand { get; private set; }
        
        [field: SerializeField] public SceneData SceneData { get; private set; }
        
        [SerializeField] private DialogBehaviour dialogBehaviour;
        [SerializeField] private DialogNodeGraph[] dialogGraph;

        private TestimonyPhase currentTestimonyphase;

        private int currentClientIndex;

        private void Start()
        {
            //SceneController.Instance.currentGameModeScene = SceneData;
            currentClientIndex = 0;
            NextClient();
            Hand.SetActive(false);
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
                Debug.Log("we should have started a dialog");
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
        private void OnTriggerEnter(Collider other)
        {
           // StartCoroutine(WaitToSwapScene());
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
            //SceneManager.LoadScene("Night_Exploration");
        }

        public void DebugAlacon()
        {
            Debug.Log("feur");
        }
    }
}
