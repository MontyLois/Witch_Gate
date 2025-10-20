using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using WitchGate.Gameplay;

namespace WitchGate.Prototype
{
    public class ShopManager : MonoBehaviour
    {
        public void EndDay()
        {
            StartCoroutine(WaitToSwapScene());
        }
        
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(WaitToSwapScene());
        }
        

        private IEnumerator WaitToSwapScene()
        {
            yield return new WaitForSeconds(1); ;
            SceneManager.LoadScene("Night_Exploration");
        }
    }
}
