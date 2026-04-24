using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using WitchGate.Controllers;
using WitchGate.Gameplay;
using WitchGate.Gameplay.Battles;
using WitchGate.Gameplay.Battles.Entities;
using WitchGate.Gameplay.Controller;
using WitchGate.Gameplay.Entities;
using WitchGate.Players;

namespace WitchGate.Prototype
{
    public class FightTrigger : MonoBehaviour
    {
        [field: SerializeField]
        private Animator animator;
        
        [field: SerializeField]
        private BattleProfile enemyProfile;
        
        private void OnTriggerEnter(Collider other)
        {
            ExplorationGameplayManager.Instance.LockPlayerMovement();
            StartCoroutine(WaitAnimation());
        }
        
        private IEnumerator WaitAnimation()
        {
            animator.SetTrigger("Apparition");
            float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSecondsRealtime(animationLength);
            StartBattle();
        }

        
        //Would be great to bind it to some dialog and be happy
        private void StartBattle()
        {
            BattleController.StartBattle(enemyProfile);
        }
    }
}
