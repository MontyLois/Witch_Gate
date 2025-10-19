using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using WitchGate.Gameplay;
using WitchGate.Gameplay.Controller;

namespace WitchGate.Prototype
{
    public class Monster : MonoBehaviour
    {
        [field: SerializeField]
        private GameObject sprite;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("ho");
            sprite.SetActive(true);
            ExplorationGameplayManager.Instance.LockPlayerMovement();
            StartCoroutine(WaitToSwapScene());
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("hey");
            
        }

        private IEnumerator WaitToSwapScene()
        {
            yield return new WaitForSeconds(1); ;
            SceneManager.LoadScene("Scenes/Prototypes/Night_Fight");
        }
    }
}
