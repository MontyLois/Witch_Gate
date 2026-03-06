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
    public class Monster : MonoBehaviour
    {
        [field: SerializeField]
        private GameObject sprite;
        
        [field: SerializeField]
        private Animator animator;
        
        [field: SerializeField]
        private BattleProfile enemyProfile;
        
        private void OnTriggerEnter(Collider other)
        {
            sprite.SetActive(true);
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

        private void StartBattle()
        {
            BattlePhase phase = new BattlePhase(new BattleEnemy(enemyProfile));
            phase.Run();
        }
    }
}
