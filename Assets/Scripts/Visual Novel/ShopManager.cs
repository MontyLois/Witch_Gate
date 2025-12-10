using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using WitchGate.Controllers;
using Helteix.Singletons.MonoSingletons;

namespace WitchGate.Prototype
{
    public class ShopManager : MonoBehaviour
    {
        
        [field: SerializeField]
        public GameObject Map_UI { get; private set; }
        
        [field: SerializeField]
        public SceneData SceneData { get; private set; }

        private void Start()
        {
            SceneController.Instance.currentGameModeScene = SceneData;
        }

        public void EndDay()
        {
            ShowMap();
            //StartCoroutine(WaitToSwapScene());
        }
        
        private void OnTriggerEnter(Collider other)
        {
           // StartCoroutine(WaitToSwapScene());
        }


        private void ShowMap()
        {
            Map_UI.SetActive(true);
        }

        private IEnumerator WaitToSwapScene()
        {
            yield return new WaitForSeconds(1); ;
            SceneManager.LoadScene("Night_Exploration");
        }
    }
}
